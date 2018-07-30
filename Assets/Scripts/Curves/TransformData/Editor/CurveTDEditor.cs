using ForestOfChaosLib.Curves.Components;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.Types;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Editor
{
	public class CurveTDEditor<T>: FoCsEditor<T> where T: MonoBehaviour, ICurveTD
	{
		private static float     resolution = 0.1f;
		private static Mode      MyMode     = Mode.Move;
		private static Transform debugTransform;
		public static  float     DebugTime = 0.5f;
		private        T         Curve;

		protected void OnEnable()
		{
			Curve = target as T;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			using(Disposables.IndentSet(1))
			{
				FoCsGUI.Layout.Label("Editor Only:");
				MyMode         = (Mode)FoCsGUI.Layout.EnumPopup(MyMode);
				resolution     = FoCsGUI.Layout.Slider(new GUIContent("Resolution", "The Curve Display Resolution"), resolution, 0.01f, 0.5f);
				debugTransform = FoCsGUI.Layout.ObjectField(debugTransform, new GUIContent("Example"), true);
				DebugTime      = FoCsGUI.Layout.Slider(new GUIContent("Lerp Time: ", "Lerp Time"), DebugTime, 0f, 1f);

				if(debugTransform)
					debugTransform.SetFromTD(Target.Lerp(DebugTime));
			}
		}

		public override void OnSceneGUI()
		{
			using(var cc = Disposables.ChangeCheck())
			{
				if(Curve == null)
					return;

				var pos = Curve.CurvePositions;

				for(var i = 0; i < pos.Count; i++)
				{
					using(var undoCheck = Disposables.ChangeCheck())
					{
						var tdPos = Curve.CurvePositions[i].Position;
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

						pos[i].UpdateData(tdPos, tdRot, tdScl);
						Handles.Label(pos[i].Position, new GUIContent(string.Format("Index: {0}", i)));

						if(undoCheck.changed)
							Undo.RecordObject(Curve, "Changed Curve Position");
					}
				}

				Curve.CurvePositions = pos;

				for(float i = 0; i < 1f; i += resolution)
					Handles.DrawLine(TransformDataBezierLerp.Lerp(Curve, i).Position, TransformDataBezierLerp.Lerp(Curve, (i + resolution).Clamp()).Position);

				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}

		private enum Mode
		{
			Hide,
			Move,
			Rotate,
			Scale,
			MoveRotate,
			RotateShowMoveArrows
		}
	}

	[CustomEditor(typeof(BezierCurveTDCubeBehaviour))] public class BezierCurveCubeTDBehaviourEditor: CurveTDEditor<BezierCurveTDCubeBehaviour> { }

	[CustomEditor(typeof(BezierCurveTDQuadBehaviour))] public class BezierCurveQuadTDBehaviourEditor: CurveTDEditor<BezierCurveTDQuadBehaviour> { }

	[CustomEditor(typeof(BezierCurveTDDoubleBehaviour))] public class BezierCurveTDDoubleBehaviourEditor: CurveTDEditor<BezierCurveTDBehaviour> { }

	[CustomEditor(typeof(BezierCurveTDBehaviour))] public class BezierCurveTDBehaviourEditor: CurveTDEditor<BezierCurveTDBehaviour> { }
}
