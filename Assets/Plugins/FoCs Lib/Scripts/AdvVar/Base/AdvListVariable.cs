using System;
using System.Collections.Generic;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.CSharpExtensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvListReference<T>: AdvListReference
	{
		[SerializeField]
		[NoFoldout]
		private List<T> _value;

		private List<T> _startValue;

		public List<T> Value
		{
			get { return _value; }
			set
			{
				OnBeforeValueChange.Trigger();
				_value = value;
				OnValueChange.Trigger();
			}
		}

		[NonSerialized]
		public Action OnBeforeValueChange;

		[NonSerialized]
		public Action OnValueChange;

		protected void OnEnable()
		{
			_startValue = _value;
		}

		protected void OnDisable()
		{
			_value = _startValue;
		}

		public void Add(T value)
		{
			Value.Add(value);
		}

		public bool Contains(T value)
		{
			return Value.Contains(value);
		}

		public void Remove(T value)
		{
			Value.Remove(value);
		}
	}

	/// <summary>
	/// This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvListReference
	{ }
}