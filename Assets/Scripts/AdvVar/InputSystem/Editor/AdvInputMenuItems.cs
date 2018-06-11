using System.Collections.Generic;
using System.IO;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.UnitySettings;
using ForestOfChaosLib.InputManager;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.InputSystem.Editor
{
	public static class AdvInputMenuItems
	{
		[MenuItem("GameObject/ADV Variables/Input Manager", false, 10)]
		private static void CreateInputManager(MenuCommand command)
		{
			var obj = AdvInputManager.CreateInstance("Adv Input Manager");
			AdvInputManager.Instance.Reset();
			Undo.RegisterCreatedObjectUndo(obj, "Created Adv Input Manager GameObject");
			Selection.activeObject = obj;
		}

		[MenuItem("Assets/Create/ADV Variables/Add All Input Axes")]
		private static void CreateInputManagerFolder(MenuCommand command)
		{
			if(!(Selection.activeObject is AdvFolder))
			{
				if(IsAssetAFolder(Selection.activeObject))
				{
					var path = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
					var obj = ScriptableObject.CreateInstance<AdvFolder>();

					AssetDatabase.CreateAsset(obj,$"{path}/Input.asset" );
					Undo.RegisterCreatedObjectUndo(obj, "Created Input AdvFolder");
					Selection.activeObject = obj;
				}
			}

			var strings = new List<string>();
			foreach(var name in ReadInputManager.GetAxisNames())
			{
				if(strings.Contains(name))
					continue;

				var sO = ScriptableObject.CreateInstance<AdvInputAxis>();
				sO.name  = name;
				sO.Value = new InputAxis(name);
				AssetDatabase.AddObjectToAsset(sO, Selection.activeObject);
				strings.Add(name);
			}

			EditorUtility.SetDirty(Selection.activeObject);
			AssetDatabase.ImportAsset(FoCsEditor.AssetPath(Selection.activeObject));
		}
		private static bool IsAssetAFolder(Object obj){
			string path = "";

			if (obj == null){
				return false;
			}

			path = AssetDatabase.GetAssetPath(obj.GetInstanceID());

			if (path.Length > 0)
			{
				if (Directory.Exists(path))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
 
			return false;
		}
	}
}
