using System.Threading.Tasks;

using DbProvider.EntityFramework;

namespace Database
{
	public static class Initialization
	{
		public static async Task<bool> DatabaseExists()
		{
			using EfDbContext dbContext = new();
			return await dbContext.Database.CanConnectAsync();
		}

		public static async Task CreateDatabase(bool recreate)
		{
			using EfDbContext dbContext = new();

			if (recreate)
			{
				await dbContext.Database.EnsureDeletedAsync();
			}
			await dbContext.Database.EnsureCreatedAsync();
			if (recreate)
			{
				await SeedData(dbContext);
			}
		}

		private static async Task SeedData(EfDbContext dbContext)
		{
			await dbContext.Clients.AddRangeAsync(TestData.Clients);
			await dbContext.ContactInfos.AddRangeAsync(TestData.ContactInfos);
			await dbContext.Products.AddRangeAsync(TestData.Products);
			await dbContext.Designers.AddRangeAsync(TestData.Designers);
			await dbContext.Designers.AddRangeAsync(TestData.UnnamedDesigners);

			await dbContext.SaveChangesAsync();
		}
	}
}
