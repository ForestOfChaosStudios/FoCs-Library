namespace ForestOfChaosLibrary.Editor.Windows
{
	public abstract class Tab<T> where T: FoCsWindow
	{
		public abstract string TabName { get; }
		public abstract void DrawTab(FoCsWindow<T> owner);
	}
}
