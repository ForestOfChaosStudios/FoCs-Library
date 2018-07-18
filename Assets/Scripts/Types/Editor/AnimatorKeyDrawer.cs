using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Animation
{
	[CustomPropertyDrawer(typeof(AnimatorKey))]
	public class AnimatorKeyDrawer: FoCsPropertyDrawer<AnimatorKey>
	{
		private const string KEY            = "Key";
		private const string KEY_LABEL      = "Key ID";
		private const string KEY_TYPE       = "KeyType";
		private const string KEY_TYPE_LABEL = "Key Type";
		private const string LABEL          = "Key Data";
		private const string INT_DATA       = "IntData";
		private const string FLOAT_DATA     = "FloatData";
		private const string BOOL_DATA      = "BoolData";
		private const string TRIGGER_DATA   = "TriggerData";

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			DoDraw(position, property, label);
		}

		public static void DoDraw(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				position.height = SingleLine;
				label = propScope.content;
				var labelPos = position.Edit(RectEdit.SetWidth(EditorGUIUtility.labelWidth));

				EditorGUI.LabelField(labelPos, label);

				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(6, position.Edit(RectEdit.AddX(labelPos.width), RectEdit.SetWidth(position.width - labelPos.width))))
				{
					using(FoCsEditor.Disposables.Indent(-1))
					{
						EditorGUI.LabelField(scope.GetNext(), KEY_LABEL);
						EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractX(4)), property.FindPropertyRelative(KEY), GUIContent.none);
						EditorGUI.LabelField(scope.GetNext(), KEY_TYPE_LABEL);
						EditorGUI.PropertyField(scope.GetNext(RectEdit.SubtractX(4)), property.FindPropertyRelative(KEY_TYPE), GUIContent.none);
						var key     = property.GetTargetObjectOfProperty<AnimatorKey>();
						var typeStr = GetDisplayString(key);
						EditorGUI.LabelField(scope.GetNext(), LABEL);
						EditorGUI.PropertyField(scope.GetNext(), property.FindPropertyRelative(typeStr), GUIContent.none);
					}
				}
			}
		}

		private static string GetDisplayString(AnimatorKey key)
		{
			switch(key.KeyType)
			{
				case AnimatorKey.AnimType.Int:     return INT_DATA;
				case AnimatorKey.AnimType.Float:   return FLOAT_DATA;
				case AnimatorKey.AnimType.Bool:    return BOOL_DATA;
				case AnimatorKey.AnimType.Trigger: return TRIGGER_DATA;
			}

			return TRIGGER_DATA;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return SingleLinePlusPadding;
		}
	}
}