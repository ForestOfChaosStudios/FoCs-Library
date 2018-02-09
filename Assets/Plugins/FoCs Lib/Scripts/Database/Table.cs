using System;
using System.Collections.Generic;

namespace ForestOfChaosLib.Database
{
	[Serializable]
	public class Table
	{
		public string TableName;

		[NonSerialized]
		public Database Database;

		public List<string> Collems = new List<string>();

		public Table(string tableName, Database database)
		{
			TableName = tableName;
			Database = database;
			GetCollems();
		}

		public object[] GetCollemData(int collem) => GetCollemData(Collems[collem]);

		public object[] GetCollemData(string collem)
		{
			return Database.GetQuery($"SELECT {collem} FROM {TableName}", 0);
		}

		private void GetCollems()
		{
			var dbIsOpen = Database.IsOpen;
			Database.IsOpen = true;

			using(var command = Database.Connection.CreateCommand())
			{
				command.CommandText = $"PRAGMA table_info('{TableName}');";
				using(var reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						Collems.Add(reader[1].ToString());
					}
				}

				Database.IsOpen = dbIsOpen;
			}
		}
	}
}