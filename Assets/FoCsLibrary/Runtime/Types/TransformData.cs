#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: TransformData.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/04 | 6:56 PM
#endregion


using System;
using ForestOfChaos.Unity.Maths.Lerp;
using UnityEngine;

namespace ForestOfChaos.Unity.Types {
    [Serializable]
    public struct TransformData {
        public Vector3    Position;
        public Quaternion Rotation;
        public Vector3    Scale;
        public bool       Local;

        public static TransformData Empty => new TransformData(Vector3.zero, Quaternion.identity, Vector3.one);

        public TransformData(Component component, bool local = false) {
            Local = local;
            var transform = component.transform;

            if (Local) {
                Rotation = transform.localRotation;
                Scale    = transform.localScale;
                Position = transform.localPosition;
            }
            else {
                Rotation = transform.rotation;
                Scale    = transform.localScale;
                Position = transform.position;
            }
        }

        public TransformData(GameObject gameObject, bool local = false) {
            Local = local;
            var transform = gameObject.transform;

            if (Local) {
                Rotation = transform.localRotation;
                Scale    = transform.localScale;
                Position = transform.localPosition;
            }
            else {
                Rotation = transform.rotation;
                Scale    = transform.localScale;
                Position = transform.position;
            }
        }

        public TransformData(Transform transform, bool local = false) {
            Local = local;

            if (Local) {
                Rotation = transform.localRotation;
                Scale    = transform.localScale;
                Position = transform.localPosition;
            }
            else {
                Rotation = transform.rotation;
                Scale    = transform.localScale;
                Position = transform.position;
            }
        }

        public TransformData(TransformData transform) {
            Local    = transform.Local;
            Rotation = transform.Rotation;
            Scale    = transform.Scale;
            Position = transform.Position;
        }

        public TransformData(Vector3 position, bool local = false) {
            Local    = local;
            Rotation = Quaternion.identity;
            Scale    = Vector3.one;
            Position = position;
        }

        public TransformData(Vector3 position, Quaternion rotation, bool local = false) {
            Local    = local;
            Rotation = rotation;
            Scale    = Vector3.one;
            Position = position;
        }

        public TransformData(Vector3 position, Quaternion rotation, Vector3 scale, bool local = false) {
            Local    = local;
            Rotation = rotation;
            Scale    = scale;
            Position = position;
        }

        public void SetData(Transform transform) {
            if (Local) {
                Rotation = transform.localRotation;
                Scale    = transform.localScale;
                Position = transform.localPosition;
            }
            else {
                Rotation = transform.rotation;
                Scale    = transform.localScale;
                Position = transform.position;
            }
        }

        public void SetData(TransformData transform) {
            if (Local) {
                Rotation = transform.Rotation;
                Scale    = transform.Scale;
                Position = transform.Position;
            }
            else {
                Rotation = transform.Rotation;
                Scale    = transform.Scale;
                Position = transform.Position;
            }
        }

        public void SetData(Vector3 position, bool setOtherValuesToDefault = true) {
            if (setOtherValuesToDefault) {
                Rotation = Quaternion.identity;
                Scale    = Vector3.one;
            }

            Position = position;
        }

        public void SetData(Vector3 position, Quaternion rotation, bool setOtherValuesToDefault = true) {
            if (setOtherValuesToDefault)
                Scale = Vector3.one;

            Rotation = rotation;
            Position = position;
        }

        public void SetData(Vector3 position, Quaternion rotation, Vector3 scale) {
            Rotation = rotation;
            Scale    = scale;
            Position = position;
        }

        public void ApplyData(Transform transform) {
            if (Local) {
                transform.localRotation = Rotation;
                transform.localScale    = Scale;
                transform.localPosition = Position;
            }
            else {
                transform.rotation   = Rotation;
                transform.localScale = Scale;
                transform.position   = Position;
            }
        }

        public void ApplyData(Transform transform, bool local) {
            if (local) {
                transform.localRotation = Rotation;
                transform.localScale    = Scale;
                transform.localPosition = Position;
            }
            else {
                transform.rotation   = Rotation;
                transform.localScale = Scale;
                transform.position   = Position;
            }
        }

        public TransformData Lerp(TransformData other, float time) => TransformDataLerp.Lerp(this, other, time);

        public static TransformData Lerp(TransformData a, TransformData b, float time) => TransformDataLerp.Lerp(a, b, time);

        public TransformData Copy() => new TransformData(this);

        public static implicit operator TransformData(Transform input) => new TransformData(input);

        public static implicit operator TransformData(Component input) => new TransformData(input.transform);

        public static implicit operator TransformData(GameObject input) => new TransformData(input.transform);

        public static TransformData Create(Transform transform, bool local = false) => new TransformData(transform, local);
    }

    public static class TransformDataExtn {
        public static void SetFromTD(this Transform transform, TransformData data) {
            data.ApplyData(transform);
        }

        public static TransformData GetTD(this Transform transform) => transform;
    }
}