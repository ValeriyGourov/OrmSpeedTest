using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.Dapper.Tests
{
	[TestClass]
	public class GetAllDesignersWithProductsTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetAllDesignersWithProducts(Queries.GetAllDesignersWithProducts.Execute);
	}
}