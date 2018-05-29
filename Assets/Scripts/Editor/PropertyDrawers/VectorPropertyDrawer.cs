using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class VectorPropEditor: FoCsPropertyDrawer
	{
		public static readonly GUIContent X_Content   = new GUIContent("X", "The X Value Of this Vector");
		public static readonly GUIContent Y_Content   = new GUIContent("Y", "The Y Value Of this Vector");
		public static readonly GUIContent Z_Content   = new GUIContent("Z", "The Z Value Of this Vector");
		public static readonly GUIContent W_Content   = new GUIContent("W", "The W Value Of this Vector");
		protected const        float      LABEL_WIDTH = 16;
	}

	[CustomPropertyDrawer(typeof(Vector2))]
	public class Vector2PropEditor: VectorPropEditor
	{
		public override void  OnGUI(Rect                           position, SerializedProperty property, GUIContent label) => Draw(position, property, label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label) => SingleLine;

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			position.height = SingleLine;

			if(string.IsNullOrEmpty(label.text))
			{
				DoFieldsDraw(position, property);
			}
			else
			{
				EditorGUI.LabelField(position, label);

				using(FoCsEditor.Disposables.IndentSet(0))
				{
					var pos = position.MoveX(EditorGUIUtility.labelWidth).MoveWidth(-EditorGUIUtility.labelWidth);
					DoFieldsDraw(pos, property);
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(2, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext().MoveWidth(-2), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, Y_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Vector3))]
	public class Vector3PropEditor: VectorPropEditor
	{
		public override void  OnGUI(Rect                           position, SerializedProperty property, GUIContent label) => Draw(position, property, label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label) => SingleLine;

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			position.height = SingleLine;

			if(string.IsNullOrEmpty(label.text))
				DoFieldsDraw(position, property);
			else
			{
				EditorGUI.LabelField(position, label);

				using(FoCsEditor.Disposables.IndentSet(0))
				{
					var pos = position.MoveX(EditorGUIUtility.labelWidth).MoveWidth(-EditorGUIUtility.labelWidth);
					DoFieldsDraw(pos, property);
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(3, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, Y_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, Z_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Vector4))]
	public class Vector4PropEditor: VectorPropEditor
	{
		public override void  OnGUI(Rect                           position, SerializedProperty property, GUIContent label) => Draw(position, property, label);
		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label) => SingleLine;

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			position.height = SingleLine;

			if(string.IsNullOrEmpty(label.text))
				DoFieldsDraw(position, property);
			else
			{
				EditorGUI.LabelField(position, label);

				using(FoCsEditor.Disposables.IndentSet(0))
				{
					var pos = position.MoveX(EditorGUIUtility.labelWidth).MoveWidth(-EditorGUIUtility.labelWidth);
					DoFieldsDraw(pos, property);
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(4, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, Y_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, Z_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(), property, W_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Quaternion))] public class QuaternionPropEditor: Vector4PropEditor { }
}