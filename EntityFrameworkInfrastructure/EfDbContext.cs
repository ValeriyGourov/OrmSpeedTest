
using System.Diagnostics;

using Configuration;

using Domain;

using Microsoft.EntityFrameworkCore;

namespace DbProvider.EntityFramework
{
	public class EfDbContext : DbContext
	{
		//private readonly string _connectionString;

		public DbSet<Designer> Designers { get; set; } = null!;
		public DbSet<Client> Clients { get; set; } = null!;
		public DbSet<ContactInfo> ContactInfos { get; set; } = null!;
		public DbSet<Product> Products { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//			optionsBuilder
			//				.EnableSensitiveDataLogging()
			//				.LogTo(sql => Debug.WriteLine(sql));
			//#if UNIT_TEST
			//			optionsBuilder.UseSqlite(ConfigService.ConnectionStrings.UnitTest);
			//#else
			//			optionsBuilder.UseSqlServer(ConfigService.ConnectionString);
			//#endif


			optionsBuilder
				.UseSqlServer(ConfigService.ConnectionString)
				.EnableSensitiveDataLogging()
				.LogTo(sql => Debug.WriteLine(sql));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Designer>()
				.HasOne(designer => designer.ContactInfo)
				.WithOne(contactInfo => contactInfo.Designer)
				.HasForeignKey<ContactInfo>(contactInfo => contactInfo.ContactInfoId);

			//modelBuilder.Entity<Designer>()
			//	.HasMany(designer => designer.Products)
			//	.WithOne()
			//	.HasForeignKey(product => product.DesignerId);

			//modelBuilder.Entity<Designer>()
			//	.HasMany(designer => designer.Clients)
			//	.WithMany(client => client.Designers);

			//modelBuilder.Entity<Client>()
			//	.HasMany(client => client.Designers)
			//	.WithMany(designer => designer.Clients);

			base.OnModelCreating(modelBuilder);
		}
	}
}
