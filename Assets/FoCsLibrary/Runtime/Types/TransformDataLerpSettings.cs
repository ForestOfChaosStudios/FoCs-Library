using System;

namespace ForestOfChaosLibrary.Types
{
	[Serializable]
	public struct TransformDataLerpSettings
	{
		public ModeSetting UsePosition;
		public ModeSetting UseRotation;
		public ModeSetting UseScale;

		public TransformDataLerpSettings(ModeSetting usePosition = ModeSetting.Use, ModeSetting useRotation = ModeSetting.Use, ModeSetting useScale = ModeSetting.Use)
		{
			UsePosition = usePosition;
			UseRotation = useRotation;
			UseScale    = useScale;
		}

		public static TransformDataLerpSettings Default => new TransformDataLerpSettings {UsePosition = ModeSetting.Use, UseRotation = ModeSetting.Use, UseScale = ModeSetting.Use};

		public enum ModeSetting
		{
			Use,
			Left,
			Right
		}
	}
}
