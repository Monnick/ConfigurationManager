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
	public class ConfigurationSource : IConfigurationSource
	{
		private IConfigurationRoot _standardRoot;
		
		public ConfigurationSource(IConfigurationBuilder builder)
			: this(builder.Build())
		{
		}
		public ConfigurationSource(IConfigurationRoot config)
		{
			_standardRoot = config;
		}
		public ConfigurationSource(IHostingEnvironment env, string settingsFile)
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

		public void Bind<T>(string prefix, T dataObject)
		{
			Bind(prefix, typeof(T), dataObject);
		}

		public void Bind(string prefix, Type t, object dataObject)
		{
			if (dataObject == null)
				return;

			var properties = t.GetProperties();
			foreach (var property in properties.Where(p => p.SetMethod.IsPublic))
			{
				string key = prefix + "." + property.Name;
				if (PropertyTypeIsBasic(property.PropertyType.GetTypeInfo()))
				{
					object value = ConfigurationBinder.GetValue(this, property.PropertyType, key, property.GetValue(dataObject));
					property.SetValue(dataObject, value);
				}
				else
				{
					Bind(key, property.PropertyType, property.GetValue(dataObject));
				}
			}
		}

		private bool PropertyTypeIsBasic(TypeInfo t)
		{
			return t.IsPrimitive || t.IsValueType || t.UnderlyingSystemType == typeof(string);
		}
	}
}
