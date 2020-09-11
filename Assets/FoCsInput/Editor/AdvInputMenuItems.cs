#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Input.Editor
//       File: AdvInputMenuItems.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:04 AM
#endregion


using System.Collections.Generic;
using System.IO;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.AdvVar.InputSystem;
using ForestOfChaos.Unity.Editor;
using ForestOfChaos.Unity.Editor.UnitySettings;
using ForestOfChaos.Unity.InputManager;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.Editor.InputSystem {
    public static class AdvInputMenuItems {
        [MenuItem("GameObject/ADV Variables/Input Manager", false, 10)]
        private static void CreateInputManager(MenuCommand command) {
            var obj = AdvInputManager.CreateInstance("Adv Input Manager");
            AdvInputManager.Instance.Reset();
            Undo.RegisterCreatedObjectUndo(obj, "Created Adv Input Manager GameObject");
            Selection.activeObject = obj;
        }

        [MenuItem("Assets/Create/ADV Variables/Add All Input Axes")]
        private static void CreateInputManagerFolder(MenuCommand command) {
            if (!(Selection.activeObject is AdvSOFolder)) {
                if (IsAssetAFolder(Selection.activeObject)) {
                    var path = AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());
                    var obj  = ScriptableObject.CreateInstance<AdvSOFolder>();
                    AssetDatabase.CreateAsset(obj, $"{path}/Input.asset");
                    Undo.RegisterCreatedObjectUndo(obj, "Created Input AdvFolder");
                    Selection.activeObject = obj;
                }
            }

            var strings = new List<string>();

            foreach (var name in ReadInputManager.GetAxisNames()) {
                if (strings.Contains(name))
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

        private static bool IsAssetAFolder(Object obj) {
            var path = "";

            if (obj == null)
                return false;

            path = AssetDatabase.GetAssetPath(obj.GetInstanceID());

            if (path.Length > 0) {
                if (Directory.Exists(path))
                    return true;

                return false;
            }

            return false;
        }
    }
}