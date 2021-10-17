using System;

using Domain;

namespace UnitTestInfrastructure.EqualityComparers
{
	public sealed class DesignerEqualityComparer : EqualityComparerBase<Designer>/*, IEqualityPropertyComparer<Designer>*/
	{
		public static DesignerEqualityComparer Instance { get; } = new DesignerEqualityComparer();

		public override Func<Designer, string?> EqualityProperty { get; } = item => item.LabelName;

	}
}
