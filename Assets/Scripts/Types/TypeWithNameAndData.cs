using System;
using ForestOfChaosLib.Extensions;

namespace ForestOfChaosLib.Types
{
	[Serializable]
	public static class TypeWithNameAndData
	{
		[Serializable]
		public abstract class BaseGenericType
		{
			public string Name;

			protected BaseGenericType(string name = "")
			{
				Name = name;
			}

			public virtual void SetData(object obj) { }
			public override string ToString() => Name;
			public virtual string GetDataString() => "";
		}

		[Serializable]
		public class GenericType<T>: BaseGenericType
		{
			private                T            _data;
			[NonSerialized] public Action       OnAfterDataChange;
			[NonSerialized] public Action       OnBeforeDataChange;
			[NonSerialized] public Action<T, T> OnDataChangeOldNewValue;

			public T Data
			{
				get { return _data; }
				set
				{
					OnDataChangeOldNewValue.Trigger(_data, value);
					OnBeforeDataChange.Trigger();
					_data = value;
					OnAfterDataChange.Trigger();
				}
			}

			public GenericType(string name = ""): base(name)
			{
				Data = default(T);
			}

			public GenericType(string name, T d): base(name)
			{
				Name = name;
				Data = d;
			}

			public override void SetData(object obj)
			{
				Data = (T)obj;
			}

			public static implicit operator T(GenericType<T> input) => input.Data;
			public virtual T GetTypeFromString(string        data) => default(T);
			public override string ToString() => ToString(false);

			public string ToString(bool b)
			{
				if(b)
					return Name + " : (" + typeof(T) + ")" + Data;

				return Name + " : " + Data;
			}

			public override string GetDataString() => Data.ToString();
		}

		[Serializable]
		public class StringType: GenericType<string>
		{
			public StringType(string                        name = ""): base(name) { }
			public StringType(string                        name, string d): base(name, d) { }
			public override string GetTypeFromString(string data) => data;

			public override void SetData(object obj)
			{
				Data = obj.ToString();
			}
		}

		[Serializable]
		public class IntType: GenericType<int>
		{
			public IntType(string name = ""): base(name) { }
			public IntType(string name, int d): base(name, d) { }

			public override int GetTypeFromString(string data)
			{
				int num;
				int.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}

		[Serializable]
		public class Int32Type: GenericType<int>
		{
			public Int32Type(string name = ""): base(name) { }
			public Int32Type(string name, int d): base(name, d) { }

			public override int GetTypeFromString(string data)
			{
				int num;
				int.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}

		[Serializable]
		public class Int64Type: GenericType<long>
		{
			public Int64Type(string name = ""): base(name) { }
			public Int64Type(string name, long d): base(name, d) { }

			public override long GetTypeFromString(string data)
			{
				long num;
				long.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}

		[Serializable]
		public class FloatType: GenericType<float>
		{
			public FloatType(string name = ""): base(name) { }
			public FloatType(string name, float d): base(name, d) { }

			public override float GetTypeFromString(string data)
			{
				float num;
				float.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}

		[Serializable]
		public class BoolType: GenericType<bool>
		{
			public BoolType(string name = ""): base(name) { }
			public BoolType(string name, bool d): base(name, d) { }

			public override bool GetTypeFromString(string data)
			{
				bool num;
				bool.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}

		[Serializable]
		public class ByteType: GenericType<byte>
		{
			public ByteType(string name = ""): base(name) { }
			public ByteType(string name, byte d): base(name, d) { }

			public override byte GetTypeFromString(string data)
			{
				byte num;
				byte.TryParse(data, out num);

				return num;
			}

			public override void SetData(object obj)
			{
				Data = GetTypeFromString(obj.ToString());
			}
		}
	}
}
