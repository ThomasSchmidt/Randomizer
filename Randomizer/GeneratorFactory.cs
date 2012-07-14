using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Randomizer.Generators;

namespace Randomizer
{
	internal static class GeneratorFactory
	{
		private static readonly Dictionary<string, IGenerator> _generatorCache = new Dictionary<string, IGenerator>();

		internal static IGenerator Create(Type type, ISettings settings)
		{
			string cacheKey = type.ToString();
			if (_generatorCache.ContainsKey(cacheKey))
				return _generatorCache[cacheKey];

			if (type == typeof(int))
				return CacheGenerator(cacheKey, new IntGenerator(settings));
			if ( type == typeof(int?))
				return CacheGenerator(cacheKey, new NullableIntGenerator(settings));
			if ( type == typeof(string))
				return CacheGenerator(cacheKey, new StringGenerator(settings));
			if ( type == typeof(char))
				return CacheGenerator(cacheKey, new CharGenerator(settings));
			if (type == typeof(char?))
				return CacheGenerator(cacheKey, new NullableCharGenerator(settings));
			if ( type == typeof(Guid))
				return CacheGenerator(cacheKey, new GuidGenerator(settings));
			if (type == typeof(Guid?))
				return CacheGenerator(cacheKey, new NullableGuidGenerator(settings));
			if ( type == typeof(long))
				return CacheGenerator(cacheKey, new LongGenerator(settings));
			if ( type == typeof(long?))
				return CacheGenerator(cacheKey, new NullableLongGenerator(settings));
			if ( IsCollection(type) )
			{
				CollectionGenerator generator = new CollectionGenerator(settings);
				generator.CollectionType = type;
				generator.CollectionItemType = GetEnumerableType(type);
				return CacheGenerator(cacheKey, generator);
			}
			if (type.IsClass && type != typeof(string))
			{
				InstanceGenerator generator = new InstanceGenerator(settings);
				generator.InstanceType = type;
				return CacheGenerator(cacheKey, generator);
			}

			return null;
		}

		private static IGenerator CacheGenerator(string cacheKey, IGenerator generator)
		{
			_generatorCache[cacheKey] = generator;
			return generator;
		}

		private static bool IsCollection(Type type)
		{
			if (type is IEnumerable)
				return true;
			if (type.IsGenericType)
			{
				if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
					return true;
				if (type.GetGenericTypeDefinition() == typeof(ICollection<>))
					return true;
				if (type.GetGenericTypeDefinition() == typeof(IList<>))
					return true;
				if (type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
					return true;
				if (type.GetGenericTypeDefinition() == typeof(Collection<>))
					return true;
				if (type.GetGenericTypeDefinition() == typeof(List<>))
					return true;
			}
			return false;
		}

		private static Type GetEnumerableType(Type type)
		{
			foreach (Type intType in type.GetInterfaces())
			{
				if (intType.IsGenericType
					&& intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
				{
					return intType.GetGenericArguments()[0];
				}
			}
			return null;
		}


	}
}
