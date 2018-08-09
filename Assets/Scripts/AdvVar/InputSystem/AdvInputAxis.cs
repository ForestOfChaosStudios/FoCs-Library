using System;
using ForestOfChaosLib.AdvVar.Base;
using ForestOfChaosLib.InputManager;
using ForestOfChaosLib.Utilities;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.InputSystem
{
	[CreateAssetMenu(fileName = "Input Axis Variable", menuName = "ADV Variables/Input Axis", order = 2)]
	[Serializable]
	[AdvFolderNameForestOfChaos]
	public class AdvInputAxis: AdvReference<InputAxis>
	{
		public bool OnlyButtonEvents
		{
			get { return Value.OnlyButtonEvents; }
			set { Value.OnlyButtonEvents = value; }
		}
		public bool ValueInverted
		{
			get { return Value.ValueInverted; }
			set { Value.ValueInverted = value; }
		}
		public KeyPosition KeyPos
		{
			get { return Value.KeyPos; }
			set { Value.KeyPos = value; }
		}
		public Action OnKeyDown
		{
			get { return Value.OnKeyDown; }
			set { Value.OnKeyDown = value; }
		}
		public Action OnKeyUp
		{
			get { return Value.OnKeyUp; }
			set { Value.OnKeyUp = value; }
		}
		public Action OnKeyPositiveDown
		{
			get { return Value.OnKeyPositiveDown; }
			set { Value.OnKeyPositiveDown = value; }
		}
		public Action OnKeyPositiveUp
		{
			get { return Value.OnKeyPositiveUp; }
			set { Value.OnKeyPositiveUp = value; }
		}
		public Action OnKeyNegativeDown
		{
			get { return Value.OnKeyNegativeDown; }
			set { Value.OnKeyNegativeDown = value; }
		}
		public Action OnKeyNegativeUp
		{
			get { return Value.OnKeyNegativeUp; }
			set { Value.OnKeyNegativeUp = value; }
		}
		public Action OnKeyNoValue
		{
			get { return Value.OnKeyNoValue; }
			set { Value.OnKeyNoValue = value; }
		}
		public Action<float> OnKey
		{
			get { return Value.OnKey; }
			set { Value.OnKey = value; }
		}
		public Action<float> OnKeyNoDeadZone
		{
			get { return Value.OnKeyNoDeadZone; }
			set { Value.OnKeyNoDeadZone = value; }
		}
		public bool InputInDeadZone()               => Value.InputInDeadZone();
		public bool InputInDeadZone(float deadZone) => Value.InputInDeadZone(deadZone);

		public void CallEvents()
		{
			Value.CallEvents();
		}

		public void CallEvents(float deadZone)
		{
			Value.CallEvents(deadZone);
		}

		public void UpdateData()
		{
			Value.UpdateData();
		}

		public void UpdateDataAndCallEvents()
		{
			Value.UpdateDataAndCallEvents();
		}

		public void UpdateDataAndCallEvents(float deadZone)
		{
			Value.UpdateDataAndCallEvents(deadZone);
		}

		public void CallEventsCustomValue(float key)
		{
			Value.CallEventsCustomValue(key);
		}

		public void CallEventsCustomValue(float key, float deadZone)
		{
			Value.CallEventsCustomValue(key, deadZone);
		}

		public static implicit operator float(AdvInputAxis input) => input.Value;

		public static implicit operator AdvInputAxis(string input)
		{
#if UNITY_EDITOR
			foreach(var axis in FoCsAssetFinder.FindAssetsByType<AdvInputAxis>())
			{
				if(axis.Value.Axis == input)
					return axis;
			}
#endif
			return null;
		}
	}
}