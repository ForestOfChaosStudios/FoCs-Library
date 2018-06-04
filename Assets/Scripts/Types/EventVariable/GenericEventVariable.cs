using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.Types.EventVariable
{
	[Serializable]
	public class GenericEventVariable<T>
	{
		[SerializeField] private T data;

		public T Data
		{
			get { return data; }
			set
			{
				OnBeforeChange.Trigger(data);
				data = value;
				OnChange.Trigger(data);
			}
		}

		public GenericEventVariable() { }

		public GenericEventVariable(T data)
		{
			this.data = data;
		}

		public event Action<T> OnBeforeChange;
		public event Action<T> OnChange;
		public static implicit operator T(GenericEventVariable<T> input) => input.Data;
	}
}
