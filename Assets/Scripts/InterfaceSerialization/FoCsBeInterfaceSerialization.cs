using UnityEngine;

namespace ForestOfChaosLib.Base.HiddenClasses
{
	public partial class FoCsBe: MonoBehaviour, ISerializationCallbackReceiver
	{
		/// <inheritdoc />
		public void OnBeforeSerialize()
		{
			if(!HasSerializedInterfaces)
				return;

			Debug.Log($"OnBeforeSerialize({GetType().Name})");
		}

		/// <inheritdoc />
		public void OnAfterDeserialize()
		{
			if(!HasSerializedInterfaces)
				return;

			Debug.Log($"OnAfterDeserialize({GetType().Name})");

		}

		protected virtual bool HasSerializedInterfaces => false;
	}
}