using System;
using ForestOfChaosLib.Attributes;
using ForestOfChaosLib.Extensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	[Serializable]
	public class AdvVariable<T, aT>: AdvVariable where aT: AdvReference<T>
	{
		private                  AdvVariableInternals internalData;
		[SerializeField] private T                    LocalValue;
		[SerializeField] private aT                   Reference;

		public T Value
		{
			get
			{
				if(UseLocal)
					return LocalValue;

				if(Reference == null)
					throw new AdvVariableReferenceMissingError();

				return Reference.Value;
			}
			set
			{
				if(UseLocal)
					LocalValue = value;
				else
					Reference.Value = value;

				OnValueChange.Trigger();
			}
		}

		public AdvVariableInternals InternalData => internalData ?? (internalData = new AdvVariableInternals(this));
		public AdvVariable() { }

		public AdvVariable(T localValue)
		{
			LocalValue = localValue;
			UseLocal   = true;
		}

		public AdvVariable(aT reference)
		{
			Reference = reference;
			UseLocal  = false;
		}

		public AdvVariable(T localValue, aT reference, bool useLocal = false)
		{
			LocalValue = localValue;
			Reference  = reference;
			UseLocal   = useLocal;
		}

		public static implicit operator T(AdvVariable<T, aT> input) => input.Value;

		public class AdvVariableInternals
		{
			private readonly AdvVariable<T, aT> classRef;

			public aT GlobalReference
			{
				get { return classRef.Reference; }
				set { classRef.Reference = value; }
			}

			public T LocalValue
			{
				get { return classRef.LocalValue; }
				set { classRef.LocalValue = value; }
			}

			public AdvVariableInternals(AdvVariable<T, aT> _classRef)
			{
				classRef = _classRef;
			}
		}

		public class AdvVariableReferenceMissingError: Exception
		{
			public AdvVariableReferenceMissingError(): base($"Missing Reference of {typeof(aT)}, Set to Local, or add reference.") { }
		}
	}

	/// <summary>
	///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvVariable
	{
		public Action OnValueChange;
		public bool   UseLocal;
	}
}
