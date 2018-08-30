using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths.Curves.Components;
using ForestOfChaosLib.Maths.Lerp;
using ForestOfChaosLib.Types;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Maths.Curves.Editor
{
	public class CurveTDEditor<T>: FoCsEditor<T> where T: ICurveTDComponent
	{
		private static float     resolution = 0.1f;
		private static Mode      MyMode     = Mode.Move;
		private static Transform debugTransform;
		public static  float     DebugTime = 0.5f;

		public enum Mode
		{
			Hide,
			Move,
			Rotate,
			Scale,
			MoveRotate,
			RotateShowMoveArrows
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
					debugTransform.SetFromTD(Target.Lerp(DebugTime));
			}
		}

		public void OnSceneGUI()
		{
			using(var cc = Disposables.ChangeCheck())
			{
				if((Curve == null) || Curve.CurvePositions.IsNullOrEmpty())
					return;

				var pos = Curve.CurvePositions;

				for(var i = 0; i < pos.Count; i++)
				{
					using(var undoCheck = Disposables.ChangeCheck())
					{
						var tdPos = Curve.CurvePositions[i].Position;

						if(Target.UseGlobalSpace)
							tdPos = Target.transform.TransformPoint(tdPos);

						var tdScl = Curve.CurvePositions[i].Scale;
						var tdRot = Curve.CurvePositions[i].Rotation;

						switch(MyMode)
						{
							case Mode.Move:
								tdPos = Handles.DoPositionHandle(tdPos, tdRot);

								break;
							case Mode.Rotate:
								tdRot = Handles.DoRotationHandle(tdRot, tdPos);

								break;
							case Mode.Scale:
								tdScl = Handles.ScaleHandle(tdScl, tdPos, tdRot, HandleUtility.GetHandleSize(tdPos));

								break;
							case Mode.MoveRotate:
								tdPos = Handles.DoPositionHandle(tdPos, tdRot);
								tdRot = Handles.DoRotationHandle(tdRot, tdPos);

								break;
							case Mode.RotateShowMoveArrows:
								Handles.DoPositionHandle(tdPos, tdRot);
								tdRot = Handles.DoRotationHandle(tdRot, tdPos);

								break;
						}

						Handles.Label(pos[i].Position, new GUIContent(string.Format("Index: {0}", i)));

						if(Target.UseGlobalSpace)
							tdPos = Target.transform.InverseTransformPoint(tdPos);

						pos[i].UpdateData(tdPos, tdRot, tdScl);

						if(undoCheck.changed)
							Undo.RecordObject(Curve, "Changed Curve Position");
					}
				}

				Curve.CurvePositions = pos;

				for(float i = 0; i < 1f; i += resolution)
				{
					if(Target.UseGlobalSpace)
					{
						var a = Target.transform.InverseTransformPoint(TransformDataLerp.Lerp(Curve.CurvePositions, i).Position);
						var b = Target.transform.InverseTransformPoint(TransformDataLerp.Lerp(Curve.CurvePositions, (i + resolution).Clamp()).Position);
						Handles.DrawLine(a, b);
					}
					else
						Handles.DrawLine(TransformDataLerp.Lerp(Curve.CurvePositions, i).Position, TransformDataLerp.Lerp(Curve.CurvePositions, (i + resolution).Clamp()).Position);
				}

				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}

	[CustomEditor(typeof(CurveTDCubeBehaviour))] public class BezierCurveCubeTDBehaviourEditor: CurveTDEditor<CurveTDCubeBehaviour> { }

	[CustomEditor(typeof(CurveTDTriBehaviour))] public class BezierCurveQuadTDBehaviourEditor: CurveTDEditor<CurveTDTriBehaviour> { }

	[CustomEditor(typeof(CurveTDDoubleBehaviour))] public class BezierCurveTDDoubleBehaviourEditor: CurveTDEditor<CurveTDBehaviour> { }

	[CustomEditor(typeof(CurveTDBehaviour))] public class BezierCurveTDBehaviourEditor: CurveTDEditor<CurveTDBehaviour> { }
}
