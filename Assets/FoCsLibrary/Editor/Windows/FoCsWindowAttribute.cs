using System;

namespace ForestOfChaosLibrary.Editor
{
	/// <summary>
	///     This Attribute is used for Windows that can be opened via the FoCs Control Panel
	///     Requires a method
	///     "static Init()"
	///     "override void OnGUI()"
	/// </summary>
	public class FoCsWindowAttribute: Attribute { }
}
