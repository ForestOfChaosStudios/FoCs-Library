using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			public static SkinRef unitySkins;
			public static SkinRef Unity => unitySkins ?? (unitySkins = new SkinRef());

			public static Texture2D GetTexture(string search) => GetAsset<Texture2D>(search);

			public static T GetAsset<T>(string search)
				where T: Object
			{
				var results = AssetDatabase.FindAssets(search);
				foreach(var guid in results)
				{
					var obj = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));

					if(obj != null)
					{
						return obj;
					}
				}
				return null;
			}
		}
	}
}