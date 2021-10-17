using Configuration;

using Domain;

using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;

namespace DbProvider.LinqToDb
{
	public class LinqToDbDataConnection : DataConnection
	{
		public ITable<Designer> Designers => GetTable<Designer>().TableName(nameof(Designers));
		public ITable<Client> Clients => GetTable<Client>().TableName(nameof(Clients));
		public ITable<ContactInfo> ContactInfos => GetTable<ContactInfo>().TableName(nameof(ContactInfos));
		public ITable<Product> Products => GetTable<Product>().TableName(nameof(Products));
		public ITable<ClientDesigner> ClientDesigner => GetTable<ClientDesigner>().TableName(nameof(ClientDesigner));

		public LinqToDbDataConnection()
			: base(
				  SqlServerTools.GetDataProvider(SqlServerVersion.v2017, SqlServerProvider.MicrosoftDataSqlClient),
				  ConfigService.ConnectionString)
		{
		}
	}
}
