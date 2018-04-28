using System;
using ForestOfChaosLib.CSharpExtensions;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	[Serializable]
	public class AdvVariable<T, aT>: AdvVariable
		where aT: AdvReference<T>
	{
		/*[GetSetter("Value")] */[SerializeField] private T ConstantValue;
		/*[GetSetter("Value")] */[SerializeField] private aT Variable;

		public T Value
		{
			get
			{
				if(UseConstant)
					return ConstantValue;
				return Variable.Value;
			}
			set
			{
				if(UseConstant)
					ConstantValue = value;
				else
					Variable.Value = value;
				OnValueChange.Trigger();
			}
		}

		public AdvVariable()
		{ }

		public AdvVariable(T constantValue)
		{
			ConstantValue = constantValue;
			UseConstant = true;
		}

		public AdvVariable(aT variable)
		{
			Variable = variable;
			UseConstant = false;
		}

		public AdvVariable(T constantValue, aT variable, bool useConstant = false)
		{
			ConstantValue = constantValue;
			Variable = variable;
			UseConstant = useConstant;
		}

		public static implicit operator T(AdvVariable<T, aT> input) => input.Value;


		private AdvVariableInternals _InternalData;
		public AdvVariableInternals InternalData => _InternalData ?? (_InternalData = new AdvVariableInternals(this));

		public class AdvVariableInternals
		{
			private readonly AdvVariable<T, aT> classRef;

			public AdvVariableInternals(AdvVariable<T, aT> _classRef)
			{
				classRef = _classRef;
			}

			public aT GlobalVariable
			{
				get { return classRef.Variable; }
				set { classRef.Variable = value; }
			}

			public T ConstantValue
			{
				get { return classRef.ConstantValue; }
				set { classRef.ConstantValue = value; }
			}
		}
	}

	/// <summary>
	///     This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvVariable
	{
		public Action OnValueChange;
		public bool UseConstant;
	}
}