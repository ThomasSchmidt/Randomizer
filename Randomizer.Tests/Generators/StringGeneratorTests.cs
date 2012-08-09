using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Randomizer.Generators;

namespace Randomizer.Tests.Generators
{
	[TestFixture]
	public class StringGeneratorTests
	{
		[Test]
		public void CanGenerateRandomStringWithDefaultSettings()
		{
			//arrange
			ISettings settings = Settings.Default();
			StringGenerator generator = new StringGenerator(settings);

			//act
			string actual = generator.Create() as string;

			//assert
			Assert.That(actual == null || actual.Length > 0, Is.True);
		}

		[Test]
		public void CanGenerateRandomStringWithOnlyNulls()
		{
			//arranage
			ISettings settings = Settings.Default();
			settings.AllowNulls = true;
			settings.NullPercentage = 100;
			StringGenerator generator = new StringGenerator(settings);

			//act
			string actual = generator.Create() as string;

			//assert
			Assert.That(actual, Is.Null);
		}
	}
}
