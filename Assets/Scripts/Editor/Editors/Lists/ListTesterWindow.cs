using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Windows;
using UnityEditor;

public class ListTesterWindow: FoCsWindow<ListTesterWindow>
{
	private ListTest                      List;
	private SerializedObject              SerializedList;
	private FoCsEditor.AdvancedListLayout ListDrawer;

	[MenuItem("Tools/ListTester Window")]
	private static void Init()
	{
		GetWindowAndShow();
	}

	private void OnEnable()
	{
		List            = CreateInstance<ListTest>();
		SerializedList  = new SerializedObject(List);
		ListDrawer      = new FoCsEditor.AdvancedListLayout(SerializedList.FindProperty("Array"));
	}

	private void Update()
	{
		if(ListDrawer.IsAnimating)
			Repaint();
	}

	protected override void OnGUI()
	{
		Draw(ListDrawer,  SerializedList,  "Array");
	}

	private static void Draw(FoCsEditor.AdvancedListLayout list, SerializedObject serializedObject, string propertyName)
	{
		serializedObject.Update();

		if(FoCsGUI.Layout.Button("Open"))
			list.Property.isExpanded = true;

		list.Property = serializedObject.FindProperty(propertyName);
		list.Draw();
		serializedObject.ApplyModifiedProperties();
	}
}
