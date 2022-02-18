#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: TDCurveEditor.cs
//    Created: 2020/04/25
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Extensions;
using ForestOfChaos.Unity.Maths.Curves.Components;
using ForestOfChaos.Unity.Types;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.Maths.Curves {
    public class TDCurveEditor<TCurveTdComponent>: FoCsEditor<TCurveTdComponent> where TCurveTdComponent: ICurveTDComponent {
        private static float     resolution = 0.1f;
        private static Mode      MyMode     = Mode.Move;
        private static Transform debugTransform;
        public static  float     DebugTime = 0.5f;
        private static bool      UseGizmo;

        public enum Mode {
            Hide,
            Move,
            Rotate,
            Scale,
            MoveRotate,
            RotateShowMoveArrows
        }

        private TCurveTdComponent Curve;

        protected override void OnEnable() {
            base.OnEnable();
            Curve = target as TCurveTdComponent;
        }

        protected override void DoExtraDraw() {
            using (Disposables.IndentSet(1)) {
                FoCsGUI.Layout.Label("Editor Only:");
                MyMode         = (Mode)EditorGUILayout.EnumPopup(MyMode);
                resolution     = FoCsGUI.Layout.Slider(new GUIContent("Resolution", "The Curve Display Resolution"), resolution, 0.01f, 0.5f);
                debugTransform = FoCsGUI.Layout.ObjectField(debugTransform, new GUIContent("Example"), true);

                using (var change = Disposables.ChangeCheck()) {
                    DebugTime = FoCsGUI.Layout.Slider(new GUIContent("Lerp Time: ", "Lerp Time"), DebugTime, 0f, 1f);
                    UseGizmo  = FoCsGUI.Layout.ToggleField("Use Gizmos", UseGizmo);

                    if (change.changed && UseGizmo)
                        SceneView.RepaintAll();
                }

                if (debugTransform)
                    debugTransform.SetFromTD(Target.Lerp(DebugTime));
            }
        }

        public void OnSceneGUI() {
            if (UseGizmo && !debugTransform) {
                var data           = Target.Lerp(DebugTime);
                var matrix         = Handles.matrix;
                var rotationMatrix = Matrix4x4.TRS(data.Position, data.Rotation, data.Scale);
                Handles.matrix = rotationMatrix;
                Handles.DrawWireCube(Vector3.zero, Vector3.one);
                Handles.matrix = matrix;
            }

            using (var cc = Disposables.ChangeCheck()) {
                if ((Curve == null) || Curve.CurvePositions.IsNullOrEmpty())
                    return;

                var pos = Curve.CurvePositions;

                for (var i = 0; i < pos.Count; i++) {
                    using (var undoCheck = Disposables.ChangeCheck()) {
                        var tdPos = Curve.CurvePositions[i].Position;

                        if (!Target.UseGlobalSpace)
                            tdPos = Target.transform.TransformPoint(tdPos);

                        var tdScl = Curve.CurvePositions[i].Scale;
                        var tdRot = Curve.CurvePositions[i].Rotation;

                        switch (MyMode) {
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

                        Handles.Label(tdPos, new GUIContent($"Index: {i}"));

                        if (!Target.UseGlobalSpace)
                            tdPos = Target.transform.InverseTransformPoint(tdPos);

                        //pos[i].UpdateData(tdPos, tdRot, tdScl);
                        pos[i] = new TransformData(tdPos, tdRot, tdScl);

                        if (undoCheck.changed)
                            Undo.RecordObject(Curve, "Changed Curve Position");
                    }
                }

                Curve.CurvePositions = pos;

                for (float i = 0; i < 1f; i += resolution)
                    Handles.DrawLine(Target.Lerp(i).Position, Target.Lerp((i + resolution).Clamp()).Position);

                if (cc.changed) {
                    serializedObject.ApplyModifiedProperties();
                    EditorUtility.SetDirty(target);
                }
            }
        }
    }

    [CustomEditor(typeof(TDCurve4PointsBehaviour))]
    public class TDCurve4PointsBehaviourEditor: TDCurveEditor<TDCurve4PointsBehaviour> { }

    [CustomEditor(typeof(TDCurve3PointsBehaviour))]
    public class TDCurve3PointsBehaviourEditor: TDCurveEditor<TDCurve3PointsBehaviour> { }

    [CustomEditor(typeof(TDCurve2PointsBehaviour))]
    public class TDCurve2PointsBehaviourEditor: TDCurveEditor<TDCurveBehaviour> { }

    [CustomEditor(typeof(TDCurveBehaviour))]
    public class TDCurveBehaviourEditor: TDCurveEditor<TDCurveBehaviour> { }
}