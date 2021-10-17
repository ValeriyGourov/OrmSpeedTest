using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using Domain;

using Microsoft.Data.SqlClient;

namespace DbProvider.Dapper
{
	public static class Queries
	{
		public static class GetAllDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = "select * from Designers";

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				return (await sqlConnection
					.QueryAsync<Designer>(sql))
					.ToArray();
			}
		}

		public static class GetAllDesignersWithProducts
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = @"
					select *
					from Designers
						left join Products
							on Products.DesignerId = Designers.Id
					";

				Dictionary<int, Designer> lookup = new();

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				await sqlConnection.QueryAsync<Designer, Product, Designer>(
					sql,
					(designer, product) =>
					{
						if (!lookup.TryGetValue(designer.Id, out Designer? localDesigner))
						{
							lookup.Add(designer.Id, localDesigner = designer);
						}

						if (product is not null)
						{
							localDesigner.Products.Add(product);
						}
						return localDesigner;
					},
					splitOn: nameof(Product.ProductId));

				return lookup.Values.ToArray();
			}
		}

		public static class GetAllDesignersWithContactInfo
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = @"
					select *
					from Designers
						left join ContactInfos
							on ContactInfos.ContactInfoId = Designers.Id
					";

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				return (await sqlConnection.QueryAsync<Designer, ContactInfo, Designer>(
					sql,
					(designer, contactInfo) =>
					{
						contactInfo.Designer = designer;
						designer.ContactInfo = contactInfo;

						return designer;
					},
					splitOn: nameof(ContactInfo.ContactInfoId)))
					.ToArray();
			}
		}

		public static class GetAllDesignersWithClients
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = @"
					select
						Designers.Id,
						Designers.LabelName,
						Clients.ClientId,
						Clients.Name
					from Designers
						left join ClientDesigner
							on ClientDesigner.DesignersId = Designers.Id
								left join Clients
									on Clients.ClientId = ClientDesigner.ClientsClientId
					";

				Dictionary<int, Designer> designers = new();

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				await sqlConnection.QueryAsync<Designer, Client, Designer>(
					sql,
					(designer, client) =>
					{
						if (!designers.TryGetValue(designer.Id, out Designer? localDesigner))
						{
							designers.Add(designer.Id, localDesigner = designer);
						}

						if (client is not null)
						{
							client.Designers.Add(designer);
							localDesigner.Clients.Add(client);
						}
						return localDesigner;
					},
					splitOn: nameof(Client.ClientId));

				return designers.Values.ToArray();



				//Dictionary<int, Designer> designers = new();
				//Dictionary<int, Client> clients = new();

				//using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				//await sqlConnection.QueryAsync<Designer, Client, Designer>(
				//	CommonSqlQueries.AllDesignersWithClients,
				//	(designer, client) =>
				//	{
				//		if (!designers.TryGetValue(designer.Id, out Designer? localDesigner))
				//		{
				//			designers.Add(designer.Id, localDesigner = designer);
				//		}

				//		if (client is not null)
				//		{
				//			if (!clients.TryGetValue(client.ClientId, out Client? localClient))
				//			{
				//				clients.Add(client.ClientId, localClient = client);
				//			}

				//			localClient.Designers.Add(designer);
				//			localDesigner.Clients.Add(client);
				//		}
				//		return localDesigner;
				//	},
				//	splitOn: nameof(Client.ClientId));

				//return designers.Values.ToArray();
			}
		}

		public static class GetProjectedDesigners
		{
			public static async Task<MiniDesigner[]> Execute()
			{
				const string sql = @"
					select
						Id,
						LabelName as Name,
						Founder as FoundedBy
					from Designers
					";

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				return (await sqlConnection
					.QueryAsync<MiniDesigner>(sql))
					.ToArray();
			}
		}

		public static class GetFilteredDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = @"
					select *
					from Designers
					where Dapperness = 2
					";

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				return (await sqlConnection
					.QueryAsync<Designer>(sql))
					.ToArray();
			}
		}

		public static class GetFilteredAndOrderedDesigners
		{
			public static async Task<Designer[]> Execute()
			{
				const string sql = @"
					select *
					from Designers
					where Dapperness = 1
					order by LabelName
					";

				using SqlConnection sqlConnection = SqlConnectionHelper.Create();
				return (await sqlConnection
					.QueryAsync<Designer>(sql))
					.ToArray();
			}
		}
	}
}
