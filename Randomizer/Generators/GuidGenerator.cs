using System;

namespace Randomizer.Generators
{
	internal class GuidGenerator : GeneratorBase
	{
		public GuidGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			return Guid.NewGuid();
		}
	}
}
