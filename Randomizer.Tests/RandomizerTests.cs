using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Randomizer.Generators;

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

		[Test]
		public void RandomizerPerformanceTest()
		{
			//arrange
			Randomizer.Randomize<TestDummy>(); //warmup
			const int loopCount = 10;
			long total = 0, avg = 0L;
			for (int i = 0; i < loopCount; i++)
			{
				long result = Time(() => Randomizer.Randomize<TestDummy>());
				total += result;
			}
			avg = total/loopCount;

			//assert
			Assert.That(total, Is.LessThan(100), "It took longer than 100ms to run the test");
			Assert.That(avg, Is.LessThan(10));
		}

		private long Time(Action action)
		{
			Stopwatch w = Stopwatch.StartNew();
			action();
			w.Stop();
			return w.ElapsedMilliseconds;
		}
	}
}
