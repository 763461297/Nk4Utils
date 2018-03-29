using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nk4Utils
{
	class InterfaceStatus
	{
		private String tag;
		private String username;
		private Boolean online;
		private String eth;

		public InterfaceStatus(String tag, Boolean online)
		{
			this.online = online;
			this.Tag = tag;
		}

		public String UserName
		{
			set { username = value;}
			get { return username; }
		}

		public Boolean OnLine
		{
			set { online = value; }
			get { return online;}
		}

		public String Tag
		{
			set { tag = value; }
			get { return tag; }
		}

		public String Eth
		{
			set { eth = value; }
			get { return eth; }
		}
	}
}
