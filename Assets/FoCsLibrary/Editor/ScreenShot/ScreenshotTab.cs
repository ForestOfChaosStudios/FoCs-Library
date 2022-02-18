#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: ScreenshotTab.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using ForestOfChaos.Unity.Editor.Windows;
using ForestOfChaos.Unity.ScreenCap;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaos.Unity.Editor.ScreenCap {
    public class ScreenshotTab: FoCsTab<ScreenCapWindow> {
        private   ScreenShotArgs  args;
        protected ScreenCapWindow Owner;

        public override string TabName => "Screenshot";

        public override void DrawTab(FoCsWindow<ScreenCapWindow> owner) {
            Owner = owner as ScreenCapWindow;

            using (Disposables.HorizontalScope()) {
                using (Disposables.VerticalScope()) {
                    DrawVariables();

                    using (Disposables.HorizontalScope())
                        DrawTakeImageGUI();
                }
            }
        }

        private void DrawVariables() {
            DrawScale();

            //DrawFilePathGUI();
            DrawPathUI();
            DrawFileUI();
            DrawOtherVars();
            UpdateArgs();
            DrawPathAndFileUI();
        }

        public virtual void DrawOtherVars() { }

        private void DrawPathAndFileUI() {
            EditorGUILayout.LabelField($"File will be saved as \"{args.GetFileNameAndPath()}\"");
        }

        private void DrawPathUI() {
            using (Disposables.VerticalScope(GUI.skin.box)) {
                EditorGUILayout.LabelField("Path");
                Owner.path = EditorGUILayout.TextField(Owner.path, GUILayout.ExpandWidth(true));
            }

            PathButtons();
        }

        private void DrawFileUI() {
            using (Disposables.VerticalScope(GUI.skin.box)) {
                EditorGUILayout.LabelField("File Name (Leave blank for name to be the date/time)");
                Owner.filename = EditorGUILayout.TextField(Owner.filename, GUILayout.ExpandWidth(true));
            }
        }

        private void DrawFilePathGUI() {
            using (Disposables.HorizontalScope())
                GUILayout.Label("Save Path", EditorStyles.boldLabel);

            EditorGUILayout.TextField(Owner.path, GUILayout.ExpandWidth(true));
            PathButtons();
        }

        private void PathButtons() {
            using (Disposables.HorizontalScope()) {
                if (GUILayout.Button("Browse"))
                    Owner.path = EditorUtility.SaveFolderPanel("Path to Save Images", Owner.path, Application.dataPath);

                if (GUILayout.Button("Default", GUILayout.Width(120)))
                    Owner.path = Owner.defaultPath;
            }
        }

        private void DrawScale() {
            Owner.scale = EditorGUILayout.IntSlider("Scale", Owner.scale, 0, 8);
        }

        private void DrawTakeImageGUI() {
            using (Disposables.DisabledScope(!Application.isPlaying)) {
                if (GUILayout.Button("Take Screenshot", GUILayout.MinHeight(40))) {
                    if (Owner.path == "") {
                        Owner.path = EditorUtility.SaveFolderPanel("Path to Save Images", Owner.path, Application.persistentDataPath);
                        Debug.Log("Path Set");
                        TakeScreenShot();
                    }
                    else
                        TakeScreenShot();
                }
            }

            if (GUILayout.Button("Open Folder", GUILayout.MaxWidth(100), GUILayout.MinHeight(40))) {
                //Application.OpenURL("file://" + Owner.path);
                Application.OpenURL("file://" + Owner.path);
            }
        }

        protected virtual void TakeScreenShot() {
            BuildArgs();
            Unity.ScreenCap.ScreenCap.TakeScreenShot(args);
        }

        private void BuildArgs() {
            args = new ScreenShotArgs { fileName = Owner.filename, Path = Owner.path, ResolutionMultiplier = Owner.scale };
        }

        private void UpdateArgs() {
            if (args == null)
                BuildArgs();

            args.fileName             = Owner.filename;
            args.Path                 = Owner.path;
            args.ResolutionMultiplier = Owner.scale;
        }
    }
}