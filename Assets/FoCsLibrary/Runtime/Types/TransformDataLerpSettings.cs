﻿#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TransformDataLerpSettings.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;

namespace ForestOfChaos.Unity.Types {
    [Serializable]
    public struct TransformDataLerpSettings {
        public ModeSetting UsePosition;
        public ModeSetting UseRotation;
        public ModeSetting UseScale;

        public TransformDataLerpSettings(ModeSetting usePosition = ModeSetting.Use, ModeSetting useRotation = ModeSetting.Use, ModeSetting useScale = ModeSetting.Use) {
            UsePosition = usePosition;
            UseRotation = useRotation;
            UseScale    = useScale;
        }

        public static TransformDataLerpSettings Default => new TransformDataLerpSettings {UsePosition = ModeSetting.Use, UseRotation = ModeSetting.Use, UseScale = ModeSetting.Use};

        public enum ModeSetting {
            Use,
            Left,
            Right
        }
    }
}