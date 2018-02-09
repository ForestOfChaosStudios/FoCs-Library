using ForestOfChaosLib.ScriptableObjects.Generic;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[CreateAssetMenu(fileName = "New Image Data SO", menuName = "SO/ImageData", order = 0)]
	public class ImageDataScriptableObject: GenericScriptableObject<ImageData>
	{
		[ContextMenu("Clear Array")]
		void OnDisable()
		{
			Data.Buffer = new byte[0];
		}
	}
}