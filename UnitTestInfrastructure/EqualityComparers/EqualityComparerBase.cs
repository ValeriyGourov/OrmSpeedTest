using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestInfrastructure.EqualityComparers
{
	public abstract class EqualityComparerBase<T> : EqualityComparer<T>
	{
		//public static  EqualityComparerBase Instance { get; } = new EqualityComparerBase();
		//public static EqualityComparerBase<T> Instance { get; }

		public abstract Func<T, string?> EqualityProperty { get; }
		//public Func<T, bool> Predicate { get; } = item => EqualityProperty(item) == EqualityProperty(expectedDesigner)

		public override bool Equals(T? object1, T? object2)
		{
			if (object1 == null
				&& object2 == null)
			{
				return true;
			}
			else if (object1 == null
				|| object2 == null)
			{
				return false;
			}

			return GetPredicate(object2)(object1);
			//return EqualityProperty(object1) == EqualityProperty(object2);
		}

		public override int GetHashCode([DisallowNull] T @object) => EqualityProperty(@object)?.GetHashCode() ?? default;

		public Func<T, bool> GetPredicate(T otherObject) => item => EqualityProperty(item) == EqualityProperty(otherObject);
	}
}
