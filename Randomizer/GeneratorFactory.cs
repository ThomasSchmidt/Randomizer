using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Randomizer.Generators;

namespace Randomizer
{
	internal static class GeneratorFactory
	{
		internal static IGenerator Create(Type type, ISettings settings)
		{
			if ( type == typeof(int))
				return new IntGenerator(settings);
			if ( type == typeof(int?))
				return new NullableIntGenerator(settings);
			if ( type == typeof(string))
				return new StringGenerator(settings);
			if ( type == typeof(char))
				return new CharGenerator(settings);
			if (type == typeof(char?))
				return new NullableCharGenerator(settings);
			if ( type == typeof(Guid))
				return new GuidGenerator(settings);
			if (type == typeof(Guid?))
				return new NullableGuidGenerator(settings);
			if ( type == typeof(long))
				return new LongGenerator(settings);
			if ( type == typeof(long?))
				return new NullableLongGenerator(settings);
			if ( IsCollection(type) )
			{
				CollectionGenerator generator = new CollectionGenerator(settings);
				generator.CollectionType = type;
				generator.CollectionItemType = GetEnumerableType(type);
				return generator;
			}
			if (type.IsClass && type != typeof(string))
			{
				InstanceGenerator generator = new InstanceGenerator(settings);
				generator.InstanceType = type;
				return generator;
			}

			return null;
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
