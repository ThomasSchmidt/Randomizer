using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer
{
	public interface ISettings
	{
		void Validate();
		int MaxDepth { get; set; }
		bool AllowNulls { get; set; }
		bool AllowNullCollections { get; set; }
		int NullPercentage { get; set; }
		int MinStringLength { get; set; }
		int MaxStringLength { get; set; }
		int MaxCollectionCount { get; set; }
	}
}
