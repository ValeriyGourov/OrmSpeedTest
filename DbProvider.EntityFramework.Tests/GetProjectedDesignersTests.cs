using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetProjectedDesignersTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetProjectedDesigners(Queries.GetProjectedDesigners.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetProjectedDesigners(Queries.GetProjectedDesigners.NotTracked);
	}
}