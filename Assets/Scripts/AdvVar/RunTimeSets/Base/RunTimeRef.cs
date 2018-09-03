using System;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.RuntimeRef
{
	public abstract class RunTimeRef<T>: RunTimeRef where T: class
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

		/// <inheritdoc />
		public override void EmptyReference()
		{
			Reference = null;
		}

		public override void FillReference(MonoBehaviour self)
		{
			Reference = self.GetComponent<T>();
		}
	}

	public abstract class RunTimeRef: ScriptableObject
	{
		public abstract bool HasReference { get; }
		public abstract void FillReference(MonoBehaviour self);
		public abstract void EmptyReference();
	}
}
