using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using DapperProvider = DbProvider.Dapper.Queries.GetFilteredDesigners;
using EntityFrameworkProvider = DbProvider.EntityFramework.Queries.GetFilteredDesigners;
using LinqToDbProvider = DbProvider.LinqToDb.Queries.GetFilteredDesigners;

namespace OrmSpeedTest.Benchmarks
{
	public class GetFilteredDesigners : BenchmarkBase
	{
		[Benchmark(Baseline = true, Description = _dapperDescription)]
		public Task Dapper() => DapperProvider.Execute();

		[Benchmark(Description = _linqToDbDescription)]
		public Task LinqToDb() => LinqToDbProvider.Execute();

		[Benchmark(Description = _efTrackedDescription)]
		public Task EF_Tracked() => EntityFrameworkProvider.Tracked();

		[Benchmark(Description = _efNotTrackedDescription)]
		public Task EF_NotTracked() => EntityFrameworkProvider.NotTracked();
	}
}
