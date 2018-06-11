using ForestOfChaosLib.Generics;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.InputSystem
{
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
			Axes = Resources.FindObjectsOfTypeAll<AdvInputAxis>();
		}
	}
}
