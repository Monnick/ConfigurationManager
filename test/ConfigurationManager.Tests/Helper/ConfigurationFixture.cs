using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConfigurationManager.Tests.Helper
{
	public class ConfigurationFixture
	{
		public ConfigurationManager Fixture { get; set; }

		public ConfigurationFixture()
		{
			Fixture = new ConfigurationManager(System.IO.Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\appsettings.json"));
		}
	}
}
