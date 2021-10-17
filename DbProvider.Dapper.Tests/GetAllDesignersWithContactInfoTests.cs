using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.Dapper.Tests
{
	[TestClass]
	public class GetAllDesignersWithContactInfoTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetAllDesignersWithContactInfo(Queries.GetAllDesignersWithContactInfo.Execute);
	}
}