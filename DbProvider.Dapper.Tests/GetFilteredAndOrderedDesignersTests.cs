using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.Dapper.Tests
{
	[TestClass]
	public class GetFilteredAndOrderedDesignersTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetFilteredAndOrderedDesigners(Queries.GetFilteredAndOrderedDesigners.Execute);
	}
}