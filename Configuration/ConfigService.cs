namespace Configuration
{
	public static class ConfigService
	{
		public static string ConnectionString => @"Server=(localdb)\MSSQLLocalDB;Database=OrmSpeedTest";

		public static class ConnectionStrings
		{
			public static string UnitTest => ":memory:";

		}
	}
}
//using System;

//namespace Configuration
//{
//	public static class ConfigService
//	{
//		private static string _connectionString;

//		//Lazy<DbContextOptions<BenchmarkContext>> _contextOptions = new Lazy<DbContextOptions<BenchmarkContext>>(() =>
//		//{
//		//	DbContextOptions<BenchmarkContext> contextOptions = new DbContextOptionsBuilder<BenchmarkContext>()
//		//		.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
//		//		.Options;

//		//	return contextOptions;
//		//});

//		//public DbContextOptions<BenchmarkContext> ContextOptions => _contextOptions.Value;

//		public static string ConnectionString
//		{
//			get => string.IsNullOrWhiteSpace(_connectionString)
//				? throw new InvalidOperationException("Не задана строка подключения.")
//				: _connectionString;
//			set => _connectionString = value;
//		}
//	}
//}
