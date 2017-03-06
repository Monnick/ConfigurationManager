﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager
{
	public interface IConfigurationManager : IConfigurationRoot
	{
		void Bind(string prefix, object dto);
	}
}
