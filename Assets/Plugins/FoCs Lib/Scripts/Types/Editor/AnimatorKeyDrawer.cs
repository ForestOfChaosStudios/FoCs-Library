using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Animation
{
	[CustomPropertyDrawer(typeof(AnimatorKey))]
	public class AnimatorKeyDrawer: FoCsPropertyDrawer<AnimatorKey>
	{
		private const string KEY = "Key";
		private const string KEY_LABEL = "Key ID";

		private const string KEY_TYPE = "KeyType";
		private const string KEY_TYPE_LABEL = "Key Type";

		private const string LABEL = "Key Data";

		private const string INT_DATA = "intData";

		private const string FLOAT_DATA = "floatData";

		private const string BOOL_DATA = "boolData";

		private const string TRIGGER_DATA = "triggerData";

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var scope = FoCsEditorDisposables.RectHorizontalScope(8, position))
			{

				EditorGUI.LabelField(scope.GetNext(), label);
				scope.GetNext();

				using(FoCsEditorDisposables.Indent(-1))
				{
					EditorGUI.LabelField(scope.GetNext(), KEY_LABEL);
					EditorGUI.PropertyField(scope.GetNext(), property.FindPropertyRelative(KEY), GUIContent.none);

					EditorGUI.LabelField(scope.GetNext(), KEY_TYPE_LABEL);
					EditorGUI.PropertyField(scope.GetNext(), property.FindPropertyRelative(KEY_TYPE), GUIContent.none);

					var key = property.GetTargetObjectOfProperty<AnimatorKey>();
					var typeStr = INT_DATA;

					switch(key.KeyType)
					{
						case AnimatorKey.AnimType.Int:
							typeStr = INT_DATA;

							break;
						case AnimatorKey.AnimType.Float:
							typeStr = FLOAT_DATA;

							break;
						case AnimatorKey.AnimType.Bool:
							typeStr = BOOL_DATA;

							break;
						case AnimatorKey.AnimType.Trigger:
							typeStr = TRIGGER_DATA;

							break;
					}
					EditorGUI.LabelField(scope.GetNext(), LABEL);
					EditorGUI.PropertyField(scope.GetNext(), property.FindPropertyRelative(typeStr), GUIContent.none);
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLine;
	}
}