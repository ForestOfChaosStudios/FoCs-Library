using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLibrary.Components.Camera
{
	[AddComponentMenu(FoCsStrings.COMPONENTS_CAMERA_FOLDER_ + "Turn On Depth Buffer")]
	public class TurnOnDepthBuffer: FoCsBehaviour
	{
		public void Start()
		{
			UCamera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}
}
