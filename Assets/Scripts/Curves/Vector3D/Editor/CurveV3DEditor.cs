using ForestOfChaosLib.Curves.Components;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Maths;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Editor
{
	public class CurveV3DEditor<T>: FoCsEditor<T> where T: MonoBehaviour, ICurveV3D
	{
		private static float resolution = 0.1f;
		private        T     Curve;
		private static Mode MyMode = Mode.Move;
		enum Mode
		{
			Hide,Move
		}

		private static Transform debugTransform;

		public static float DebugTime = 0.5f;

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
				MyMode = (Mode)EditorGUILayout.EnumPopup(MyMode);


				resolution     = EditorGUILayout.Slider(new GUIContent("Resolution", "The Curve Display Resolution"), resolution, 0.01f, 0.5f);
				debugTransform = FoCsGUI.Layout.ObjectField<Transform>(new GUIContent("Example"), debugTransform, true);
				DebugTime      = EditorGUILayout.Slider(new GUIContent("Lerp Time: ", "Lerp Time"), DebugTime, 0f, 1f);

				if(debugTransform)
				{
					debugTransform.position = Curve.Lerp(DebugTime);
				}
			}
		}

		public override void OnSceneGUI()
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
							pos[i] = Handles.DoPositionHandle(Curve.CurvePositions[i], Quaternion.identity);
							Handles.Label(pos[i], new GUIContent(string.Format("Index: {0}", i)));

							if(undoCheck.changed)
								Undo.RecordObject(Curve, "Changed Curve Position");
						}
					}

					Curve.CurvePositions = pos;
				}

				for(float i = 0; i < 1f; i += resolution)
					Handles.DrawLine(Vector3BezierLerp.Lerp(Curve, i), Vector3BezierLerp.Lerp(Curve, (i + resolution).Clamp()));


				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}

	[CustomEditor(typeof(BezierCurveV3DCubeBehaviour))] public class BezierCurveCubeV3DBehaviourEditor: CurveV3DEditor<BezierCurveV3DCubeBehaviour> { }

	[CustomEditor(typeof(BezierCurveV3DQuadBehaviour))] public class BezierCurveQuadV3DBehaviourEditor: CurveV3DEditor<BezierCurveV3DQuadBehaviour> { }

	[CustomEditor(typeof(BezierCurveV3DBehaviour))] public class BezierCurveV3DBehaviourEditor: CurveV3DEditor<BezierCurveV3DBehaviour> { }
}