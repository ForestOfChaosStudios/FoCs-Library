#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsScriptableObjectEditor.cs
//    Created: 2022/02/19
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Editor.Windows;
using UnityEngine;

public abstract class FoCsScriptableObjectEditor<TWindow, TScriptableObject>: FoCsWindow<TWindow>
        where TScriptableObject: ScriptableObject
        where TWindow: FoCsWindow {

    protected override void OnGUI() { }
}