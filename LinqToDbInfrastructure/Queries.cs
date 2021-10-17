using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain;
using Domain.Enums;

using LinqToDB;

namespace DbProvider.LinqToDb
{
	public static class Queries
	{
		public static class GetAllDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();
				return await dbConnection.Designers.ToArrayAsync();
			}
		}

		public static class GetAllDesignersWithProducts
		{
			public static async Task<Designer[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();

				IQueryable<Designer> query =
					from designer in dbConnection.Designers
					join product in dbConnection.Products
						on designer.Id equals product.DesignerId
						into products
					select designer.Buid(products);

				return await query.ToArrayAsync();
			}
		}

		public static class GetAllDesignersWithContactInfo
		{
			public static async Task<Designer[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();

				IQueryable<Designer> query =
					from designer in dbConnection.Designers
					from contactInfo in dbConnection.ContactInfos.LeftJoin(contactInfoItem => contactInfoItem.ContactInfoId == designer.Id)
					select designer.Buid(contactInfo);

				return await query.ToArrayAsync();
			}
		}

		public static class GetAllDesignersWithClients
		{
			public static async Task<Designer[]> OneQuery()
			{
				using LinqToDbDataConnection dbConnection = new();

				IQueryable<Designer> query =
					from designer in dbConnection.Designers
					select designer.Buid(
						from client in dbConnection.Clients
						join clientDesigner in dbConnection.ClientDesigner
							on client.ClientId equals clientDesigner.ClientsClientId
						where clientDesigner.DesignersId == designer.Id
						select client
						);

				return await query.ToArrayAsync();
			}

			public static async Task<Designer[]> ManualFilling()
			{
				using LinqToDbDataConnection dbConnection = new();

				var query =
					from designer in dbConnection.Designers
					from clientDesigner in dbConnection.ClientDesigner.LeftJoin(clientDesigner => clientDesigner.DesignersId == designer.Id)
					from client in dbConnection.Clients.LeftJoin(client => client.ClientId == clientDesigner.ClientsClientId)
					select new
					{
						designer,
						client
					};

				Dictionary<int, Designer> designers = new();
				Dictionary<int, Client> clients = new();

				foreach (var item in query)
				{
					Designer designer = item.designer;
					Client client = item.client;

					if (!designers.TryGetValue(designer.Id, out Designer? localDesigner))
					{
						designers.Add(designer.Id, localDesigner = designer);
					}

					if (client is not null)
					{
						if (!clients.TryGetValue(client.ClientId, out Client? localClient))
						{
							clients.Add(client.ClientId, localClient = client);
						}

						localClient.Designers.Add(designer);
						localDesigner.Clients.Add(client);
					}
				}

				return designers.Values.ToArray();
			}
		}

		public static class GetProjectedDesigners
		{
			public static async Task<MiniDesigner[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();
				return await dbConnection.Designers
					.Select(item => new MiniDesigner
					{
						Id = item.Id,
						Name = item.LabelName,
						FoundedBy = item.Founder
					})
					.ToArrayAsync();
			}
		}

		public static class GetFilteredDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();
				return await dbConnection.Designers
					.Where(designer => designer.Dapperness == Dapperness.PrettyDapper)
					.ToArrayAsync();
			}
		}

		public static class GetFilteredAndOrderedDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				using LinqToDbDataConnection dbConnection = new();
				return await dbConnection.Designers
					.Where(designer => designer.Dapperness == Dapperness.KindaDapper)
					.OrderBy(designer => designer.LabelName)
					.ToArrayAsync();
			}
		}
	}
}
