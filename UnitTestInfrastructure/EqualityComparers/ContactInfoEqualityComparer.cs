using System;

using Domain;

namespace UnitTestInfrastructure.EqualityComparers
{
	public sealed class ContactInfoEqualityComparer : EqualityComparerBase<ContactInfo>
	{
		public static ContactInfoEqualityComparer Instance { get; } = new ContactInfoEqualityComparer();

		public override Func<ContactInfo, string?> EqualityProperty { get; } = item => item.Twitter;

	}
}
