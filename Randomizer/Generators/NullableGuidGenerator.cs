using System;

namespace Randomizer.Generators
{
	internal class NullableGuidGenerator : GeneratorBase
	{
		public NullableGuidGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			if ( ShouldCreateNullValue )
				return null;
			return Guid.NewGuid();
		}
	}
}
