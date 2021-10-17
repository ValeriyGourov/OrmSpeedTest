using System;

using Domain;

namespace UnitTestInfrastructure.EqualityComparers
{
	public sealed class MiniDesignerEqualityComparer : EqualityComparerBase<MiniDesigner>
	{
		public static MiniDesignerEqualityComparer Instance { get; } = new MiniDesignerEqualityComparer();

		public override Func<MiniDesigner, string?> EqualityProperty { get; } = item => item.Name;

	}
}
