using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	/// <inheritdoc />
	/// <summary>
	///     [MenuItem("Tools/Forest Of Chaos/Example Window")]
	///     private static void Init(){
	///     GetWindowAndOpenTab();
	///     }
	/// </summary>
	/// <typeparam name="T">Class name of type that inherits directly from this class, for a static ref to its self</typeparam>
	public abstract class FoCsWindow<T>: EditorWindow where T: EditorWindow
	{
		private static   T window;
		protected static T Window
		{
			get { return window ?? (window = GetWindow()); }
		}

		protected static T GetWindow()
		{
			if(window != null)
				return window;

			window = FindObjectOfType<T>() ?? CreateInstance<T>();

			return window;
		}

		protected static T GetWindowAndShow()
		{
			GetWindow();
			window.Show();
			window.Focus();

			return window;
		}

		protected static T GetWindowAndOpenUtility()
		{
			GetWindow();
			window.ShowUtility();
			window.Focus();

			return window;
		}

		protected abstract void OnGUI();

		protected static void DrawReorderableList(ReorderableList list)
		{
			list.DoLayoutList();
		}

		public static void DrawSpace()
		{
			EditorGUILayout.Space();
		}

		public static void DrawSpace(int count)
		{
			for(var i = 0; i < count; i++)
				EditorGUILayout.Space();
		}

		public static void DrawSpace(float size)
		{
			GUILayout.Space(size);
		}
	}
}