using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer
{
	public class Settings : ISettings
	{
		public static ISettings Default()
		{
			return new Settings
			{
				AllowNulls = false,
				MaxCollectionCount = 10,
				MaxStringLength = 50,
				MinStringLength = 2,
				RandomizePrivateFields = false,
				RandomizeProctedProperties = false,
				NullPercentage = 10,
				MaxDepth = 10,
			};
		}

		public void Validate()
		{
			if (this.MinStringLength > this.MaxStringLength)
				this.MinStringLength = this.MaxStringLength;
			if (this.MinStringLength < 0)
				this.MinStringLength = 0;
			if (this.MaxStringLength < 0)
				this.MaxStringLength = Default().MaxStringLength;
			if (this.NullPercentage < 0 || this.NullPercentage > 100)
				this.NullPercentage = Default().NullPercentage;
		}

		public int MaxDepth { get; set; }
		public bool AllowNulls { get; set; }
		public bool AllowNullCollections { get; set; }
		public int NullPercentage { get; set; }
		public int MinStringLength { get; set; }
		public int MaxStringLength { get; set; }
		public int MaxCollectionCount { get; set; }
		public bool RandomizePrivateFields { get; set; }
		public bool RandomizeProctedProperties { get; set; }
	}
}
