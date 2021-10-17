using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetAllDesignersWithClientsTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetAllDesignersWithClients(Queries.GetAllDesignersWithClients.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetAllDesignersWithClients(Queries.GetAllDesignersWithClients.NotTracked);
	}
}