#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Input
//       File: AdvInputManager.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using ForestOfChaos;
using ForestOfChaos.Unity.Generics;
using ForestOfChaos.Unity.Utilities;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar.InputSystem {
    [AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER + "/AdvVar/" + "Input Manager")]
    public class AdvInputManager: Singleton<AdvInputManager> {
        public AdvInputAxis[]  Axes;
        public Vector2Variable MousePosition = Vector2.zero;

        public void Update() {
            foreach (var advInputAxisVariable in Axes)
                advInputAxisVariable.Value.UpdateDataAndCallEvents();

            MousePosition.Value = Input.mousePosition;
        }

        public void Reset() {
            Axes = FoCsAssetFinder.FindAssetsByType<AdvInputAxis>();
        }
    }
}