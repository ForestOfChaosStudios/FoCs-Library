using UnityEditor;

namespace ForestOfChaosLib.Editor.Windows
{
	public abstract class Tab<T> where T: EditorWindow
	{
		public abstract string TabName { get; }
		public abstract void DrawTab(FoCsWindow<T> owner);
	}
}
