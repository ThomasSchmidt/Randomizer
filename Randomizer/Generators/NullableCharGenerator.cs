using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer.Generators
{
	internal class NullableCharGenerator : GeneratorBase
	{
		public NullableCharGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			char[] chars = "abcdefghijklmnopqrstuvxyzæøåABCDEFGHIJKLMNOPQRSTUVXYZÆØÅ".ToArray();

			if (ShouldCreateNullValue)
				return null;

			return chars[Rnd.Next(0, chars.Length - 1)];
		}
	}
}
