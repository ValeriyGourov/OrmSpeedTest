using System;

using Domain;

namespace UnitTestInfrastructure.EqualityComparers
{
	public sealed class ProductEqualityComparer : EqualityComparerBase<Product>/*, IEqualityPropertyComparer<Product>*/
	{
		public static ProductEqualityComparer Instance { get; } = new ProductEqualityComparer();

		public override Func<Product, string?> EqualityProperty { get; } = item => item.Description;
	}
}
