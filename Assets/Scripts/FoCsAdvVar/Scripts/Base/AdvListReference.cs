using System;
using System.Collections.Generic;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosAdvVar.Base
{
	public class AdvListReference<T>: AdvListReference
	{
		[SerializeField] private List<T>   _value;
		[NonSerialized]  public  Action<T> OnValueAdded;
		[NonSerialized]  public  Action    OnValueChange;
		[NonSerialized]  public  Action<T> OnValueRemoved;

		public List<T> Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnValueChange.Trigger();
			}
		}

		public void Add(T value)
		{
			Value.Add(value);
			OnValueAdded.Trigger(value);
		}

		public bool Contains(T value) => Value.Contains(value);

		public void Remove(T value)
		{
			Value.Remove(value);
			OnValueRemoved.Trigger(value);
		}
	}

	/// <summary>
	///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvListReference: ScriptableObject { }
}
