using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.LinqToDb.Tests
{
	[TestClass]
	public class GetFilteredDesignersTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetFilteredDesigners(Queries.GetFilteredDesigners.Execute);
	}
}