using ForestOfChaosLib.AdvVar.RuntimeRef;

namespace ForestOfChaosLib.AdvVar.RuntimeRef.Components
{
	public abstract class BaseAddToRTSet<T,RT_T>: FoCsBehavior where RT_T: RunTimeList<T>
	{
		public RT_T Set;

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

		public abstract T Value { get; }
	}
}