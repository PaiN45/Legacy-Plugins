using Oxide.Core;
using Oxide.Core.Plugins;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using RustProto;

namespace Oxide.Plugins
{
	
	
	[Info("IP White list", "PaiN", "1.0.0")]
	public class IPwhitelist : RustLegacyPlugin
	{
		
		public void Loaded()
		{
		LoadDefaultConfig();
		}
		
		protected override void LoadDefaultConfig()
		{
		Puts("Creating new configuration file!");
		
		List<string> allowedips = new List<string>() { "999.9999.9999.9", "999.99.99.999.99" };
		Config["AllowedIPs"] = allowedips;
		SaveConfig();
		}
		
		void CanClientLogin(ClientConnection connection, uLink.NetworkPlayerApproval approval)
		{		
			List<string> allowedips = Config["AllowedIPs"] as List<string>;
			foreach(string allowedip in allowedips)
			{
				var ip = approval.ipAddress;
				if (ip != allowedip)
				{
					return;
				}
			}
		}
	}
}
