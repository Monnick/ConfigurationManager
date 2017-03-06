using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager.Tests.Mocks
{
	public class MockClass
	{
		public int Integer { get; set; }

		public string String { get; set; }

		public int IntegerReadonly { get; private set; }

		public string StringReadonly { get; private set; }

		private int IntegerPrivate { get; set; }

		private string StringPrivate { get; set; }

		public int GetIntegerPrivate()
		{
			return IntegerPrivate;
		}

		public string GetStringPrivate()
		{
			return StringPrivate;
		}
	}
}
