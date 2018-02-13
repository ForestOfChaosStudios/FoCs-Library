using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public static class FoCsGUIImages
	{
		internal const string SEPERATOR = @"\";
		internal static string Path = @"Assets\Plugins\FoCs Lib\Editor Resources\Textures";

		private static Texture objectField;

		private static Texture upArrow;

		private static Texture up2Arrow;

		private static Texture downArrow;

		private static Texture down2Arrow;

		public static Texture ObjectField => objectField ?? (objectField = EditorGUIUtility.FindTexture("IN ObjectField f@2x"));

		public static Texture UpArrow => upArrow ?? (upArrow = GetTexture("u_1_arrow"));

		public static Texture Up2Arrow => up2Arrow ?? (up2Arrow = GetTexture("u_2_arrow"));

		public static Texture DownArrow => downArrow ?? (downArrow = GetTexture("d_1_arrow"));

		public static Texture Down2Arrow => down2Arrow ?? (down2Arrow = GetTexture("d_2_arrow"));

		private static Texture GetTexture(string name) => (Texture)EditorGUIUtility.Load($"{Path}{SEPERATOR}{name}.png");
	}
}