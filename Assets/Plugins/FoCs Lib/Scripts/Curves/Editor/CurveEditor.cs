using ForestOfChaosLib.Curves.Components;
using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Maths;
using ForestOfChaosLib.CSharpExtensions;
using ForestOfChaosLib.UnityScriptsExtensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Curves.Editor
{
	public class CurveEditor<T>: FoCsEditor<T>
		where T: MonoBehaviour, ICurve
	{
		private static float resolution = 0.1f;
		private T Curve;

		protected override void OnEnable()
		{
			base.OnEnable();
			Curve = target as T;
		}

		public override void DrawGUI()
		{
			resolution = EditorGUILayout.Slider(new GUIContent("Resolution", "The Curve Display Resolution"), resolution, 0.01f, 0.5f);
		}

		public override void OnSceneGUI()
		{
			using(var cc = EditorDisposables.ChangeCheck())
			{
				if(Curve.IsNull())
					return;
				var pos = Curve.CurvePositions;
				for(var i = 0; i < pos.Count; i++)
				{
					using(var undoCheck = EditorDisposables.ChangeCheck())
					{
						if(!Curve.UseGlobalSpace)
						{
							var tempPos = Curve.transform.TransformPoint(Curve.CurvePositions[i]);

							pos[i] = Curve.transform.InverseTransformPoint(Handles.DoPositionHandle(tempPos, Curve.transform.rotation));
							Handles.Label(tempPos, new GUIContent($"Index: {i}"));
						}
						else
						{
							pos[i] = Handles.DoPositionHandle(Curve.CurvePositions[i], Quaternion.identity);
							Handles.Label(pos[i], new GUIContent($"Index: {i}"));
						}
						if(undoCheck.changed)
						{
							Undo.RecordObject(Curve,"Changed Curve Position");
						}
					}
				}
				Curve.CurvePositions = pos;
				if(!Curve.UseGlobalSpace)
				{
					var tempPos = Curve.transform.TransformPoints(Curve.CurvePositions);
					for(float i = 0; i < 1f; i += resolution)
						Handles.DrawLine(BezierLerp.Lerp(tempPos, i), BezierLerp.Lerp(tempPos, (i + resolution).Clamp()));
				}
				else
				{
					for(float i = 0; i < 1f; i += resolution)
						Handles.DrawLine(BezierLerp.Lerp(Curve, i), BezierLerp.Lerp(Curve, (i + resolution).Clamp()));
				}
				if(cc.changed)
					EditorUtility.SetDirty(target);
			}
		}
	}

	[CustomEditor(typeof(BezierCurveCubeV3DBehaviour))]
	public class BezierCurveCubeV3DBehaviourEditor: CurveEditor<BezierCurveCubeV3DBehaviour>
	{ }

	[CustomEditor(typeof(BezierCurveQuadV3DBehaviour))]
	public class BezierCurveQuadV3DBehaviourEditor: CurveEditor<BezierCurveQuadV3DBehaviour>
	{ }

	[CustomEditor(typeof(BezierCurveV3DBehaviour))]
	public class BezierCurveV3DBehaviourEditor: CurveEditor<BezierCurveV3DBehaviour>
	{ }
}