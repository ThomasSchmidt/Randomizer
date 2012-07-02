using System;
using System.Collections.Generic;

namespace Randomizer.Generators
{
	internal abstract class GeneratorBase : IGenerator
	{
		private readonly ISettings _settings;
		private static readonly Random _random = new Random(DateTime.Now.Millisecond);

		protected GeneratorBase(ISettings settings)
		{
			_settings = settings;
		}

		protected ISettings Settings
		{
			get { return _settings; }
		}

		protected Random Rnd
		{
			get { return _random; }
		}

		protected bool ShouldCreateNullValue
		{
			get 
			{
				if (!_settings.AllowNulls)
					return false;
				int hit = Rnd.Next(0, _settings.NullPercentage);
				return hit <= _settings.NullPercentage;
			}
		}

		public abstract object Create();

		public virtual IEnumerable<object> AdditionalObjectsToRandomize 
		{ 
			get
			{
				return new object[]{};
			}
		}
	}
}
