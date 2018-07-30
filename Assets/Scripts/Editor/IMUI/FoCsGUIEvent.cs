using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public static partial class FoCsGUI
	{
		public class GUIEvent
		{
			public Event Event;
			public Rect  Rect;

			public bool EventOccurredInRect
			{
				get { return Rect.Contains(Event.mousePosition); }
			}

			public bool EventIsMouseL
			{
				get { return (Event.type == EventType.MouseUp) && (Event.button == 0); }
			}

			public bool EventIsMouseR
			{
				get { return (Event.type == EventType.MouseUp) && (Event.button == 1); }
			}

			public bool EventIsMouseLInRect
			{
				get { return EventIsMouseL && EventOccurredInRect; }
			}

			public bool EventIsMouseRInRect
			{
				get { return EventIsMouseR && EventOccurredInRect; }
			}

			public virtual bool Pressed
			{
				get { return EventIsMouseLInRect; }
			}

			public static implicit operator Event(GUIEvent input)
			{
				return input.Event;
			}

			public static implicit operator Rect(GUIEvent input)
			{
				return input.Rect;
			}

			public static GUIEvent Create()
			{
				var data = new GUIEvent {Event = new Event(Event.current)};

				//if(data.Event.type == EventType.Repaint)
				data.Rect = GUILayoutUtility.GetLastRect();

				return data;
			}

			public static GUIEvent Create(Rect rect)
			{
				var data = new GUIEvent {Event = new Event(Event.current)};

				return data;
			}

			public static GUIEvent<T> Create<T>(T val)
			{
				var data = new GUIEvent<T> {Event = new Event(Event.current), Value = val};

				//if(data.Event.type == EventType.Repaint)
				data.Rect = GUILayoutUtility.GetLastRect();

				return data;
			}

			public static GUIEvent<T> Create<T>(Rect rect, T val)
			{
				var data = new GUIEvent<T> {Event = new Event(Event.current), Rect = rect, Value = val};

				return data;
			}

			public static GUIEventBool Create(bool val)
			{
				var data = new GUIEventBool {Event = new Event(Event.current), Value = val};

				//if(data.Event.type == EventType.Repaint)
				data.Rect = GUILayoutUtility.GetLastRect();

				return data;
			}

			public static GUIEventBool Create(Rect rect, bool val)
			{
				var data = new GUIEventBool {Event = new Event(Event.current), Rect = rect, Value = val};

				return data;
			}
		}

		public class GUIEvent<T>: GUIEvent
		{
			public T Value;

			public static implicit operator T(GUIEvent<T> input)
			{
				return input.Value;
			}
		}

		public class GUIEventBool: GUIEvent<bool>
		{
			/// <inheritdoc />
			public override bool Pressed
			{
				get { return Value; }
			}
		}
	}
}
