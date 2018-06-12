using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvReference<T>: AdvReference
	{
		[SerializeField] protected T value;

		public T Value
		{
			get { return value; }
			set
			{
				this.value = value;
				OnValueChange.Trigger();
			}
		}
	}

	/// <summary>
	///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvReference: FoCsScriptableObject
	{
		public Action OnValueChange;
	}
}
