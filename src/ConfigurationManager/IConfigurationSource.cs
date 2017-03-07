using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager
{
	public interface IConfigurationSource : IConfigurationRoot
	{
		/// <summary>
		/// Binds the data from an appsettings file to a dataObject.
		/// </summary>
		/// <param name="prefix">The settings prefix to filter for</param>
		/// <param name="t">The type to bind the file to</param>
		/// <param name="dataObject">The object holder to obtain the data</param>
		void Bind(string prefix, Type t, object dataObject);

		/// <summary>
		/// Binds the data from an appsettings file to a dataObject.
		/// </summary>
		/// <typeparam name="T">The dataObject type</typeparam>
		/// <param name="prefix">The settings prefix to filter for</param>
		/// <param name="dataObject">The object holder to obtain the data</param>
		void Bind<T>(string prefix, T dataObject);
	}
}
