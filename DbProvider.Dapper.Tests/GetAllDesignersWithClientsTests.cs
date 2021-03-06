using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.Dapper.Tests
{
	[TestClass]
	public class GetAllDesignersWithClientsTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetAllDesignersWithClients(Queries.GetAllDesignersWithClients.Execute);
	}
}