using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Randomizer.Tests
{
	[TestFixture]
	public class RandomizerTests
	{
		[Test]
		public void CanCreateRandomInstanceOfTestDummyWithDefaultSettings()
		{
			//arrange + act
			TestDummy actual = Randomizer.Randomize<TestDummy>();

			//assert
			Assert.That(actual, Is.Not.Null, "actual was null");
			//Assert.That(actual.StringProperty1, Has.Length.AtLeast(2), "StringProperty1 was not at least 2 chars");
			//Assert.That(actual.GuidProperty1, Is.Not.EqualTo(Guid.Empty), "GuidProperty was empty");
			//Assert.That(actual.NullableGuidProperty1, Is.Not.Null, "NullableGuidProperty1 was null");
		}

		[Test]
		public void WhenProvidedWithSettingsThatAllowNullsAndHas100PercentageNullsAllNullableFieldsShouldBeNull()
		{
			//arrange
			ISettings settings = new Settings{AllowNullCollections = true, AllowNulls = true, NullPercentage = 100};

			//act
			TestDummy actual = Randomizer.Randomize<TestDummy>(settings);

			//assert
			//Assert.That(actual.StringProperty1, Is.Null);
			//Assert.That(actual.NullableCharProperty1, Is.Null);
			//Assert.That(actual.NullableGuidProperty1, Is.Null);
			//Assert.That(actual.NullableIntProperty1, Is.Null);
			//Assert.That(actual.NullableLongProperty1, Is.Null);
		}
	}
}
