using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.LinqToDb.Tests
{
	[TestClass]
	public class GetAllDesignersWithClientsTests
	{
		[TestMethod]
		public Task OneQuery() => TestsMethods.GetAllDesignersWithClients(Queries.GetAllDesignersWithClients.OneQuery);

		[TestMethod]
		public Task ManualClientFilling() => TestsMethods.GetAllDesignersWithClients(Queries.GetAllDesignersWithClients.ManualFilling);
	}
}