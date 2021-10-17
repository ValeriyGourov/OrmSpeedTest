using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetAllDesignersWithProductsTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetAllDesignersWithProducts(Queries.GetAllDesignersWithProducts.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetAllDesignersWithProducts(Queries.GetAllDesignersWithProducts.NotTracked);

		//[TestMethod]
		//public Task ViaRawSqlTracked() => TestsMethods.GetAllDesignersWithProducts(Queries.GetAllDesignersWithProducts.ViaRawSqlTracked);

		//[TestMethod]
		//public Task ViaRawSqlNotTracked() => TestsMethods.GetAllDesignersWithProducts(Queries.GetAllDesignersWithProducts.ViaRawSqlNotTracked);
	}
}