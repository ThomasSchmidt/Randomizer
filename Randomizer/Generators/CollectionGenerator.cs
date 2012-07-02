using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Randomizer.Generators
{
	internal class CollectionGenerator : GeneratorBase
	{
		private IList<object> _additionalObjects;

		public CollectionGenerator(ISettings settings) : base(settings)
		{
		}

		public Type CollectionType { get; set; }
		public Type CollectionItemType { get; set; }

		public override object Create()
		{
			_additionalObjects = new List<object>();

			Type listType = null;
			if (CollectionType.GetGenericTypeDefinition() == typeof(IList<>) || CollectionType.GetGenericTypeDefinition() == typeof(List<>))
				listType = typeof(List<>).MakeGenericType(CollectionItemType);
			if ( CollectionType.GetGenericTypeDefinition() == typeof(ICollection<>) || CollectionType.GetGenericTypeDefinition() == typeof(Collection<>))
				listType = typeof(Collection<>).MakeGenericType(CollectionItemType);
			if (listType == null)
				return null;
			object newRandomList = Activator.CreateInstance(listType);

			//calculate the amount of items to add and add via reflection
			int creationCount = Rnd.Next(0, Settings.MaxCollectionCount);
			for (int i = 0; i < creationCount; i++)
			{
				object newRandomListItem = Activator.CreateInstance(CollectionItemType);
				_additionalObjects.Add(newRandomListItem);
				newRandomList.GetType().GetMethod("Add").Invoke(newRandomList, new object[] { newRandomListItem });
			}
			return newRandomList;
		}

		public override IEnumerable<object> AdditionalObjectsToRandomize
		{
			get
			{
				return _additionalObjects;
			}
		}
	}
}
