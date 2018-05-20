using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public class GUIEvent
		{
			public Event Event;
			public Rect Rect;

			public bool EventOccurredInRect => Rect.Contains(Event.mousePosition);

			public bool LeftClick => EventIsMouse0InRect;

			public bool RightClick => EventIsMouse1InRect;

			public bool EventIsMouse0 => (Event.type == EventType.MouseUp) && (Event.button == 0);

			public bool EventIsMouse1 => (Event.type == EventType.MouseUp) && (Event.button == 1);

			public bool EventIsMouse0InRect => EventIsMouse0 && EventOccurredInRect;

			public bool EventIsMouse1InRect => EventIsMouse1 && EventOccurredInRect;

			public bool Pressed => this;

			public static implicit operator bool(GUIEvent input)
			{
				return input.EventIsMouse0InRect;
			}

			public static implicit operator Event(GUIEvent input) => input.Event;

			public static implicit operator Rect(GUIEvent input) => input.Rect;

			public static GUIEvent Create()
			{
				var data = new GUIEvent
						   {
							   Event = new Event(Event.current)
						   };

				if(data.Event.type == EventType.repaint)
					data.Rect = GUILayoutUtility.GetLastRect();
				return data;
			}

			public static GUIEvent Create(Rect rect)
			{
				var data = new GUIEvent
						   {
							   Event = new Event(Event.current)
						   };
				return data;
			}

			public static GUIEvent<T> Create<T>(T val)
			{
				var data = new GUIEvent<T>
						   {
							   Event = new Event(Event.current),
							   Value = val
						   };

				if(data.Event.type == EventType.repaint)
					data.Rect = GUILayoutUtility.GetLastRect();
				return data;
			}

			public static GUIEvent<T> Create<T>(Rect rect, T val)
			{
				var data = new GUIEvent<T>
						   {
							   Event = new Event(Event.current),
							   Rect = rect,
							   Value = val
						   };
				return data;
			}
		}

		public class GUIEvent<T>: GUIEvent
		{
			public T Value;
		}
	}
}