using System.Collections.Generic;
using System.Linq;

using Microsoft.Toolkit.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure.EqualityComparers;

namespace UnitTestInfrastructure.Extentions
{
	/// <summary>
	/// Расширения функционала класса <see cref="CollectionAssert"/>.
	/// </summary>
	public static class CollectionAssertExtentions
	{
		public static void AreEquivalent<T>(
			this CollectionAssert collectionAssert,
			ICollection<T> expected,
			ICollection<T> actual,
			EqualityComparerBase<T> comparer,
			//IEqualityPropertyComparer<T> comparer,
			string? message = null)
		{
			Guard.IsNotNull(collectionAssert, nameof(collectionAssert));
			Guard.IsNotNull(expected, nameof(expected));
			Guard.IsNotNull(actual, nameof(actual));
			Guard.IsNotNull(comparer, nameof(comparer));

			IOrderedEnumerable<T> expectedOrdered = expected.OrderBy(comparer.EqualityProperty);
			IOrderedEnumerable<T> actualOrdered = actual.OrderBy(comparer.EqualityProperty);

			if (!Enumerable.SequenceEqual(expectedOrdered, actualOrdered, comparer))
			{
				throw new AssertFailedException(string.IsNullOrWhiteSpace(message)
					? "Коллекции не эквивалентны: количество или состав элементов не совпадает."
					: message);
			}
		}
	}
}
