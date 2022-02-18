#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: IPropertyLayoutHandler.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEditor;

namespace ForestOfChaos.Unity.Editor {
    public interface IPropertyLayoutHandler {
        void HandleProperty(SerializedProperty property);

        float PropertyHeight(SerializedProperty property);

        bool IsValidProperty(SerializedProperty property);

        void DrawAfterEditor(SerializedProperty serializedProperty);
    }
}