using ConfigurationManager.Tests.Helper;
using System;
using Xunit;

namespace ConfigurationManager.Tests
{
	public class SimpleTest : IClassFixture<ConfigurationFixture>
	{
		private ConfigurationManager _sut;

		public SimpleTest(ConfigurationFixture fixture)
		{
			_sut = fixture.Fixture;
		}

		[Fact]
		public void SimpleStringTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.Equal("string", simple.String);
		}

		[Fact]
		public void SimpleIntegerTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.Equal(2, simple.Integer);
		}

		[Fact]
		public void SimpleStringReadonlyTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.NotEqual("readonly", simple.StringReadonly);
		}

		[Fact]
		public void SimpleIntegerReadonlyTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.NotEqual(4, simple.IntegerReadonly);
		}

		[Fact]
		public void SimpleStringPrivateTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.NotEqual("private", simple.GetStringPrivate());
		}

		[Fact]
		public void SimpleIntegerPrivateTest()
		{
			Mocks.MockClass simple = new Mocks.MockClass();

			_sut.Bind("simple", simple);

			Assert.NotEqual(6, simple.GetIntegerPrivate());
		}
	}
}
