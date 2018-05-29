using System;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar.Base
{
	[Serializable]
	public class AdvListVariable<T, aT>: AdvListVariable where aT: AdvListReference<T>
	{
		public                   bool    UseConstant = true;
		[SerializeField] private List<T> ConstantValue;
		[SerializeField] private aT      Variable;
		public                   List<T> Value => UseConstant? ConstantValue : Variable.Value;
	}

	/// <summary>
	/// This is a base class so that as Unity needs a none generic base class for editors/property drawers
	/// </summary>
	public class AdvListVariable { }
}