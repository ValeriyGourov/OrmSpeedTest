using System.Linq;
using System.Threading.Tasks;

using Domain;
using Domain.Enums;

using Microsoft.EntityFrameworkCore;

namespace DbProvider.EntityFramework
{
	public static class Queries
	{
		public static class GetAllDesigners
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.AsNoTracking()
					.ToArrayAsync();
			}

			//public static async Task<Designer[]> ViaRawSqlTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		.ToArrayAsync();
			//}

			//public static async Task<Designer[]> ViaRawSqlNotTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		.AsNoTracking()
			//		.ToArrayAsync();
			//}
		}

		public static class GetAllDesignersWithProducts
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.Products)
					.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.Products)
					.AsNoTracking()
					.ToArrayAsync();
			}

			//public static async Task<Designer[]> ViaRawSqlTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		//.FromSqlRaw(CommonSqlQueries.AllDesignersWithProducts)
			//		.Include(designer => designer.Products)
			//		.ToArrayAsync();
			//}

			//public static async Task<Designer[]> ViaRawSqlNotTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		//.FromSqlRaw(CommonSqlQueries.AllDesignersWithProducts)
			//		.Include(designer => designer.Products)
			//		.AsNoTracking()
			//		.ToArrayAsync();
			//}
		}

		public static class GetAllDesignersWithContactInfo
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.ContactInfo)
					.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.ContactInfo)
					.AsNoTracking()
					.ToArrayAsync();
			}

			//public static async Task<Designer[]> ViaRawSqlTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		//.FromSqlRaw(CommonSqlQueries.AllDesignersWithContactInfo)
			//		.Include(designer => designer.ContactInfo)
			//		.ToArrayAsync();
			//}

			//public static async Task<Designer[]> ViaRawSqlNotTracked()
			//{
			//	using EfDbContext dbContext = new();
			//	return await dbContext.Designers
			//		.FromSqlRaw(CommonSqlQueries.AllDesigners)
			//		//.FromSqlRaw(CommonSqlQueries.AllDesignersWithContactInfo)
			//		.Include(designer => designer.ContactInfo)
			//		.AsNoTracking()
			//		.ToArrayAsync();
			//}
		}

		public static class GetAllDesignersWithClients
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.Clients)
					.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Include(designer => designer.Clients)
					.AsNoTracking()
					.ToArrayAsync();
			}
		}

		public static class GetProjectedDesigners
		{
			public static async Task<MiniDesigner[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Select(item => new MiniDesigner
					{
						Id = item.Id,
						Name = item.LabelName,
						FoundedBy = item.Founder
					})
					.ToArrayAsync();
			}

			public static async Task<MiniDesigner[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Select(item => new MiniDesigner
					{
						Id = item.Id,
						Name = item.LabelName,
						FoundedBy = item.Founder
					})
					.AsNoTracking()
					.ToArrayAsync();
			}
		}

		public static class GetFilteredDesigners
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Where(designer => designer.Dapperness == Dapperness.PrettyDapper)
					.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Where(designer => designer.Dapperness == Dapperness.PrettyDapper)
					.AsNoTracking()
					.ToArrayAsync();
			}
		}

		public static class GetFilteredAndOrderedDesigners
		{
			public static async Task<Designer[]> Tracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Where(designer => designer.Dapperness == Dapperness.KindaDapper)
					.OrderBy(designer => designer.LabelName)
					.ToArrayAsync();
			}

			public static async Task<Designer[]> NotTracked()
			{
				using EfDbContext dbContext = new();
				return await dbContext.Designers
					.Where(designer => designer.Dapperness == Dapperness.KindaDapper)
					.OrderBy(designer => designer.LabelName)
					.AsNoTracking()
					.ToArrayAsync();
			}
		}
	}
}
