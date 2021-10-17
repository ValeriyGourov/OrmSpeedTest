using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using DapperProvider = DbProvider.Dapper.Queries.GetFilteredAndOrderedDesigners;
using EntityFrameworkProvider = DbProvider.EntityFramework.Queries.GetFilteredAndOrderedDesigners;
using LinqToDbProvider = DbProvider.LinqToDb.Queries.GetFilteredAndOrderedDesigners;

namespace OrmSpeedTest.Benchmarks
{
	public class GetFilteredAndOrderedDesigners : BenchmarkBase
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
