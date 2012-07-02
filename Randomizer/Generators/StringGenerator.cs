using System;
using System.Linq;
using System.Text;

namespace Randomizer.Generators
{
	internal class StringGenerator : GeneratorBase
	{
		public StringGenerator(ISettings settings) : base(settings)
		{
		}

		public override object Create()
		{
			char[] chars = "abcdefghijklmnopqrstuvxyzæøåABCDEFGHIJKLMNOPQRSTUVXYZÆØÅ".ToArray();

			if ( ShouldCreateNullValue )
			{
				return null;
			}

			int calculatedLength = Rnd.Next(Settings.MinStringLength, Settings.MaxStringLength);
			int cl = chars.Length - 1;

			StringBuilder sb = new StringBuilder(calculatedLength);
			for (int i = 0; i < calculatedLength; i++)
			{
				sb.Append(chars[Rnd.Next(0, cl)]);
			}
			return sb.ToString();
		}
	}
}
