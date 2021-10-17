using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using DapperProvider = DbProvider.Dapper.Queries.GetAllDesignersWithContactInfo;
using EntityFrameworkProvider = DbProvider.EntityFramework.Queries.GetAllDesignersWithContactInfo;
using LinqToDbProvider = DbProvider.LinqToDb.Queries.GetAllDesignersWithContactInfo;

namespace OrmSpeedTest.Benchmarks
{
	public class GetAllDesignersWithContactInfo : BenchmarkBase
	{
		[Benchmark(Baseline = true, Description = _dapperDescription)]
		public Task Dapper() => DapperProvider.Execute();

		[Benchmark(Description = _linqToDbDescription)]
		public Task LinqToDb() => LinqToDbProvider.Execute();

		[Benchmark(Description = _efTrackedDescription)]
		public Task EF_Tracked() => EntityFrameworkProvider.Tracked();

		[Benchmark(Description = _efNotTrackedDescription)]
		public Task EF_NotTracked() => EntityFrameworkProvider.NotTracked();

		//[Benchmark(Description = _efRawSqlTrackedDescription)]
		//public Task EF_ViaRawSqlTracked() => EntityFrameworkProvider.ViaRawSqlTracked();

		//[Benchmark(Description = _efRawSqlNotTrackedDescription)]
		//public Task EF_ViaRawSqlNotTracked() => EntityFrameworkProvider.ViaRawSqlNotTracked();
	}
}
