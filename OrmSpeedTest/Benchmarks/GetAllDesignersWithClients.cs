using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using DapperProvider = DbProvider.Dapper.Queries.GetAllDesignersWithClients;
using EntityFrameworkProvider = DbProvider.EntityFramework.Queries.GetAllDesignersWithClients;
using LinqToDbProvider = DbProvider.LinqToDb.Queries.GetAllDesignersWithClients;

namespace OrmSpeedTest.Benchmarks
{
	public class GetAllDesignersWithClients : BenchmarkBase
	{
		[Benchmark(Baseline = true, Description = _dapperDescription)]
		public Task Dapper() => DapperProvider.Execute();

		[Benchmark(Description = _linqToDbDescription + ", one query")]
		public Task LinqToDb_OneQuery() => LinqToDbProvider.OneQuery();

		[Benchmark(Description = _linqToDbDescription + ", manual filling")]
		public Task LinqToDb_ManualFilling() => LinqToDbProvider.ManualFilling();

		[Benchmark(Description = _efTrackedDescription)]
		public Task EF_Tracked() => EntityFrameworkProvider.Tracked();

		[Benchmark(Description = _efNotTrackedDescription)]
		public Task EF_NotTracked() => EntityFrameworkProvider.NotTracked();
	}
}
