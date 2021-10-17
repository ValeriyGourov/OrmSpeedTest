using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetFilteredDesignersTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetFilteredDesigners(Queries.GetFilteredDesigners.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetFilteredDesigners(Queries.GetFilteredDesigners.NotTracked);
	}
}