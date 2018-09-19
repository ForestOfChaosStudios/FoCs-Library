using System;

namespace ForestOfChaosLibraryEditor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsControlPanel
	{
		/// <summary>
		///     This Attribute is used for Tabs that show in the FoCs Control Panel
		///     Requires a method
		///     static "Init()"
		///     public static void DrawGUI(FoCsControlPanel owner)
		/// </summary>
		public class ControlPanelTabAttribute: Attribute { }
	}
}
