#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.AdvVar
//       File: AnimatorKeyReference.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using ForestOfChaos.Unity.AdvVar.Base;
using ForestOfChaos.Unity.Animation;
using UnityEngine;

namespace ForestOfChaos.Unity.AdvVar {
    [Serializable]
    [AdvFolderNameForestOfChaos]
    public class AnimatorKeyReference: AdvReference<AnimatorKey> { }

    [Serializable]
    public class AnimatorKeyVariable: AdvVariable<AnimatorKey, AnimatorKeyReference> {
        public string Key {
            get => Value.Key;
            set => Value.Key = value;
        }

        public AnimatorKey.AnimType KeyType {
            get => Value.KeyType;
            set => Value.KeyType = value;
        }

        public int IntData {
            get => Value.IntData;
            set => Value.IntData = value;
        }

        public float FloatData {
            get => Value.FloatData;
            set => Value.FloatData = value;
        }

        public bool BoolData {
            get => Value.BoolData;
            set => Value.BoolData = value;
        }

        public bool TriggerData {
            get => Value.TriggerData;
            set => Value.TriggerData = value;
        }

        public static implicit operator AnimatorKeyVariable(AnimatorKey input) {
            var fR = new AnimatorKeyVariable {UseLocal = true, Value = input};

            return fR;
        }

        public void CalculateAnimator(Animator animator) {
            Value.CalculateAnimator(animator);
        }
    }
}