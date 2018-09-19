using System;
using ForestOfChaosLibrary.Extensions;
using UnityEngine;

namespace ForestOfChaosLibrary.Components.Syncs
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_FOLDER_ + "GameObject State Events")]
	public class GameObjectStateEvents: FoCsBehaviour
	{
		public Action OnDestroyed;
		public Action OnDisabled;
		public Action OnEnabled;

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
