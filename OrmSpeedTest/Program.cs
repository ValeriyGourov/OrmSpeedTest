#if !DEBUG
using System;
#endif
using System.Threading.Tasks;

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace OrmSpeedTest
{
	internal class Program
	{
		private static async Task Main(string[] args)
		{
			//await Host.CreateDefaultBuilder()
			//	.ConfigureAppConfiguration((hostingContext, config) =>
			//	{
			//		config.Sources.Clear();
			//		config
			//			//.AddJsonFile("appsettings.Development.json", false, true)
			//			.AddJsonFile("appsettings.json", false, true);
			//	})
			//	//.ConfigureWebHostDefaults(hostBuilder =>
			//	//{
			//	//	hostBuilder.UseEnvironment("Development");
			//	//	hostBuilder.UseStartup<Startup>();
			//	//})
			//	.ConfigureLogging(loggingBuilder =>
			//	{
			//		loggingBuilder.ClearProviders();
			//		loggingBuilder.AddDebug();
			//		loggingBuilder.AddConsole();
			//	})
			//	.UseConsoleLifetime()
			//	.RunConsoleAsync();




			//IConfiguration configuration = new ConfigurationBuilder()
			//	.AddJsonFile("appsettings.json", true, true)
			//	//.AddUserSecrets<Program>(true, true)
			//	//.AddCommandLine(args)
			//	.Build();
			//ConfigService.ConnectionString = configuration.GetConnectionString("Default");



#if !DEBUG
			await PrepareDB();
#endif

#if DEBUG
			DbProvider.LinqToDb.Initialization.Run();
#endif

			IConfig? config = null;
#if DEBUG
			config = new DebugInProcessConfig();
#endif
			BenchmarkSwitcher
				.FromAssembly(typeof(Program).Assembly)
				.Run(args, config);
		}

#if !DEBUG
		private static async Task PrepareDB()
		{
			bool recreate = false;

			if (await Database.Initialization.DatabaseExists())
			{
				Console.WriteLine("База данных уже существует. Создать её заново?");
				Console.Write("Yes (Y)/No (N): ");

				int seconds = 1;

				while (true)
				{
					if (Console.KeyAvailable)
					{
						ConsoleKeyInfo key = Console.ReadKey(true);
						if (key.Key == ConsoleKey.Y)
						{
							recreate = true;
							break;
						}
						if (key.Key == ConsoleKey.N)
						{
							break;
						}
					}

					await Task.Delay(1000);

					if (seconds++ > 5)
					{
						break;
					}

					Console.Write('.');
				}
			}

			Console.Clear();
			Console.WriteLine("Выполняется заполнение данных...");
			await Database.Initialization.CreateDatabase(recreate);

			Console.Clear();
		}
#endif
	}
}
