using System;
using System.Linq;

namespace Randomizer.Generators
{
	internal class CharGenerator : GeneratorBase
	{
		public CharGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			char[] chars = "abcdefghijklmnopqrstuvxyzæøåABCDEFGHIJKLMNOPQRSTUVXYZÆØÅ".ToArray();

			return chars[Rnd.Next(0, chars.Length - 1)];
		}
	}
}
