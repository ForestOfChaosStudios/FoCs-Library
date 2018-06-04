using UnityEditor;

namespace ForestOfChaosLib.AdvVar.InputSystem.Editor
{
	public static class AdvInputMenuItems
	{
		[MenuItem("GameObject/ADV Variables/Input Manager", false, 10)]
		private static void CreateInputManager(MenuCommand command)
		{
			AdvInputManager.CreateInstance("Adv Input Manager");
			AdvInputManager.Instance.Reset();
		}
	}
}
