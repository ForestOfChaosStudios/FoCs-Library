using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.InputManager
{
	[Serializable]
	public class InputAxis
	{
		/// <summary>
		/// The Axis that the coder uses as Reference
		/// </summary>
		public string Axis;

		public float Value
		{
			get
			{
				return ValueInverted?
					m_Value :
					-m_Value;
			}
			set
			{
				m_Value = ValueInverted?
					value :
					-value;
			}
		}

		public float DeadZone
		{
			get { return m_DeadZone; }
			set { m_DeadZone = value; }
		}

		[SerializeField]
		private float m_Value;

		[SerializeField]
		private float m_DeadZone;

		public KeyPosition KeyPos = KeyPosition.Up;

		public bool ValueInverted;

		public bool OnlyButton = false;

		public Action OnKeyDown;
		public Action OnKeyUp;
		public Action OnKeyPositiveDown;
		public Action OnKeyPositiveUp;
		public Action OnKeyNegativeDown;
		public Action OnKeyNegativeUp;
		public Action OnKeyNoValue;
		public Action<float> OnKey;
		public Action<float> OnKeyNoDeadZone;

		public InputAxis(string axis, bool invert = false)
		{
			Axis = axis;
			ValueInverted = invert;
		}

		public static implicit operator float(InputAxis fp)
		{
			return fp.Value;
		}

		public static implicit operator string(InputAxis fp)
		{
			return fp.Axis;
		}

		public static implicit operator bool(InputAxis fp)
		{
			return fp.ValueInverted;
		}

		public static implicit operator InputAxis(string fp)
		{
			return new InputAxis(fp);
		}

		public bool InputInDeadZone()
		{
			return Math.Abs(Value) > m_DeadZone;
		}

		public bool InputInDeadZone(float deadZone)
		{
			return Math.Abs(Value) > deadZone;
		}

		public void CallEvents()
		{
			CallEvents(this, m_DeadZone);
		}

		public void CallEvents(float deadZone)
		{
			CallEvents(this, deadZone);
		}

		public void UpdateData()
		{
			m_Value = Input.GetAxis(Axis);
			if(Input.GetButtonUp(Axis))
				KeyPos = KeyPosition.Up;
			else if(Input.GetButtonDown(Axis))
				KeyPos = KeyPosition.Down;
			else if(Input.GetButton(Axis))
				KeyPos = KeyPosition.Held;
		}

		public void UpdateDataAndCallEvents()
		{
			UpdateData();
			CallEvents(this, m_DeadZone);
		}

		public void UpdateDataAndCallEvents(float deadZone)
		{
			UpdateData();
			CallEvents(this, deadZone);
		}

		public static void CallEvents(InputAxis key)
		{
			CallEvents(key, key.m_DeadZone);
		}

		public void CallEventsCustomValue(float key)
		{
			var tempVal = Value;
			Value = key;
			CallEvents(this, m_DeadZone);
			Value = tempVal;
		}

		public void CallEventsCustomValue(float key, float deadZone)
		{
			var tempVal = Value;
			Value = key;
			CallEvents(this, deadZone);
			Value = tempVal;
		}

		public static void CallEvents(InputAxis key, float deadZone)
		{
			if(key.OnlyButton)
			{
				switch(key.KeyPos)
				{
					case KeyPosition.Up:
						KeyUp(key);
						return;
					case KeyPosition.Down:
						KeyDown(key);
						return;
					case KeyPosition.Held:
						KeyHeld(key);
						return;
				}
				return;
			}

			if(Input.GetButtonUp(key))
				KeyUp(key);
			else if(Input.GetButtonDown(key))
				KeyDown(key);
			else if(Math.Abs(key.Value) > deadZone)
				KeyHeld(key);

			key.OnKeyNoDeadZone.Trigger(key.Value);

			if(key.InputInDeadZone())
				key.KeyPos = KeyPosition.None;
		}

		private static void KeyHeld(InputAxis key)
		{
			key.OnKey.Trigger(key.Value);
			key.OnKeyNoValue.Trigger();
		}

		private static void KeyDown(InputAxis key)
		{
			key.OnKeyDown.Trigger();

			if(key.Value > 0)
				key.OnKeyPositiveDown.Trigger();
			else if(key.Value < 0)
				key.OnKeyNegativeDown.Trigger();
		}

		private static void KeyUp(InputAxis key)
		{
			key.OnKeyUp.Trigger();

			if(key.Value > 0)
				key.OnKeyPositiveUp.Trigger();
			else if(key.Value < 0)
				key.OnKeyNegativeUp.Trigger();
		}
	}

	public enum KeyPosition
	{
		Up,
		Down,
		Held,
		None
	}
}