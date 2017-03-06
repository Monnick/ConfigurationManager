using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager.Tests.Mocks
{
	public class MockComplex
	{
		public MockClass Complex { get; set; }

		public int Integer { get; set; }

		public string String { get; set; }

		public MockComplex()
		{
			Complex = new Mocks.MockClass();
		}
	}
}
