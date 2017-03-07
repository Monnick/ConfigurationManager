using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;

namespace ConfigurationManager.Tests.Helper
{
	public class ConfigurationFixture : IDisposable
	{
		public ConfigurationFixture()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile(System.IO.Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\appsettings.json"), optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			ConfigurationManager.Manager.Initialize(builder);
		}
	
		public void Dispose()
		{
			// no data to dispose
		}
	}
}
