using ForestOfChaosLib.Generics;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.InputSystem
{
	public class AdvInputManager: Singleton<AdvInputManager>
	{
		public AdvInputAxisReference[] AxisReferences;
		public Vector2Variable         MousePosition = Vector2.zero;

		public void Update()
		{
			foreach(var advInputAxisVariable in AxisReferences)
				advInputAxisVariable.Value.UpdateDataAndCallEvents();

			MousePosition.Value = Input.mousePosition;
		}

		public void Reset()
		{
			AxisReferences = Resources.FindObjectsOfTypeAll<AdvInputAxisReference>();
		}
	}
}
