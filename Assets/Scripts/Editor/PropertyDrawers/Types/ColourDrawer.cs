using ForestOfChaosLib.Types;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers.Types
{
	[CustomPropertyDrawer(typeof(Colour))]
	public class ColourDrawer: FoCsPropertyDrawer<Colour>
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var rect = position;
			rect.height =  SingleLine;
			rect.y      += 1;
			var colour = GetOwner(property);

			if(colour == null)
				return;

			var rect2 = rect;
			rect2.width         = IndentSize;
			property.isExpanded = EditorGUI.Foldout(rect2, property.isExpanded, "");
			rect2               = rect;

			using(var ChangeCheck = FoCsEditor.Disposables.ChangeCheck())
			{
				var col = EditorGUI.ColorField(rect2, new GUIContent(property.displayName, property.displayName), colour);
				colour.SetColor(col);

				if(!property.isExpanded)
					return;

				using(FoCsEditor.Disposables.Indent())
				{
					rect.y += 1 + SingleLine;
					var A = EditorGUI.IntField(rect, new GUIContent("Alpha", "Alpha"), colour.A);
					rect.y += 1 + SingleLine;
					var R = EditorGUI.IntField(rect, new GUIContent("Red", "Red"), colour.R);
					rect.y += 1 + SingleLine;
					var G = EditorGUI.IntField(rect, new GUIContent("Green", "Green"), colour.G);
					rect.y += 1 + SingleLine;
					var B = EditorGUI.IntField(rect, new GUIContent("Blue", "Blue"), colour.B);
					rect.y += 1 + SingleLine;

					if(GUI.Button(rect, new GUIContent("Randomize Colour", "Randomizes the Colour")))
					{
						var colHSV = Random.ColorHSV();
						colour.SetColor(colHSV);

						return;
					}

					if(A >= 255)
						colour.A = 255;
					else if(A <= 0)
						colour.A = 0;
					else
						colour.A = (byte)A;

					if(R >= 255)
						colour.R = 255;
					else if(R <= 0)
						colour.R = 0;
					else
						colour.R = (byte)R;

					if(G >= 255)
						colour.G = 255;
					else if(G <= 0)
						colour.G = 0;
					else
						colour.G = (byte)G;

					if(B >= 255)
						colour.B = 255;
					else if(B <= 0)
						colour.B = 0;
					else
						colour.B = (byte)B;

					if(ChangeCheck.changed)
						Undo.RecordObject(property.serializedObject.targetObject, "ColourChange");
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if(property.isExpanded)
				return (EditorGUIUtility.singleLineHeight * 6) + 6;

			return EditorGUIUtility.singleLineHeight;
		}
	}
}
