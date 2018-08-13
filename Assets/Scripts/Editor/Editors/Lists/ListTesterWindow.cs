using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

public class ListTesterWindow: FoCsWindow<ListTesterWindow>
{
	private ListTest                     List;
	private SerializedObject             SerializedList;
	private FoCsEditor.AdvanceListLayout ListDrawer;

	[MenuItem("Tools/ListTester Window")]
	private static void Init()
	{
		GetWindowAndShow();
	}

	private void OnEnable()
	{
		List           = CreateInstance<ListTest>();
		SerializedList = new SerializedObject(List);
		ListDrawer     = new FoCsEditor.AdvanceListLayout(SerializedList.FindProperty("Array"));
	}

	protected override void OnGUI()
	{
		ListDrawer.Draw();
	}
}
