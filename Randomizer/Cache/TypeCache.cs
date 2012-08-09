using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Randomizer.Generators;

namespace Randomizer.Cache
{
	internal static class TypeCache
	{
		private static readonly Dictionary<string, PropertyInfo[]> _propertyCache = new Dictionary<string, PropertyInfo[]>();

		internal static PropertyInfo[] GetMembers(Type type)
		{
			string cacheKey = type.ToString();
			
			if (_propertyCache.ContainsKey(cacheKey))
				return _propertyCache[cacheKey];
			
			PropertyInfo[] members = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			_propertyCache[cacheKey] = members;
			return members;
		}
	}
}
