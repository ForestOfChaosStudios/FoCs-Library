#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsWindow.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using UnityEditor;

namespace ForestOfChaos.Unity.Editor.Windows {
    /// <inheritdoc />
    /// <summary>
    ///     [MenuItem("Tools/Forest Of Chaos/Example Window")]
    ///     private static void Init(){
    ///     GetWindowAndOpenTab();
    ///     }
    /// </summary>
    /// <typeparam name="TWindow">Class name of type that inherits directly from this class, for a static ref to its self</typeparam>
    public abstract class FoCsWindow<TWindow>: FoCsWindow where TWindow: FoCsWindow, IRepaintable {
        private static TWindow window;

        protected static TWindow Window => window? window : window = GetWindow();

        public static TWindow CreateInstance()   => CreateInstance<TWindow>();

        public static TWindow FindObjectOfType() => FindObjectOfType<TWindow>();

        protected static TWindow GetWindow() {
            if (window != null)
                return window;

            window = FindObjectOfType() ?? CreateInstance();

            return window;
        }

        protected static TWindow GetWindowAndShow() {
            GetWindow();
            window.Show();
            window.Focus();

            return window;
        }

        protected static TWindow GetWindowAndOpenUtility() {
            GetWindow();
            window.ShowUtility();
            window.Focus();

            return window;
        }
    }

    public abstract class FoCsWindow: EditorWindow, IRepaintable {
        protected abstract void OnGUI();

        public static void DrawSpace() {
            FoCsGUI.Layout.Space();
        }

        public static void DrawSpace(int count) {
            for (var i = 0; i < count; i++)
                FoCsGUI.Layout.Space();
        }

        public static void DrawSpace(float size) {
            FoCsGUI.Layout.Space(size);
        }
    }
}