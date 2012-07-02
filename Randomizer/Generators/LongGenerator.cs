using System;

namespace Randomizer.Generators
{
	internal class LongGenerator : GeneratorBase
	{
		public LongGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			return (long)Rnd.Next(0, int.MaxValue);
		}
	}
}
