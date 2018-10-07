using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		private static GUIStyle LabelStyle       => Styles.Unity.Label;
		private static GUIStyle ToggleStyle      => Styles.Unity.Toggle;
		private static GUIStyle ButtonStyle      => Styles.Unity.Button;
		private static GUIStyle FoldoutStyle     => Styles.Unity.Foldout;
		private static GUIStyle TextFieldStyle   => Styles.Unity.TextField_Editor;
		private static GUIStyle NumberFieldStyle => Styles.Unity.NumberField;
		private static GUIStyle TextAreaStyle    => Styles.Unity.TextArea_Editor;

		public static partial class Styles
		{
			private static SkinRef unitySkins;
			public static  SkinRef Unity => unitySkins ?? (unitySkins = new SkinRef());
			public static Texture2D GetTexture(string search) => GetAsset<Texture2D>(search);

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
