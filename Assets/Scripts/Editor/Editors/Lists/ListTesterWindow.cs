using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

public class ListTesterWindow: FoCsWindow<ListTesterWindow>
{
	private ListTest                      List;
	private SerializedObject              SerializedList;
	private FoCsEditor.AdvancedListLayout ListDrawer;
	private FoCsEditor.AdvancedListLayout ListDrawer1;

	[MenuItem("Tools/ListTester Window")]
	private static void Init()
	{
		GetWindowAndShow();
	}

	private void OnEnable()
	{
		List           = CreateInstance<ListTest>();
		SerializedList = new SerializedObject(List);
		ListDrawer     = new FoCsEditor.AdvancedListLayout(SerializedList.FindProperty("Array"));
		ListDrawer1    = new FoCsEditor.AdvancedListLayout(SerializedList.FindProperty("Array"), new FoCsEditor.AdvancedListLayout.ListOptions(true, false, true));
	}

	private void Update()
	{
		//if(ListDrawer.IsAnimating)
			Repaint();
	}

	private void OnInspectorUpdate()
	{
		Repaint();
	}

	protected override void OnGUI()
	{
		Draw(ListDrawer, SerializedList);
		Draw(ListDrawer1, SerializedList);
	}

	private static void Draw(FoCsEditor.AdvancedListLayout list, SerializedObject serializedObject)
	{
		serializedObject.Update();

		if(FoCsGUI.Layout.Button("Open"))
			list.Listable.IsExpanded = true;

		list.Draw();
		serializedObject.ApplyModifiedProperties();
	}
}
