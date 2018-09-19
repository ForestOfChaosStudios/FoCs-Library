using ForestOfChaosLibrary.Animation;
using ForestOfChaosLibraryEditor.PropertyDrawers;
using ForestOfChaosLibrary.Extensions;
using ForestOfChaosLibrary.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibraryEditor.Animation
{
	[CustomPropertyDrawer(typeof(AnimatorKey))]
	public class AnimatorKeyDrawer: FoCsPropertyDrawer<AnimatorKey>
	{
		private const string KEY            = "Key";
		private const string KEY_LABEL      = "ID:";
		private const string KEY_TYPE       = "KeyType";
		private const string KEY_TYPE_LABEL = "Type:";
		private const string LABEL          = "Data:";
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
			using(var propScope = Disposables.PropertyScope(position, label, property))
			{
				position.height = SingleLine;
				label           = propScope.content;
				var labelPos = position.Edit(RectEdit.SetWidth(EditorGUIUtility.labelWidth));
				FoCsGUI.Label(labelPos, label);

				using(var scope = Disposables.RectHorizontalScope(6, position.Edit(RectEdit.AddX(labelPos.width), RectEdit.SetWidth(position.width - labelPos.width))))
				{
					using(Disposables.IndentSet(0))
					{
						using(var innerScope = Disposables.RectHorizontalScope(3, scope.GetNext(2)))
						{
							FoCsGUI.Label(innerScope.GetNext(), KEY_LABEL);
							FoCsGUI.PropertyField(innerScope.GetNext(2), property.FindPropertyRelative(KEY), GUIContent.none);
						}

						using(var innerScope = Disposables.RectHorizontalScope(5, scope.GetNext(2)))
						{
							FoCsGUI.Label(innerScope.GetNext(2), KEY_TYPE_LABEL);
							FoCsGUI.PropertyField(innerScope.GetNext(3), property.FindPropertyRelative(KEY_TYPE), GUIContent.none);
						}

						using(var innerScope = Disposables.RectHorizontalScope(5, scope.GetNext(2)))
						{
							var key     = property.GetTargetObjectOfProperty<AnimatorKey>();
							var typeStr = GetDisplayString(key);
							FoCsGUI.Label(innerScope.GetNext(2), LABEL);
							FoCsGUI.PropertyField(innerScope.GetNext(3), property.FindPropertyRelative(typeStr), GUIContent.none);
						}
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

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => SingleLinePlusPadding;
	}
}
