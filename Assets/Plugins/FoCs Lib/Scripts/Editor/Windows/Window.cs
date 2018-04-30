using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	/// <summary>
	/// [MenuItem("Tools/Forest Of Chaos/Example Window")]
	/// private static void Init(){
	///		GetWindowAndOpenTab();
	/// }
	/// </summary>
	/// <typeparam name="T">Class name of type that inherits directly from this class, for a static ref to its self</typeparam>
	public abstract class Window<T>: EditorWindow where T: EditorWindow
	{
		protected static T window;

		protected static EditorWindow GetWindow()
		{
			window = FindObjectOfType<T>() ?? CreateInstance<T>();
			return window;
		}

		protected static EditorWindow GetWindowAndOpenTab()
		{
			window = FindObjectOfType<T>() ?? CreateInstance<T>();
			window.ShowTab();
			return window;
		}

		protected static EditorWindow GetWindowAndOpenUtility()
		{
			window = FindObjectOfType<T>() ?? CreateInstance<T>();
			window.ShowUtility();
			return window;
		}

		protected virtual void OnGUI()
		{
			if(window == null)
				GetWindow();

			DrawGUI();
		}

		protected static void DrawReorderableList(ReorderableList list)
		{
			list.DoLayoutList();
		}

		protected abstract void DrawGUI();

		protected virtual void Update()
		{ }

		public static void DrawSpace()
		{
			EditorGUILayout.Space();
		}

		public static void DrawSpace(int count)
		{
			for(int i = 0; i < count; i++)
			{
				EditorGUILayout.Space();
			}
		}

		public static void DrawSpace(float size)
		{
			GUILayout.Space(size);
		}
	}
}