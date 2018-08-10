using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		private static GUIStyle LabelStyle
		{
			get { return Styles.Unity.Label; }
		}

		private static GUIStyle ToggleStyle
		{
			get { return Styles.Unity.Toggle; }
		}

		private static GUIStyle ButtonStyle
		{
			get { return Styles.Unity.Button; }
		}

		private static GUIStyle FoldoutStyle
		{
			get { return Styles.Unity.Foldout; }
		}

		private static GUIStyle TextFieldStyle
		{
			get { return Styles.Unity.TextField_Editor; }
		}

		private static GUIStyle NumberFieldStyle
		{
			get { return Styles.Unity.NumberField; }
		}

		private static GUIStyle TextAreaStyle
		{
			get { return Styles.Unity.TextArea_Editor; }
		}

		public static partial class Styles
		{
			private static SkinRef unitySkins;

			public static SkinRef Unity
			{
				get { return unitySkins ?? (unitySkins = new SkinRef()); }
			}

			public static Texture2D GetTexture(string search)
			{
				return GetAsset<Texture2D>(search);
			}

			public static T GetAsset<T>(string search) where T: Object
			{
				var results = AssetDatabase.FindAssets(search);

				foreach(var guid in results)
				{
					var obj = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));

					if(obj != null)
						return obj;
				}

				return null;
			}
		}
	}
}
