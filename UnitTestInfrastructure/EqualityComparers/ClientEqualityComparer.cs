using System;

using Domain;

namespace UnitTestInfrastructure.EqualityComparers
{
	public sealed class ClientEqualityComparer : EqualityComparerBase<Client>
	{
		public static ClientEqualityComparer Instance { get; } = new ClientEqualityComparer();

		public override Func<Client, string?> EqualityProperty { get; } = item => item.Name;

	}
}
