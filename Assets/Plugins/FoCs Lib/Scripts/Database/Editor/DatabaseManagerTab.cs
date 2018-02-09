using ForestOfChaosLib.Editor.Windows;
using ForestOfChaosLib.Editor;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Database
{
	public class DatabaseManagerTab: Tab<DatabaseWindow>
	{
		public override string TabName => "Database Manager";

		public override void DrawTab(Window<DatabaseWindow> owner)
		{
			EditorGUILayout.LabelField("Tabz");

			//using (var dB = new Database(FileAndPathHelpers.GetStreamingAssetsPath("Test.db"), true))
			//{
			//    var strs = dB.GetQuery("select * from items");
			//
			//    EditorGUILayout.LabelField("Items");
			//    using (new GUILayout.VerticalScope(GUI.skin.box))
			//    {
			//        foreach (var str in strs)
			//        {
			//            EditorGUILayout.LabelField(str);
			//        }
			//    }
			//
			//    EditorGUILayout.LabelField("Tables");
			//
			//    using (new GUILayout.VerticalScope(GUI.skin.box))
			//    {
			//        foreach (var str in dB.Tables)
			//        {
			//            EditorGUILayout.LabelField(str.TableName);
			//            using (new GUILayout.VerticalScope(GUI.skin.box))
			//            {
			//                foreach (var col in str.Collems)
			//                    EditorGUILayout.LabelField(col);
			//            }
			//        }
			//    }
			//    if (GUILayout.Button("Button"))
			//    {}
			//}
		}
	}
}