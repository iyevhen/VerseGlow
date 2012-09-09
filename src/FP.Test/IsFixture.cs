using System;
using NUnit.Framework;

namespace FreePresenter.UI.Test
{
	[TestFixture]
	public class IsFixture
	{
		[Test]
		public void Guard_defends()
		{
			Assert.Throws<ArgumentException>(
				() => Is.Not(true)
				      	.Throw<ArgumentException>("This is Guard Testing"));
		}

		[Test]
		public void Guard_defends_is_passing_through()
		{
			Assert.DoesNotThrow(
				() => Is.Not(false)
				      	.Throw<ArgumentException>("This is Guard Testing"));
		}

		[Test]
		public void Guard_argument_shouldnt_be_null_or_empty()
		{
			Assert.Throws<ArgumentException>(
				() => Is.NotNullOrEmpty("", "param"));

			Assert.Throws<ArgumentException>(
				() => Is.NotNullOrEmpty(null, "param"));

			Assert.DoesNotThrow(
				() => Is.NotNullOrEmpty("value", "param"));
		}

		[Test]
		public void Guard_argument_shouldnt_be_null()
		{
			Assert.DoesNotThrow(
				() => Is.NotNull(string.Empty, ""));

			string val = null;
			Assert.Throws<ArgumentNullException>(
				() => Is.NotNull(val, ""));
		}

	}
}