using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ForestOfChaosLib.IO
{
	public static class GameDataIO
	{
		public const string FILE_EXT = SimpleIO.FILE_EXT;




		public struct GameSaveData
		{
			public string Data;
			public string Hash;
		}
	}
}