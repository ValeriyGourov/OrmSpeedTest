using System.Diagnostics;

using LinqToDB.Data;

namespace DbProvider.LinqToDb
{
	public static class Initialization
	{
		public static void Run()
		{
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (
				message,
				messageCategory,
				level) => Debug.WriteLine(message, messageCategory);
		}
	}
}
