using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Randomizer.Tests
{
	internal class TestDummy
	{
		public string StringProperty1 { get; set; }
		public char CharProperty1 { get; set; }
		public char? NullableCharProperty1 { get; set; }
		public int IntProperty1 { get; set; }
		public int? NullableIntProperty1 { get; set; }
		public Guid GuidProperty1 { get; set; }
		public Guid? NullableGuidProperty1 { get; set; }
		public long LongProperty1 { get; set; }
		public long? NullableLongProperty1 { get; set; }
		public SubTestDummy SubTestDummyProperty1 { get; set; }
		public ICollection<SubTestDummy> SubTestICollection1 { get; set; }
		public IList<SubTestDummy> SubTestIList1 { get; set; }
		public Collection<SubTestDummy> SubTestCollection1 { get; set; }
		public List<SubTestDummy> SubTestList1 { get; set; } //fails
	}

	internal class SubTestDummy
	{
		public string SubStringProperty1 { get; set; }
		public string SubStringProperty2 { get; set; }
		public int SubIntProperty1 { get; set; }
		public TestDummy ParentTestDummyProperty1 { get; set; }
	}
}
