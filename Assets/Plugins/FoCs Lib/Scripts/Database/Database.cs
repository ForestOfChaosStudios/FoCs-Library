using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Mono.Data.Sqlite;

namespace ForestOfChaosLib.Database
{
	[Serializable]
	public class Database: IDisposable
	{
		private const string CONNECTION_STRING = "uri=file:{0}";
		public string ConnectionString;

		[NonSerialized]
		public List<Table> Tables = new List<Table>();

		public bool IsOpen
		{
			get
			{
				if(Connection == null)
					return false;
				return (Connection.State == ConnectionState.Open);
			}
			set
			{
				if((Connection == null) && value)
				{
					Open();
				}
				else if(!value)
				{
					Close();
				}
			}
		}

		public SqliteConnection Connection { get; private set; }

		public Database(Database other): this(other.ConnectionString, other.IsOpen)
		{ }

		public Database(string fileName, bool open = false)
		{
			ConnectionString = string.Format(CONNECTION_STRING, fileName);

			GetTables();

			if(open)
				Open();
		}

		private void GetTables()
		{
			var dbIsOpen = IsOpen;
			IsOpen = true;

			var tablesNames = GetQuery("SELECT name FROM sqlite_master WHERE type = 'table'", 0);
			foreach(var tablesName in tablesNames)
			{
				Tables.Add(new Table(tablesName.ToString(), this));
			}

			IsOpen = dbIsOpen;
		}

		public IDbConnection GetNewConnection() => new SqliteConnection(ConnectionString);

		public void Dispose()
		{
			Close();
		}

		public void Open()
		{
			if(Connection == null)
			{
				Connection = new SqliteConnection(ConnectionString);
				Connection.Open();
			}
			else
			{
				Connection.Open();
			}
		}

		public void Close()
		{
			if((Connection != null))
				Connection.Close();
		}

		public object[] GetQuery(string query, int index = 1)
		{
			var strs = new List<object>(0);
			using(var command = Connection.CreateCommand())
			{
				command.CommandText = query;
				using(var reader = command.ExecuteReader())
				{
					while(reader.Read())
					{
						strs.Add(reader[index]);
					}
				}
			}
			return strs.ToArray();
		}

		public void SetQuery(string query)
		{
			using(var command = Connection.CreateCommand())
			{
				command.CommandText = query;
				command.ExecuteScalar();
			}
		}

		public static void AddToTable(Database db, string tableName, List<DataEntry> values)
		{
			var dbIsOpen = db.IsOpen;
			db.IsOpen = true;

			var keysStr = new StringBuilder();
			var valuesStr = new StringBuilder();

			for(var i = 0; i < values.Count; i++)
			{
				var value = values[i];

				keysStr.Append(value.Key);
				if(i != values.Count - 1)
					keysStr.Append(",");

				valuesStr.Append("'");
				valuesStr.Append(value.Value);
				valuesStr.Append("'");
				if(i != values.Count - 1)
					valuesStr.Append(",");
			}

			db.SetQuery($"INSERT INTO {tableName}({keysStr}) VALUES({valuesStr})");

			db.IsOpen = dbIsOpen;
		}

		public struct DataEntry
		{
			public string Key;
			public string Value;
		}
	}
}