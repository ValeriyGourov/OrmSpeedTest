using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass]
	public class GetAllDesignersTests
	{
		//[ClassInitialize]
		//public static void ClassInit(TestContext context)
		//{
		//	// TODO: Инициализировать новый экземпляр БД в памяти.
		//}

		[TestMethod]
		public Task Tracked() => TestsMethods.GetAllDesigners(Queries.GetAllDesigners.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetAllDesigners(Queries.GetAllDesigners.NotTracked);

		//[TestMethod]
		//public Task ViaRawSqlTracked() => TestsMethods.GetAllDesigners(Queries.GetAllDesigners.ViaRawSqlTracked);

		//[TestMethod]
		//public Task ViaRawSqlNotTracked() => TestsMethods.GetAllDesigners(Queries.GetAllDesigners.ViaRawSqlNotTracked);
	}
}