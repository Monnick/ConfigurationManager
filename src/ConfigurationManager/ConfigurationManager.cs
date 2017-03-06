using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace ConfigurationManager
{
	public sealed class ConfigurationManager : IConfigurationManager
	{
		private IConfigurationRoot _standardRoot;

		public ConfigurationManager()
			: this("appsettings.json")
		{ }
		public ConfigurationManager(string settingsFile)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();

			_standardRoot = builder.Build();
		}
		public ConfigurationManager(IHostingEnvironment env, string settingsFile)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(settingsFile, optional: true, reloadOnChange: true)
				.AddEnvironmentVariables();
			
			_standardRoot = builder.Build();
		}
		
		public string this[string key]
		{
			get
			{
				return _standardRoot[key];
			}
			set
			{
				_standardRoot[key] = value;
			}
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			return _standardRoot.GetChildren();
		}

		public IChangeToken GetReloadToken()
		{
			return _standardRoot.GetReloadToken();
		}

		public IConfigurationSection GetSection(string key)
		{
			return _standardRoot.GetSection(key);
		}

		public void Reload()
		{
			_standardRoot.Reload();
		}
		
		public void Bind(string prefix, object dto)
		{
			Type t = dto.GetType();

			var properties = t.GetProperties();
			foreach (var property in properties.Where(p => p.SetMethod.IsPublic))
			{
				string key = prefix + "." + property.Name;
				if (PropertyTypeIsBasic(property.PropertyType.GetTypeInfo()))
				{
					object value = ConfigurationBinder.GetValue(this, property.PropertyType, key, property.GetValue(dto));
					property.SetValue(dto, value);
				}
				else
				{
					Bind(key, property.GetValue(dto));
				}
			}
		}

		private bool PropertyTypeIsBasic(TypeInfo t)
		{
			return t.IsPrimitive || t.IsValueType || t.UnderlyingSystemType == typeof(string);
		}
	}
}
