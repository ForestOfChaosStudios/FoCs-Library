using System;
using ForestOfChaosLib.CSharpExtensions;

namespace ForestOfChaosLib.AdvVar.RuntimeRef
{
	public abstract class RunTimeRef<T>: RunTimeRef
	{
		private Action onBeforeValueChange = () => { };

		private Action onValueChange = () => { };

		public Action OnBeforeValueChange
		{
			get
			{
				return onBeforeValueChange ??
					   (onBeforeValueChange = () =>
							   { });
			}
			//set { onBeforeValueChange = value; }
		}

		public Action OnValueChange
		{
			get
			{
				return onValueChange ??
					   (onValueChange = () =>
							   { });
			}
			//set { onValueChange = value; }
		}

		private T reference;

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

		protected virtual void OnEnable()
		{
			if(onValueChange == null)
				onValueChange = () => { };
			if(onBeforeValueChange == null)
				onBeforeValueChange = () => { };
		}

		public override bool HasReference => reference != null;
	}

	public abstract class RunTimeRef: FoCsScriptableObject
	{
		public abstract bool HasReference { get; }
	}
}