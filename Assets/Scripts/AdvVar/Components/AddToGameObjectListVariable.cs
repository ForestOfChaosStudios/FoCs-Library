namespace ForestOfChaosLib.AdvVar.Components
{
	public class AddToGameObjectListVariable: FoCsBehavior
	{
		public GameObjectListReference GameObjectListReference;

		public void OnEnable()
		{
			if(GameObjectListReference) GameObjectListReference.Add(gameObject);
		}

		public void OnDisable()
		{
			if(GameObjectListReference) GameObjectListReference.Remove(gameObject);
		}
	}
}