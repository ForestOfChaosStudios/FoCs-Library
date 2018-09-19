using ForestOfChaosLibrary;
using ForestOfChaosLibrary.Generics;
using ForestOfChaosLibrary.Utilities;
using UnityEngine;

namespace ForestOfChaosAdvVar.InputSystem
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Input Manager")]
	public class AdvInputManager: Singleton<AdvInputManager>
	{
		public AdvInputAxis[]  Axes;
		public Vector2Variable MousePosition = Vector2.zero;

		public void Update()
		{
			foreach(var advInputAxisVariable in Axes)
				advInputAxisVariable.Value.UpdateDataAndCallEvents();

			MousePosition.Value = Input.mousePosition;
		}

		public void Reset()
		{
			Axes = FoCsAssetFinder.FindAssetsByType<AdvInputAxis>();
		}
	}
}
