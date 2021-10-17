using Microsoft.Data.SqlClient;

using Configuration;

namespace DbProvider.Dapper
{
	static class SqlConnectionHelper
	{
		public static SqlConnection Create() => new(ConfigService.ConnectionString);
	}
}
