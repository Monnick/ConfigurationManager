using ConfigurationManager.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ConfigurationManager.Tests
{
	public class ComplexTest : IClassFixture<ConfigurationFixture>
	{
		private ConfigurationManager _sut;

		public ComplexTest(ConfigurationFixture fixture)
		{
			_sut = fixture.Fixture;
		}

		[Fact]
		public void ComplexSimpleStringTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.Equal("complex string simple", complex.String);
		}

		[Fact]
		public void ComplexSimpleIntegerTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.Equal(15, complex.Integer);
		}

		[Fact]
		public void ComplexStringTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.Equal("complex-string", complex.Complex.String);
		}

		[Fact]
		public void ComplexIntegerTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.Equal(9, complex.Complex.Integer);
		}

		[Fact]
		public void ComplexStringReadonlyTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.NotEqual("complex-readonly", complex.Complex.StringReadonly);
		}

		[Fact]
		public void ComplexIntegerReadonlyTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.NotEqual(11, complex.Complex.IntegerReadonly);
		}

		[Fact]
		public void ComplexStringPrivateTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.NotEqual("complex-private", complex.Complex.GetStringPrivate());
		}

		[Fact]
		public void ComplexIntegerPrivateTest()
		{
			Mocks.MockComplex complex = new Mocks.MockComplex();

			_sut.Bind("complex", complex);

			Assert.NotEqual(13, complex.Complex.GetIntegerPrivate());
		}
	}
}
