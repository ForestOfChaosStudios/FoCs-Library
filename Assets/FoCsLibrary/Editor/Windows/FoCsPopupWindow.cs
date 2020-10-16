#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsPopupWindow.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

using System;
using ForestOfChaos.Unity.Extensions;

namespace ForestOfChaos.Unity.Editor.Windows {
    public class FoCsPopupWindow: FoCsWindow<FoCsPopupWindow> {
        private FoCsPopupWindowArguments currentArguments;

        private static void Init() {
            GetWindowAndOpenUtility();
        }

        public static void SetUpInstance(FoCsPopupWindowArguments Args) {
            Init();
            Window.titleContent.text       = Args.WindowTitle;
            Window.currentArguments        = Args;
            Window.currentArguments.Window = Window;

            if (Window.currentArguments.MinHeight != null) {
                var m = Window.minSize;
                m.y            = Window.currentArguments.MinHeight();
                Window.minSize = m;
            }

            if (Window.currentArguments.MinWidth != null) {
                var m = Window.minSize;
                m.x            = Window.currentArguments.MinWidth();
                Window.minSize = m;
            }

            if (Window.currentArguments.MaxHeight != null) {
                var m = Window.maxSize;
                m.y            = Window.currentArguments.MaxHeight();
                Window.maxSize = m;
            }

            if (Window.currentArguments.MaxWidth != null) {
                var m = Window.maxSize;
                m.x            = Window.currentArguments.MaxWidth();
                Window.maxSize = m;
            }
        }

        protected override void OnGUI() {
            if (currentArguments == null)
                return;

            Window.currentArguments.Window = Window;
            currentArguments.OnGUI.Trigger(currentArguments);
        }
    }

    public class FoCsPopupWindowArguments {
        public Func<float>                      MaxHeight;
        public Func<float>                      MaxWidth;
        public Func<float>                      MinHeight;
        public Func<float>                      MinWidth;
        public Action<FoCsPopupWindowArguments> OnClose;
        public Action<FoCsPopupWindowArguments> OnGUI;
        public FoCsPopupWindow                  Window;
        public string                           WindowTitle;
    }
}