using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Randomizer.Generators
{
	internal class InstanceGenerator : GeneratorBase
	{
		private object _random;

		public InstanceGenerator(ISettings settings) : base(settings)
		{
		}

		public Type InstanceType { get; set; }

		public override object Create()
		{
			_random = Activator.CreateInstance(InstanceType);
			return _random;
		}

		public override IEnumerable<object> AdditionalObjectsToRandomize
		{
			get
			{
				Collection<object> objects = new Collection<object>();
				objects.Add(_random);
				return objects;
			}
		}
	}
}
