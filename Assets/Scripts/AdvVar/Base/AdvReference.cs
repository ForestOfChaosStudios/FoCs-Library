using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvReference<T>: AdvReference
	{
		[SerializeField] private T storedValue;
		protected virtual T InternalValue
		{
			get { return storedValue; }
			set { storedValue = value; }
		}
		public T Value
		{
			get { return InternalValue; }
			set
			{
				this.InternalValue = value;
				OnValueChange.Trigger();
			}
		}
	}

	/// <summary>
	///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvReference: ScriptableObject
	{
		public Action OnValueChange;
	}
}