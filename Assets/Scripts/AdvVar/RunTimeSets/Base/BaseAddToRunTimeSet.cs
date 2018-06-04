namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public abstract class BaseAddToRunTimeSet<T, RT_T>: FoCsBehavior where RT_T: RunTimeList<T>
	{
		public          RT_T Set;
		public abstract T    Value { get; }

		public void OnEnable()
		{
			if(Set)
				Set.Add(Value);
		}

		public void OnDisable()
		{
			if(Set)
				Set.Remove(Value);
		}
	}
}
