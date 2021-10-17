using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.LinqToDb.Tests
{
	[TestClass]
	public class GetProjectedDesignersTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetProjectedDesigners(Queries.GetProjectedDesigners.Execute);
	}
}