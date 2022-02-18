#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsTab.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

namespace ForestOfChaos.Unity.Editor.Windows {
    public abstract class FoCsTab<T> where T: FoCsWindow {
        public abstract string TabName { get; }

        public abstract void DrawTab(FoCsWindow<T> owner);
    }
}