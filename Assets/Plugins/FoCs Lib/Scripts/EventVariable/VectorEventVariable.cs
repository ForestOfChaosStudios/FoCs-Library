﻿using System;
using UnityEngine;

namespace ForestOfChaosLib.EventVariable
{
	[Serializable]
	public class Vector2EventVariable: GenericEventVariable<Vector2>
	{
		public Vector2EventVariable(): this(Vector2.zero)
		{ }

		public Vector2EventVariable(Vector2 data): base(data)
		{ }

		public static implicit operator Vector2EventVariable(Vector2 input)
		{
			return new Vector2EventVariable(input);
		}
	}

	[Serializable]
	public class Vector3EventVariable: GenericEventVariable<Vector3>
	{
		public Vector3EventVariable(): this(Vector3.zero)
		{ }

		public Vector3EventVariable(Vector3 data): base(data)
		{ }

		public static implicit operator Vector3EventVariable(Vector3 input)
		{
			return new Vector3EventVariable(input);
		}
	}

	[Serializable]
	public class Vector4EventVariable: GenericEventVariable<Vector4>
	{
		public Vector4EventVariable(): this(Vector4.zero)
		{ }

		public Vector4EventVariable(Vector4 data): base(data)
		{ }

		public static implicit operator Vector4EventVariable(Vector4 input)
		{
			return new Vector4EventVariable(input);
		}
	}

	[Serializable]
	public class QuaternionEventVariable: GenericEventVariable<Quaternion>
	{
		public QuaternionEventVariable(): this(Quaternion.identity)
		{ }

		public QuaternionEventVariable(Quaternion data): base(data)
		{ }

		public static implicit operator QuaternionEventVariable(Quaternion input)
		{
			return new QuaternionEventVariable(input);
		}
	}
}