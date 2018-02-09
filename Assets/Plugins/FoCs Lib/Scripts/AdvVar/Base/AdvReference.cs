using System;
using ForestOfChaosLib.CSharpExtensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	public class AdvReference<T> : AdvReference
	{
		[SerializeField] protected T _value;

		private Action onBeforeValueChange = () => {};
		private Action onValueChange = () => { };

		public Action OnBeforeValueChange
		{
			get
			{
				return onBeforeValueChange ??
					   (onBeforeValueChange = () =>
							   { });
			}
			set
			{
				onBeforeValueChange = value;
			}
		}

		public Action OnValueChange
		{
			get
			{
				return onValueChange ??
					   (onValueChange = () =>
							   { });
			}
			set
			{
				onValueChange = value;
			}
		}

		public T Value
		{
			get { return _value; }
			set
			{
				OnBeforeValueChange.Trigger();
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