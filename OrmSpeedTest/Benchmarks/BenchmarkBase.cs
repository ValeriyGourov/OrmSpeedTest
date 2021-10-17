using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
#if !DEBUG
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
#endif

namespace OrmSpeedTest.Benchmarks
{
	[Config(typeof(Config))]
	public abstract class BenchmarkBase
	{
		private class Config : ManualConfig
		{
			public Config()
			{
#if !DEBUG
				AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));
#endif
			}
		}

		protected const string _dapperDescription = "Dapper";
		protected const string _linqToDbDescription = "LINQ to DB";
		protected const string _efTrackedDescription = "EF, tracked";
		protected const string _efNotTrackedDescription = "EF, not tracked";
		//protected const string _efRawSqlTrackedDescription = "EF, Raw SQL, tracked";
		//protected const string _efRawSqlNotTrackedDescription = "EF, Raw SQL, not tracked";
	}
}
