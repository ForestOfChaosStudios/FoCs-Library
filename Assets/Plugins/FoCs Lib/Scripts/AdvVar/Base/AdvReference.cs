using System;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.CSharpExtensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvReference<T> : AdvReference
	{
		[SerializeField] [GetSetter("Value")] protected T _value;

		public Action OnValueChange = () => { };

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
	{ }
}