#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsTab.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:11 PM
#endregion

namespace ForestOfChaos.Unity.Editor.Windows {
    public abstract class FoCsTab<T> where T: FoCsWindow {
        public abstract string TabName { get; }

        public abstract void DrawTab(FoCsWindow<T> owner);
    }
}