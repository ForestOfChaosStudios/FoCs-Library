using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Maths.Curves.Components;
using ForestOfChaosLib.Maths.Lerp;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Editor
{
	public class CurveV3DEditor<T>: FoCsEditor<T> where T: ICurveV3DComponent
	{
		private static float     resolution = 0.1f;
		private static Mode      MyMode     = Mode.Move;
		private static Transform debugTransform;
		public static  float     DebugTime = 0.5f;

		/// <inheritdoc />
		public override bool AllowsSortingModeChanging => false;

		public enum Mode
		{
			Hide,
			Move
		}

		private T Curve;

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
				DebugTime      = FoCsGUI.Layout.Slider(new GUIContent("Lerp Time: ", "Lerp Time"), DebugTime, 0f, 1f);

				if(debugTransform)
					debugTransform.position = Target.Lerp(DebugTime);
			}
		}

		public void OnSceneGUI()
		{
			using(var cc = Disposables.ChangeCheck())
			{
				if(Curve == null)
					return;

				if(MyMode == Mode.Move)
				{
					var pos = Curve.CurvePositions;

					for(var i = 0; i < pos.Count; i++)
					{
						using(var undoCheck = Disposables.ChangeCheck())
						{
							if(Curve.UseGlobalSpace)
								pos[i] = Target.transform.TransformPoint(pos[i]);

							pos[i] = Handles.DoPositionHandle(Curve.CurvePositions[i], Quaternion.identity);
							Handles.Label(pos[i], new GUIContent(string.Format("Index: {0}", i)));

							if(Curve.UseGlobalSpace)
								pos[i] = Target.transform.InverseTransformPoint(pos[i]);

							if(undoCheck.changed)
								Undo.RecordObject(Curve, "Changed Curve Position");
						}
					}

					Curve.CurvePositions = pos;
				}

				for(float i = 0; i < 1f; i += resolution)
				{
					if(Curve.UseGlobalSpace)
					{
						var a = Target.transform.TransformPoint(Vector3Lerp.Lerp(Curve.CurvePositions, i));
						var b = Target.transform.TransformPoint(Vector3Lerp.Lerp(Curve.CurvePositions, (i + resolution), true));
						Handles.DrawLine(a, b);
					}
					else
						Handles.DrawLine(Vector3Lerp.Lerp(Curve.CurvePositions, i), Vector3Lerp.Lerp(Curve.CurvePositions, (i + resolution),true));
				}

				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}

	[CustomEditor(typeof(CurveV3DCubeBehaviour))] public class BezierCurveCubeV3DBehaviourEditor: CurveV3DEditor<CurveV3DCubeBehaviour> { }

	[CustomEditor(typeof(CurveV3DQuadBehaviour))] public class BezierCurveQuadV3DBehaviourEditor: CurveV3DEditor<CurveV3DQuadBehaviour> { }

	[CustomEditor(typeof(CurveV3DBehaviour))] public class BezierCurveV3DBehaviourEditor: CurveV3DEditor<CurveV3DBehaviour> { }
}
