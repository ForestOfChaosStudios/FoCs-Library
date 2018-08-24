using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef
{
	public abstract class RunTimeRef<T>: RunTimeRef
	{
		public  Action OnBeforeValueChange = () => { };
		public  Action OnValueChange       = () => { };
		private T      reference;
		public T Reference
		{
			get { return reference; }
			set
			{
				OnBeforeValueChange.Trigger();
				reference = value;
				OnValueChange.Trigger();
			}
		}
		public override bool HasReference => reference != null;
	}

	public abstract class RunTimeRef: ScriptableObject
	{
		public abstract bool HasReference { get; }
	}
}