using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager
{
	public interface IConfigurationManager : IConfigurationSource
	{
		/// <summary>
		/// Initializes the configuration manager.
		/// </summary>
		/// <param name="builder">The configuration builder to access the settings file and environment data</param>
		void Initialize(IConfigurationBuilder builder);

		/// <summary>
		/// Initializes the configuration manager.
		/// </summary>
		/// <param name="env">The hosting environment</param>
		/// <param name="settingsFile">The path to the appsettings file</param>
		void Initialize(IHostingEnvironment env, string settingsFile);

		/// <summary>
		/// Initializes the configuration manager.
		/// </summary>
		/// <param name="config">The configuration created by an outside context</param>
		void Initialize(IConfigurationRoot config);
	}
}
