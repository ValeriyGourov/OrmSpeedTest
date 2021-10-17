using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetFilteredAndOrderedDesignersTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetFilteredAndOrderedDesigners(Queries.GetFilteredAndOrderedDesigners.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetFilteredAndOrderedDesigners(Queries.GetFilteredAndOrderedDesigners.NotTracked);
	}
}