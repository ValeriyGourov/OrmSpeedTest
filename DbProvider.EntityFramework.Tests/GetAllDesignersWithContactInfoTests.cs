using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.EntityFramework.Tests
{
	[TestClass()]
	public class GetAllDesignersWithContactInfoTests
	{
		[TestMethod]
		public Task Tracked() => TestsMethods.GetAllDesignersWithContactInfo(Queries.GetAllDesignersWithContactInfo.Tracked);

		[TestMethod]
		public Task NotTracked() => TestsMethods.GetAllDesignersWithContactInfo(Queries.GetAllDesignersWithContactInfo.NotTracked);

		//[TestMethod]
		//public Task ViaRawSqlTracked() => TestsMethods.GetAllDesignersWithContactInfo(Queries.GetAllDesignersWithContactInfo.ViaRawSqlTracked);

		//[TestMethod]
		//public Task ViaRawSqlNotTracked() => TestsMethods.GetAllDesignersWithContactInfo(Queries.GetAllDesignersWithContactInfo.ViaRawSqlNotTracked);
	}
}