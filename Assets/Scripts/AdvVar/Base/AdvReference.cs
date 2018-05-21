using System;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvReference<T>: AdvReference
	{
		[SerializeField] [GetSetter("Value")] protected T _value;

		public T Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnValueChange.Trigger();
			}
		}
	}

	public class AdvReferenceNoGetSetter<T>: AdvReference
	{
		[SerializeField] protected T _value;

		public T Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnValueChange.Trigger();
			}
		}
	}

	/// <summary>
	/// This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvReference: FoCsScriptableObject
	{
		public Action OnValueChange;
	}
}