using System;

namespace Randomizer.Generators
{
	internal class IntGenerator : GeneratorBase
	{
		public IntGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			return Rnd.Next(0, int.MaxValue);
		}
	}
}
