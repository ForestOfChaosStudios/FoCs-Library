#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: FoCsGUIEvent.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:03 AM
#endregion


using UnityEngine;

namespace ForestOfChaos.Unity.Editor {
    // ReSharper disable once MismatchedFileName
    public static partial class FoCsGUI {
        public class GUIEvent {
            public Event Event;
            public Rect  Rect;

            public bool EventOccurredInRect => Rect.Contains(Event.mousePosition);

            public bool EventIsMouseL => (Event.type == EventType.MouseUp) && (Event.button == 0);

            public bool EventIsMouseR => (Event.type == EventType.MouseUp) && (Event.button == 1);

            public bool EventIsMouseLInRect => EventIsMouseL && EventOccurredInRect;

            public bool EventIsMouseRInRect => EventIsMouseR && EventOccurredInRect;

            public virtual bool Pressed => EventIsMouseLInRect;

            public static implicit operator Event(GUIEvent input) => input.Event;

            public static implicit operator Rect(GUIEvent input) => input.Rect;

            public static GUIEvent Create() {
                var data = new GUIEvent {Event = new Event(Event.current)};
                data.Rect = GUILayoutUtility.GetLastRect();

                return data;
            }

            public static GUIEvent Create(Rect rect) {
                var data = new GUIEvent {Event = new Event(Event.current)};

                return data;
            }

            public static GUIEvent<T> Create<T>(T val) {
                var data = new GUIEvent<T> {Event = new Event(Event.current), Value = val};
                data.Rect = GUILayoutUtility.GetLastRect();

                return data;
            }

            public static GUIEvent<T> Create<T>(Rect rect, T val) {
                var data = new GUIEvent<T> {Event = new Event(Event.current), Rect = rect, Value = val};

                return data;
            }

            public static GUIEventBool Create(bool val) {
                var data = new GUIEventBool {Event = new Event(Event.current), Value = val};
                data.Rect = GUILayoutUtility.GetLastRect();

                return data;
            }

            public static GUIEventBool Create(Rect rect, bool val) {
                var data = new GUIEventBool {Event = new Event(Event.current), Rect = rect, Value = val};

                return data;
            }
        }

        public class GUIEvent<T>: GUIEvent {
            public T Value;

            public static implicit operator T(GUIEvent<T> input) => input.Value;
        }

        public class GUIEventBool: GUIEvent<bool> {
            /// <inheritdoc />
            public override bool Pressed => Value;
        }
    }
}