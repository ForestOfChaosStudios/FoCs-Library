using System;
using ForestOfChaosLib.Extensions;

namespace ForestOfChaosLib.Components.Syncs
{
	public class GameObjectStateEvents: FoCsBehaviour
	{
		public Action OnEnabled;
		public Action OnDisabled;
		public Action OnDestroyed;

        private void OnEnable()
		{
			OnEnabled.Trigger();
        }

		private void OnDisable()
		{
			OnDisabled.Trigger();
        }

		private void OnDestroy()
		{
			OnDestroyed.Trigger();
		}
	}
}