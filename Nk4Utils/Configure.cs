using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Nk4Utils
{
	class Configure
	{
		private String user;

		public String User
		{
			get { return user; }
			set { user = value; }
		}
		private String password;

		public String Password
		{
			get { return password; }
			set { password = value; }
		}
		private String path;

		public String Path
		{
			get { return path; }
			set { path = value; }
		}
		private String host;

		public String Host
		{
			get { return host; }
			set { host = value; }
		}

		private String npp;

		public String Npp
		{
			get { return npp; }
			set { npp = value; }
		}

		private Boolean nkAuto;

		public Boolean NkAuto
		{
			get { return nkAuto; }
			set { nkAuto = value; }
		}


		public static Configure ReadConfigure(String file)
		{
			String path = Application.StartupPath + @"\" + file;
			XmlDocument xmlDoc = new XmlDocument();
			Dictionary<String,String> map = new Dictionary<string,string>();
			try
			{
				xmlDoc.Load(path);
				XmlNode root = xmlDoc.SelectSingleNode("configure");
				XmlNodeList lst = root.ChildNodes;
				foreach(XmlNode node in lst)
				{
					map.Add(node.Name,node.InnerText);
				}
				Configure conf = new Configure();
				try{ conf.Host = map["host"];} catch (Exception) {}
				try{ conf.User = map["username"];} catch (Exception) {}
				try{ conf.Password = map["password"];} catch (Exception) {}
				try{ conf.Path = map["nk4path"];} catch (Exception) {}
				try { conf.Npp = map["npp"]; } catch(Exception) { conf.Npp = getNppPath(); }
				try { conf.NkAuto = map["nk4auto"].Equals("1") ? true : false; } catch(Exception) { conf.NkAuto = true; }
				return conf;
			}
			catch (Exception)
			{
				return null;
			}
		}
		public static void WriteConfigure(Configure conf,String file)
		{
			String path = Application.StartupPath + @"\" + file;
			try
			{
				XmlDocument xml = new XmlDocument();
				xml.Load(path);
				XmlNode root = xml.SelectSingleNode("configure");
				XmlNodeList lst = root.ChildNodes;
			}
			catch(Exception ex)
			{
			}
		}

		public static String getNppPath()
		{
			String npp_x86 = @"C:\Program Files (x86)\Notepad++\notepad++.exe";
			String npp_x64 = @"C:\Program Files\Notepad++\notepad++.exe";
			if(File.Exists(npp_x86))
			{
				return npp_x86;
			}
			else if(File.Exists(npp_x64))
			{
				return npp_x64;
			}
			return null;
		}
	}
}
