using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths.Curves.Components;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Editor
{
	public class V3DCurveEditor<T>: FoCsEditor<T> where T: ICurveV3DComponent
	{
		private static float     resolution = 0.1f;
		private static Mode      MyMode     = Mode.Move;
		private static Transform debugTransform;
		public static  float     DebugTime = 0.5f;
		private static bool      UseGizmo  = false;

		public enum Mode
		{
			Hide,
			Move
		}

		private T Curve;

		/// <inheritdoc />
		public override bool AllowsSortingModeChanging => false;

		protected override void OnEnable()
		{
			base.OnEnable();
			Curve = target as T;
		}

		protected override void DoExtraDraw()
		{
			using(Disposables.IndentSet(1))
			{
				FoCsGUI.Layout.Label("Editor Only:");
				MyMode         = (Mode)EditorGUILayout.EnumPopup(MyMode);
				resolution     = FoCsGUI.Layout.Slider(new GUIContent("Resolution", "The Curve Display Resolution"), resolution, 0.01f, 0.5f);
				debugTransform = FoCsGUI.Layout.ObjectField(debugTransform, new GUIContent("Example"), true);

				using(var change = Disposables.ChangeCheck())
				{
					DebugTime = FoCsGUI.Layout.Slider(new GUIContent("Lerp Time: ", "Lerp Time"), DebugTime, 0f, 1f);
					UseGizmo  = FoCsGUI.Layout.ToggleField("Use Gizmos", UseGizmo);

					if(change.changed && UseGizmo)
						SceneView.RepaintAll();
				}

				if(debugTransform)
					debugTransform.position = Target.Lerp(DebugTime);
			}
		}

		public void OnSceneGUI()
		{
			if(UseGizmo && !debugTransform)
			{
				var data = Target.Lerp(DebugTime);
				Handles.DrawWireCube(data, Vector3.one);
			}

			using(var cc = Disposables.ChangeCheck())
			{
				if((Curve == null) || Curve.CurvePositions.IsNullOrEmpty())
					return;

				if(MyMode == Mode.Move)
				{
					var pos = Curve.CurvePositions;

					for(var i = 0; i < pos.Count; i++)
					{
						using(var undoCheck = Disposables.ChangeCheck())
						{
							if(!Curve.UseGlobalSpace)
								pos[i] = Target.transform.TransformPoint(pos[i]);

							pos[i] = Handles.DoPositionHandle(Curve.CurvePositions[i], Quaternion.identity);
							Handles.Label(pos[i], new GUIContent(string.Format("Index: {0}", i)));

							if(!Curve.UseGlobalSpace)
								pos[i] = Target.transform.InverseTransformPoint(pos[i]);

							if(undoCheck.changed)
								Undo.RecordObject(Curve, "Changed Curve Position");
						}
					}

					Curve.CurvePositions = pos;
				}

				for(float i = 0; i < 1f; i += resolution)
					Handles.DrawLine(Target.Lerp(i), Target.Lerp((i + resolution).Clamp()));

				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}

	[CustomEditor(typeof(V3CurveBehaviour))] public class V3DCurveBehaviourEditor: V3DCurveEditor<V3CurveBehaviour> { }

	[CustomEditor(typeof(V3Curve3PointsBehaviour))] public class V3DCurve3PointsBehaviourEditor: V3DCurveEditor<V3Curve3PointsBehaviour> { }

	[CustomEditor(typeof(V3Curve4PointsBehaviour))] public class V3DCurve4PointsBehaviourEditor: V3DCurveEditor<V3Curve4PointsBehaviour> { }
}
