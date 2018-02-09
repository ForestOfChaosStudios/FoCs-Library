using ForestOfChaosLib.Types;
using UnityEditor;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	[CustomPropertyDrawer(typeof(Vector2I))]
	public class Vector2IPropEditor: Vector2PropEditor
	{ }

	[CustomPropertyDrawer(typeof(Vector3I))]
	public class Vector3IPropEditor: Vector3PropEditor
	{ }

	[CustomPropertyDrawer(typeof(Vector4I))]
	public class Vector4IPropEditor: Vector4PropEditor
	{ }
}