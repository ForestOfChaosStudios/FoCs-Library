#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: VectorIPropertyDrawer.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Types;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.PropertyDrawers {
    [CustomPropertyDrawer(typeof(Vector2I))]
    public class Vector2IPropEditor: Vector2PropEditor { }

    [CustomPropertyDrawer(typeof(Vector3I))]
    public class Vector3IPropEditor: Vector3PropEditor { }

    [CustomPropertyDrawer(typeof(Vector4I))]
    public class Vector4IPropEditor: Vector4PropEditor { }
}