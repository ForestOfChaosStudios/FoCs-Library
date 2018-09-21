using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.Windows
{
	[FoCsWindow]
	public class TextureMaker: FoCsWindow<TextureMaker>
	{
		private const string TITLE = "Texture Maker";
		private       Color  color;

		[MenuItem(FileStrings.FORESTOFCHAOS_ + TITLE)]
		private static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = TITLE;
		}

		protected override void OnGUI()
		{
			color = EditorGUILayout.ColorField("Colour To Make Texture", color);

			if(GUILayout.Button("Create Texture"))
			{
				var tex = new Texture2D(2, 2);
				tex.SetPixels(new[] {color, color, color, color});
				tex.Apply();
				AssetDatabase.CreateAsset(tex, string.Format("Assets/Solid_{0}.asset", ColorUtility.ToHtmlStringRGB(color)));
			}
		}
	}
}
