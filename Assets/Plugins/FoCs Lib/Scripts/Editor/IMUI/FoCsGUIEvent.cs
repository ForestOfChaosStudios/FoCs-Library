using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public struct GUIEvent
		{
			public Event Event;
			public Rect Rect;
			public bool? ForcePressed;

			public bool EventOccurredInRect => Rect.Contains(Event.mousePosition);

			public bool AsButtonLeftClick => EventIsMouse0InRect;

			public bool AsButtonRightClick => EventIsMouse1InRect;

			public bool EventIsMouse0 => (Event.type == EventType.MouseUp) && (Event.button == 0);

			public bool EventIsMouse1 => (Event.type == EventType.MouseUp) && (Event.button == 1);

			public bool EventIsMouse0InRect => EventIsMouse0 && EventOccurredInRect;

			public bool EventIsMouse1InRect => EventIsMouse1 && EventOccurredInRect;

			public static implicit operator bool(GUIEvent input)
			{
				if(input.ForcePressed.HasValue)
					return input.ForcePressed.Value;
				return input.EventIsMouse0InRect;
			}

			public static implicit operator Event(GUIEvent input) => input.Event;

			public static implicit operator Rect(GUIEvent input) => input.Rect;

			public static GUIEvent Create()
			{
				var data = new GUIEvent
						   {
							   Event = new Event(Event.current),
							   ForcePressed = null
						   };

				if(data.Event.type == EventType.repaint)
					data.Rect = GUILayoutUtility.GetLastRect();
				return data;
			}

			public static GUIEvent Create(Rect rect)
			{
				var data = new GUIEvent
						   {
							   Event = new Event(Event.current),
							   ForcePressed = null
						   };
				if(data.Event.type == EventType.repaint)
					data.Rect = GUILayoutUtility.GetLastRect();
				return data;
			}

			public static GUIEvent Create(bool pressed)
			{
				var data = new GUIEvent
						   {
							   Event = new Event(Event.current),
							   ForcePressed = pressed
						   };

				if(data.Event.type == EventType.repaint)
					data.Rect = GUILayoutUtility.GetLastRect();
				return data;
			}
		}
	}
}