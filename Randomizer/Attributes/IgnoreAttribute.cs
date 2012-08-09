using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomizer.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
	public class IgnoreAttribute : Attribute
	{
	}
}
