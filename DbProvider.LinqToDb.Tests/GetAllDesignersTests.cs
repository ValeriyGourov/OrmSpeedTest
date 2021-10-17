using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestInfrastructure;

namespace DbProvider.LinqToDb.Tests
{
	[TestClass]
	public class GetAllDesignersTests
	{
		[TestMethod]
		public Task Execute() => TestsMethods.GetAllDesigners(Queries.GetAllDesigners.Execute);
	}
}