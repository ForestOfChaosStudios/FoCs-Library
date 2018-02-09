using UnityEngine;

namespace ForestOfChaosLib.Editor.ImGUI
{
	public struct FoCsGUIEvent
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

		public static implicit operator bool(FoCsGUIEvent input)
		{
			if(input.ForcePressed.HasValue)
				return input.ForcePressed.Value;
			return input.EventIsMouse0InRect;
		}

		public static implicit operator Event(FoCsGUIEvent input) => input.Event;

		public static implicit operator Rect(FoCsGUIEvent input) => input.Rect;

		public static FoCsGUIEvent Create()
		{
			var data = new FoCsGUIEvent
					   {
						   Event = new Event(Event.current),
						   ForcePressed = null
					   };

			if(data.Event.type == EventType.repaint)
				data.Rect = GUILayoutUtility.GetLastRect();
			return data;
		}

		public static FoCsGUIEvent Create(Rect rect)
		{
			var data = new FoCsGUIEvent
					   {
						   Event = new Event(Event.current),
						   ForcePressed = null
					   };
			if(data.Event.type == EventType.repaint)
				data.Rect = GUILayoutUtility.GetLastRect();
			return data;
		}

		public static FoCsGUIEvent Create(bool pressed)
		{
			var data = new FoCsGUIEvent
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