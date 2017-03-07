using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Hosting;

namespace ConfigurationManager
{
	public class ConfigurationManager : IConfigurationManager
	{
		private static Lazy<IConfigurationManager> _instance = new Lazy<IConfigurationManager>(() => new ConfigurationManager());

		public static IConfigurationManager Manager
		{
			get { return _instance.Value; }
		}

		private IConfigurationSource Configuration { get; set; }

		public string this[string key]
		{
			get { return Configuration[key]; }
			set { Configuration[key] = value; }
		}

		private ConfigurationManager()
		{
			Configuration = null;
		}
		
		private void InitializeConfiguration(IConfigurationBuilder builder)
		{
			if (Configuration == null)
				Configuration = new ConfigurationSource(builder);
			else throw new InvalidOperationException("already initialized");
		}
		
		public void Initialize(IConfigurationBuilder builder)
		{
			InitializeConfiguration(builder);

		}
		
		public void Initialize(IHostingEnvironment env, string settingsFile)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			InitializeConfiguration(builder);
		}

		public void Bind(string prefix, Type t, object dataObject)
		{
			Configuration?.Bind(prefix, t, dataObject);
		}

		public void Bind<T>(string prefix, T dataObject)
		{
			Configuration?.Bind(prefix, dataObject);
		}

		public void Reload()
		{
			Configuration?.Reload();
		}

		public IConfigurationSection GetSection(string key)
		{
			return Configuration?.GetSection(key);
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			return Configuration?.GetChildren();
		}

		public IChangeToken GetReloadToken()
		{
			return Configuration?.GetReloadToken();
		}
	}
}
