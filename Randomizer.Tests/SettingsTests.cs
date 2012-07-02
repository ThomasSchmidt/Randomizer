using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Randomizer.Tests
{
	[TestFixture]
	public class SettingsTests
	{
		[Test]
		public void CanCreateDefaultSettings()
		{
			//arrange + act
			ISettings actual = Settings.Default();

			Assert.That(actual.AllowNulls, Is.False, "AllowNulls was not false");
			Assert.That(actual.NullPercentage, Is.EqualTo(10M), "NullPercentage is not 10%");
			Assert.That(actual.MinStringLength, Is.EqualTo(2), "MinStringLength was not 2");
			Assert.That(actual.MaxStringLength, Is.EqualTo(50), "MaxStringLength was not 50");
			Assert.That(actual.MaxCollectionCount, Is.EqualTo(10), "MaxCollectionCount was not 10");
		}
	}
}
