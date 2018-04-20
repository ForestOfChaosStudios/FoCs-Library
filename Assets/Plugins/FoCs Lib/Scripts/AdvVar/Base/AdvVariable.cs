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
				return UseConstant?
					ConstantValue :
					Variable.Value;
			}
			set
			{
				if(UseConstant)
					ConstantValue = value;
				else
					Variable.Value = value;
				OnValueChange.Trigger();
				//AdvDebug.AdvDebug.Log("OnValueChange: " + typeof(T),value.ToString());
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