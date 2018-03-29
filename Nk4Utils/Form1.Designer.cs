namespace Nk4Utils
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.textBoxHost = new System.Windows.Forms.TextBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxPwd = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkLabelAutoHost = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.配置CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.编辑配置文件EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.backgroundWorkerLog = new System.ComponentModel.BackgroundWorker();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.backgroundWorkerStatus = new System.ComponentModel.BackgroundWorker();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.启动NetkeeperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.重新加载RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonStop = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point(257, 365);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(96, 23);
			this.buttonLogin.TabIndex = 0;
			this.buttonLogin.Text = "开始监测(&S)";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// textBoxHost
			// 
			this.textBoxHost.Location = new System.Drawing.Point(53, 26);
			this.textBoxHost.Name = "textBoxHost";
			this.textBoxHost.Size = new System.Drawing.Size(95, 21);
			this.textBoxHost.TabIndex = 1;
			// 
			// textBoxUser
			// 
			this.textBoxUser.Location = new System.Drawing.Point(53, 57);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(130, 21);
			this.textBoxUser.TabIndex = 2;
			// 
			// textBoxPwd
			// 
			this.textBoxPwd.Location = new System.Drawing.Point(53, 88);
			this.textBoxPwd.Name = "textBoxPwd";
			this.textBoxPwd.PasswordChar = '*';
			this.textBoxPwd.Size = new System.Drawing.Size(130, 21);
			this.textBoxPwd.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.linkLabelAutoHost);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxPwd);
			this.groupBox1.Controls.Add(this.textBoxHost);
			this.groupBox1.Controls.Add(this.textBoxUser);
			this.groupBox1.Location = new System.Drawing.Point(12, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 118);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SSH 连接设置";
			// 
			// linkLabelAutoHost
			// 
			this.linkLabelAutoHost.AutoSize = true;
			this.linkLabelAutoHost.Location = new System.Drawing.Point(154, 29);
			this.linkLabelAutoHost.Name = "linkLabelAutoHost";
			this.linkLabelAutoHost.Size = new System.Drawing.Size(29, 12);
			this.linkLabelAutoHost.TabIndex = 7;
			this.linkLabelAutoHost.TabStop = true;
			this.linkLabelAutoHost.Text = "检测";
			this.linkLabelAutoHost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAutoHost_LinkClicked);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "密码";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "用户名";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "Host";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置CToolStripMenuItem,
            this.工具TToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(610, 25);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 配置CToolStripMenuItem
			// 
			this.配置CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑配置文件EToolStripMenuItem,
            this.toolStripSeparator1,
            this.重新加载RToolStripMenuItem});
			this.配置CToolStripMenuItem.Name = "配置CToolStripMenuItem";
			this.配置CToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
			this.配置CToolStripMenuItem.Text = "配置(&C)";
			// 
			// 编辑配置文件EToolStripMenuItem
			// 
			this.编辑配置文件EToolStripMenuItem.Name = "编辑配置文件EToolStripMenuItem";
			this.编辑配置文件EToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.编辑配置文件EToolStripMenuItem.Text = "编辑配置文件(&E)";
			this.编辑配置文件EToolStripMenuItem.Click += new System.EventHandler(this.编辑配置文件EToolStripMenuItem_Click);
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.Controls.Add(this.flowLayoutPanel1);
			this.groupBoxStatus.Location = new System.Drawing.Point(12, 152);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Size = new System.Drawing.Size(189, 203);
			this.groupBoxStatus.TabIndex = 6;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "接口状态";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(183, 183);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxLog);
			this.groupBox3.Location = new System.Drawing.Point(207, 28);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(391, 327);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "PPPoE 日志";
			// 
			// textBoxLog
			// 
			this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLog.Location = new System.Drawing.Point(6, 20);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxLog.Size = new System.Drawing.Size(379, 301);
			this.textBoxLog.TabIndex = 0;
			this.textBoxLog.WordWrap = false;
			this.textBoxLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLog_KeyPress);
			// 
			// backgroundWorkerLog
			// 
			this.backgroundWorkerLog.WorkerSupportsCancellation = true;
			this.backgroundWorkerLog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLog_DoWork);
			// 
			// backgroundWorkerStatus
			// 
			this.backgroundWorkerStatus.WorkerSupportsCancellation = true;
			this.backgroundWorkerStatus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerStatus_DoWork);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(15, 369);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(186, 16);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "启动监测后自动打开Netkeeper";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// 工具TToolStripMenuItem
			// 
			this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动NetkeeperToolStripMenuItem});
			this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
			this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.工具TToolStripMenuItem.Text = "工具(&T)";
			// 
			// 启动NetkeeperToolStripMenuItem
			// 
			this.启动NetkeeperToolStripMenuItem.Name = "启动NetkeeperToolStripMenuItem";
			this.启动NetkeeperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.启动NetkeeperToolStripMenuItem.Text = "启动Netkeeper(&N)";
			this.启动NetkeeperToolStripMenuItem.Click += new System.EventHandler(this.启动NetkeeperToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
			// 
			// 重新加载RToolStripMenuItem
			// 
			this.重新加载RToolStripMenuItem.Name = "重新加载RToolStripMenuItem";
			this.重新加载RToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.重新加载RToolStripMenuItem.Text = "重新加载(&R)";
			this.重新加载RToolStripMenuItem.Click += new System.EventHandler(this.重新加载RToolStripMenuItem_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(267, 365);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 9;
			this.buttonStop.Text = "停止(&T)";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Visible = false;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// Form1
			// 
			this.AcceptButton = this.buttonLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 396);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBoxStatus);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.buttonStop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PandoraBox路由网络监测工具";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBoxStatus.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.TextBox textBoxHost;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.TextBox textBoxPwd;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel linkLabelAutoHost;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 配置CToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 编辑配置文件EToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.ComponentModel.BackgroundWorker backgroundWorkerLog;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.BackgroundWorker backgroundWorkerStatus;
		private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 启动NetkeeperToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 重新加载RToolStripMenuItem;
		private System.Windows.Forms.Button buttonStop;
	}
}

