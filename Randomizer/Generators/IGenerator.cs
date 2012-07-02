using System;
using System.Collections.Generic;

namespace Randomizer.Generators
{
	interface IGenerator
	{
		object Create();
		IEnumerable<object> AdditionalObjectsToRandomize { get; }
	}
}
