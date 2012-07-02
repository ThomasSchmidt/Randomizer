using System;

namespace Randomizer.Generators
{
	class NullableIntGenerator : GeneratorBase
	{
		public NullableIntGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			if ( ShouldCreateNullValue )
				return null;
			return Rnd.Next(0, int.MaxValue);
		}
	}
}
