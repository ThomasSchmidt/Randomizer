using System;

namespace Randomizer.Generators
{
	internal class NullableLongGenerator : GeneratorBase
	{
		public NullableLongGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			if (ShouldCreateNullValue)
				return null;

			return (long)Rnd.Next(0, int.MaxValue);
		}
	}
}
