using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(Transform))]
	internal class TransformEditor: FoCsEditor<Transform>
	{
		private static bool scaleToggle;
		private static float scaleAmount = 1;

		private static readonly GUIContent ResetContent = new GUIContent("Reset Transform", "Reset Transforms in global space");
		private static readonly GUIContent ResetLocalContent = new GUIContent("Reset Local Transform", "Reset Transforms in local space");

		public override bool ShowCopyPasteButtons => true;

		public override bool UseDefaultMargins() => false;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			var transform = Target;

			DoDrawHeader();
			using(Disposables.Indent())
			{
				EditorGUILayout.LabelField(transform.parent == null?
											   "Transform" :
											   "Local Transform");
				bool guiChanged;
				var localPosition = EditorHelpers.DrawVector3("Position", transform.localPosition, Vector3.zero, transform, out guiChanged);
				if(guiChanged)
				{
					Undo.RecordObject(transform, "localPosition Changed");
					transform.localPosition = localPosition;
				}

				var localEulerAngles = EditorHelpers.DrawVector3("Rotation", transform.localEulerAngles, Vector3.zero, transform, out guiChanged);
				if(guiChanged)
				{
					Undo.RecordObject(transform, "localEulerAngles Changed");
					transform.localEulerAngles = localEulerAngles;
				}

				var localScale = EditorHelpers.DrawVector3("Scale", transform.localScale, Vector3.one, transform, out guiChanged);
				if(guiChanged)
				{
					Undo.RecordObject(transform, "localScale Changed");
					transform.localScale = localScale;
				}
				using(Disposables.VerticalScope())
				{
					if(scaleToggle = EditorGUILayout.Foldout(scaleToggle, "Scale Options"))
						ScaleBtnsEnabled();
				}
				serializedObject.ApplyModifiedProperties();
			}
		}

		protected override void DoDrawHeader()
		{
			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var transform = Target;
				if(GUILayout.Button(ResetContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "ResetPosRotScale");
					transform.ResetPosRotScale();
				}
				if(GUILayout.Button(ResetLocalContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "ResetLocalPosRotScale");
					transform.ResetLocalPosRotScale();
				}
				DrawCopyPasteButtons();
			}
		}

		private void ScaleBtnsEnabled()
		{
			ScaleArea();
			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				ScaleBtn(0.5f);
				ScaleBtn(1);
				ScaleBtn(2);
				ScaleBtn(5);
				ScaleBtn(10);
				ScaleBtn(20);
				ScaleBtn(50);
				ScaleBtn(100);
			}
		}

		private void ScaleBtn(float multi = 1)
		{
			var resetContent = new GUIContent($"{multi}x", $"Sets the Scale to ({multi},{multi},{multi})");

			if(GUILayout.Button(resetContent, EditorStyles.toolbarButton))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = Vector3.one * multi;
				scaleAmount = transform.localScale.x;
			}
		}

		private void ScaleArea()
		{
			var transform = Target;

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var content = new GUIContent("Scale amount", "Set amount to uniformly scale the object");
				scaleAmount = EditorGUILayout.FloatField(content, scaleAmount, EditorStyles.toolbarTextField);
				var scaleContent = new GUIContent("Set Scale", $"Sets the scale ({scaleAmount},{scaleAmount},{scaleAmount})");
				if(GUILayout.Button(scaleContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale = Vector3.one * scaleAmount;
				}
				var scaleTimesContent = new GUIContent("Times Scale",
													   $"Sets the scale ({transform.position.x * scaleAmount},{transform.position.y * scaleAmount},{transform.position.z * scaleAmount})");
				if(GUILayout.Button(scaleTimesContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale *= scaleAmount;
				}
			}
		}
	}
}