using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbProvider.LinqToDb.Tests
{
	[TestClass]
	public sealed class TestAssemblyInitialize
	{
		[AssemblyInitialize]
		public static void Initialize(TestContext context)
		{
			Initialization.Run();
		}
	}
}
