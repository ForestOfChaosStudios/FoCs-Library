#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: AnimatorKey.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaosLibrary.Animation {
    [Serializable]
    public class AnimatorKey {
        public enum AnimType {
            Int,
            Float,
            Bool,
            Trigger
        }

        public bool     BoolData;
        public float    FloatData;
        public int      IntData;
        public string   Key;
        public AnimType KeyType;
        public bool     TriggerData;

        private AnimatorKey(string key, AnimType keyType, int intData, float floatData, bool boolData, bool triggerData) {
            Key         = key;
            KeyType     = keyType;
            IntData     = intData;
            FloatData   = floatData;
            BoolData    = boolData;
            TriggerData = triggerData;
        }

        public AnimatorKey(int intData, string key = ""): this(key, AnimType.Int, intData, 0, false, false) { }

        public AnimatorKey(float floatData, string key = ""): this(key, AnimType.Float, 0, floatData, false, false) { }

        public AnimatorKey(bool boolData, string key = ""): this(key, AnimType.Bool, 0, 0, boolData, false) { }

        public AnimatorKey(string key = ""): this(key, AnimType.Trigger, 0, 0, false, true) { }

        public AnimatorKey CalculateAnimator(Animator animator) {
            if (animator == null)
                return this;

            switch (KeyType) {
                case AnimType.Int:
                    animator.SetInteger(Key, IntData);

                    break;
                case AnimType.Float:
                    animator.SetFloat(Key, FloatData);

                    break;
                case AnimType.Bool:
                    animator.SetBool(Key, BoolData);

                    break;
                case AnimType.Trigger:

                    if (TriggerData) {
                        TriggerData = false;
                        animator.SetTrigger(Key);
                    }

                    break;
            }

            return this;
        }
    }
}