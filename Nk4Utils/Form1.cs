using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tamir.SharpSsh;

namespace Nk4Utils
{
	public partial class Form1 : Form
	{
		private SshExec exec;
		private SshExec exec2;
		private String[] ifList;
		private String nk4path = null;
		private String nppPath = null;
		private Configure conf;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender,EventArgs e)
		{
			loadConfig();
		}

		private delegate void ShowAlertCallback(string text,string caption,MessageBoxButtons buttons,MessageBoxIcon icon);
		private void ShowAlert(string text,string caption,MessageBoxButtons buttons,MessageBoxIcon icon)
		{
			MessageBox.Show(text,caption,buttons,icon);
		}

		private void buttonLogin_Click(object sender,EventArgs e)
		{
			try
			{
				buttonLogin.Visible = false;
				buttonStop.Visible = true;

				groupBox1.Enabled = false;
				checkBox1.Enabled = false;

				String host = textBoxHost.Text;
				String user = textBoxUser.Text;
				String pwd = textBoxPwd.Text;
				exec = new SshExec(host, user, pwd);
				exec2 = new SshExec(host, user, pwd);

				new Thread(() => {
					try
					{
						exec.Connect();
					} catch (Exception ex)
					{
						this.Invoke(new ShowAlertCallback(ShowAlert),
							new Object[] {ex.Message,"接口状态监控模块",MessageBoxButtons.OK,MessageBoxIcon.Error});
						return;
					}
					if(backgroundWorkerStatus.IsBusy) return;
					backgroundWorkerStatus.RunWorkerAsync();
				}).Start();

				new Thread(() =>
				{
					try
					{
						exec2.Connect();
					} catch (Exception ex)
					{
						this.Invoke(new ShowAlertCallback(ShowAlert),
							new Object[] { ex.Message,"日志监控模块",MessageBoxButtons.OK,MessageBoxIcon.Error });
						return;
					}
					if(backgroundWorkerLog.IsBusy) return;
					backgroundWorkerLog.RunWorkerAsync();
				}).Start();

				
				new Thread(() => {
					if(!checkBox1.Checked)
					{ 
						return;
					}
					while(true)
					{
						Thread.Sleep(1000);
						if(checkBox1.Checked && backgroundWorkerLog.IsBusy && backgroundWorkerStatus.IsBusy)
						{
							启动NetkeeperToolStripMenuItem_Click(null, null);
							return;
						}
					}
				}).Start();
			}
			catch(Exception ex)
			{
				
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void buttonStop_Click(object sender,EventArgs e)
		{
			buttonLogin.Visible = true;
			buttonStop.Visible = false;
			groupBox1.Enabled = true;
			checkBox1.Enabled = true;

			backgroundWorkerLog.CancelAsync();
			backgroundWorkerLog.Dispose();
			backgroundWorkerStatus.CancelAsync();
			backgroundWorkerStatus.Dispose();
		}

		private void linkLabelAutoHost_LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
		{
			string hostName = Dns.GetHostName();
			IPAddress[] adds = Dns.GetHostAddresses(hostName);
			ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection nics = mc.GetInstances();
			foreach(ManagementObject i in nics)
			{
				if(Convert.ToBoolean(i["ipEnabled"]) == true)
				{
					string ip = (i["DefaultIPGateway"] as string[])[0];
					MessageBox.Show("侦测到网关地址：" + ip,"侦测到IP",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
					textBoxHost.Text = ip;
					return;
				}
			}
			MessageBox.Show("未检测到网关信息，请手动输入","未找到",
						MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void textBoxLog_KeyPress(object sender,KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private delegate void UpdateLogCallback(String[] str);

		private void backgroundWorkerLog_DoWork(object sender,DoWorkEventArgs e)
		{
			String preStr = "";
			while(true)
			{
				try
				{
					// 获取日志
					String str = exec2.RunCommand("tail -100 /tmp/pppoe.log");
					String[] opt = GetLastUpdateLog(preStr,str);
					if(backgroundWorkerLog.CancellationPending)
					{
						exec2.Close();
						break;
					}
					this.Invoke(new UpdateLogCallback(UpdateLogContent),new Object[]{opt});
					preStr = str;
				} catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				Thread.Sleep(1000);
			}
		}

		private delegate void UpdateInterfaceStatucCallback(List<InterfaceStatus> ifsList);

		private void backgroundWorkerStatus_DoWork(object sender,DoWorkEventArgs e)
		{
			while(true)
			{
				try
				{
					// 获取接口状态
					String uciCom = exec.RunCommand("uci show network | grep -E \"(network\\.)\\w+(\\.proto='pppoe')\" | cut -d . -f 2");
					ifList = uciCom.Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries);
					List<InterfaceStatus> list = new List<InterfaceStatus>();
					foreach(String ifname in ifList)
					{
						String eth = exec.RunCommand("uci show network." + ifname + ".ifname | cut -d = -f 2 | cut -d \\' -f 2");
						String res = exec.RunCommand("ifconfig | grep pppoe-" + ifname);
						InterfaceStatus ifs = new InterfaceStatus(ifname, false);
						ifs.Eth = eth;
						if(!res.Trim().Equals(""))
						{
							String user = exec.RunCommand("uci show network." + ifname + ".username | cut -d = -f 2 | cut -c 13-23");
							ifs.UserName = user;
							ifs.OnLine = true;
						}
						list.Add(ifs);
					}
					if(backgroundWorkerStatus.CancellationPending)
					{
						exec.Close();
						break;
					}
					this.Invoke(new UpdateInterfaceStatucCallback(UpdateInterfaceStatus), list);
				} catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				Thread.Sleep(1000);
			}
		}

		private String[] GetLastUpdateLog(String last, String now)
		{
			List<String> tmpList = new List<String>();
			tmpList.AddRange(now.Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries));
			int nowLen = tmpList.Count;
			tmpList.AddRange(last.Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries));
			int len = tmpList.Count;
			int[] next = new int[len + 1];
			next[0] = -1;
			int k = -1;
			int j = 0;
			while(j < len)
			{
				//k表示前缀最后一位，j表示后缀最后一位  
				if(k == -1 || tmpList[j].Equals(tmpList[k]))
				{
					next[++j] = ++k;
				}
				else // 失配时，移动k指针，即步骤3  
				{
					k = next[k];
				}
			}
			int maxCommon = next[len];
			return tmpList.GetRange(maxCommon,nowLen - maxCommon).ToArray();
		} 

		private void UpdateLogContent(String[] str)
		{
			foreach(String s in str)
			{
				textBoxLog.AppendText(s + "\r\n");
			}
		}

		private Panel GetInterfaceStatusPanel(Control parent, InterfaceStatus ifs)
		{
			// 接口状态容器
			Panel panel = new Panel();
			panel.Width = parent.Width - 25;
			panel.Height = 50;
			panel.Anchor = AnchorStyles.Right;
			panel.Tag = ifs.Tag;
			panel.BorderStyle = BorderStyle.FixedSingle;
			panel.BackColor = ifs.OnLine ? Color.LightGreen : Color.Pink;
			// 顶端接口名
			Label label = new Label();
			label.Text = ifs.Tag;
			label.Font = new Font(new FontFamily("Consolas"), 15, FontStyle.Bold);
			label.TextAlign = ContentAlignment.MiddleCenter;
			label.Width = panel.Width;
			panel.Controls.Add(label);
			// 中间水平分割线
			Label splitLine = new Label();
			splitLine.Width = panel.Width - 12;
			splitLine.Top = 25;
			splitLine.BackColor = Color.Gray;
			splitLine.Height = 1;
			splitLine.Left = 5;
			panel.Controls.Add(splitLine);
			// 接口连接用户
			Label ifconn = new Label();
			ifconn.Text = ifs.OnLine ? ifs.UserName : "offline";
			ifconn.Font = new Font(new FontFamily("Consolas"),10);
			ifconn.TextAlign = ContentAlignment.MiddleCenter;
			ifconn.Width = panel.Width;
			ifconn.Top = 26;
			panel.Controls.Add(ifconn);

			return panel;
		}

		private void UpdateInterfaceStatus(List<InterfaceStatus> list)
		{
			List<Control> cList = new List<Control>();
			foreach(InterfaceStatus ifs in list)
			{
				Panel panel = GetInterfaceStatusPanel(flowLayoutPanel1, ifs);
				cList.Add(panel);
			}
			flowLayoutPanel1.Controls.Clear();
			flowLayoutPanel1.Controls.AddRange(cList.ToArray());
		}

		private void 编辑配置文件EToolStripMenuItem_Click(object sender,EventArgs e)
		{
			try
			{
				if(nppPath != null)
				{
					System.Diagnostics.Process.Start(nppPath, Application.StartupPath + @"\properties.xml");
				}
				else
				{
					System.Diagnostics.Process.Start("notepad.exe",Application.StartupPath + @"\properties.xml");
				}
			} 
			catch(Exception)
			{
				MessageBox.Show("无法打开编辑器","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void 启动NetkeeperToolStripMenuItem_Click(object sender,EventArgs e)
		{
			try
			{
				if(nk4path == null)
				{
					MessageBox.Show("未配置Netkeeper启动路径，无法启动Netkeeper，请编辑配置文件的<nk4path>节点！" + nk4path,"启动错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				System.Diagnostics.Process.Start(nk4path);
			}
			catch(Exception)
			{
				MessageBox.Show("无法启动Netkeeper，在位置" + nk4path,"启动错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void 重新加载RToolStripMenuItem_Click(object sender,EventArgs e)
		{
			loadConfig();
		}

		private void loadConfig()
		{
			conf = Configure.ReadConfigure("properties.xml");
			if(conf != null)
			{
				textBoxHost.Text = conf.Host;
				textBoxUser.Text = conf.User;
				textBoxPwd.Text = conf.Password;
				nk4path = conf.Path;
				nppPath = conf.Npp;
				checkBox1.Checked = conf.NkAuto;
			}
		}

		private void Form1_FormClosed(object sender,FormClosingEventArgs e)
		{
			if(buttonStop.Visible)
			{
				DialogResult res = MessageBox.Show("监控正在运行，确实要退出吗？","退出",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
				if(res == DialogResult.Yes)
				{
					buttonStop.PerformClick();
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

	}

}
