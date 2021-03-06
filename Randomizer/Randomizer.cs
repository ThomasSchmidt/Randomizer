﻿using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Randomizer.Cache;
using Randomizer.Generators;

namespace Randomizer
{
	public static class Randomizer
	{
		private static readonly Random _random = new Random(DateTime.Now.Millisecond);

		public static T Randomize<T>() where T : class, new()
		{
			return Randomize<T>(Settings.Default());
		}

		public static T Randomize<T>(ISettings settings) where T : class, new()
		{
			if (settings == null)
				return default(T);

			settings.Validate();

			return Randomize<T>(typeof(T), settings);
		}

		private static T Randomize<T>(Type type, ISettings settings)
		{
			T result = (T)Activator.CreateInstance(type);

			return (T)GenerateRandom(result, settings, 0);
		}

		private static object GenerateRandom(object random, ISettings settings, int currentDepth)
		{
			if (currentDepth > settings.MaxDepth)
				return random;

			//loop through all public properties and randomize values
			PropertyInfo[] properties = TypeCache.GetMembers(random.GetType());
			foreach (PropertyInfo propertyInfo in properties)
			{
				IGenerator generator = GeneratorFactory.Create(propertyInfo.PropertyType, settings);
				if (generator == null)
					throw new NotSupportedException("The property " + propertyInfo.Name + " with type " + propertyInfo.PropertyType + " is not supported");
				object val = generator.Create();
				propertyInfo.SetValue(random, val, null);
				currentDepth++;
				if ( currentDepth > settings.MaxDepth) //break out of recursion if needed
					return random;
				foreach (object o in generator.AdditionalObjectsToRandomize)
				{
					GenerateRandom(o, settings, currentDepth + 1);
				}
				currentDepth--;
			}

			return random;
		}

		
	}
}
