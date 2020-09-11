#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: IPropertyLayoutHandler.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using UnityEditor;

namespace ForestOfChaosLibrary.Editor {
    public interface IPropertyLayoutHandler {
        void HandleProperty(SerializedProperty property);

        float PropertyHeight(SerializedProperty property);

        bool IsValidProperty(SerializedProperty property);

        void DrawAfterEditor(SerializedProperty serializedProperty);
    }
}