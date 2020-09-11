#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Vector3I.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/09/12 | 12:02 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaosLibrary.Types {
    [Serializable]
    public struct Vector3I: IEquatable<Vector3I>, IComparable<Vector3I>, IEquatable<int>, IComparable<int> {
        public int x;
        public int y;
        public int z;

        public Vector3I(int _x, bool allValues = false) {
            if (allValues) {
                x = _x;
                y = _x;
                z = _x;
            }
            else {
                x = _x;
                y = 0;
                z = 0;
            }
        }

        public Vector3I(int _x, int _y, int _z) {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3I(float _x): this((int)_x, 0, 0) { }

        public Vector3I(float _x, bool allValues = false): this((int)_x, allValues) { }

        public Vector3I(int _x, int _y): this(_x, _y, 0) { }

        public Vector3I(float _x, float _y): this((int)_x, (int)_x, 0) { }

        public Vector3I(float _x, float _y, float _z): this((int)_x, (int)_y, (int)_z) { }

        public Vector3I(Vector3I other): this(other.x, other.y, other.z) { }

        public int Total() => x + y + z;

        public bool IsZero() => (x == 0) && (y == 0) && (z == 0);

        public bool IsZeroOrNegative() => (x <= 0) && (y <= 0) && (z <= 0);

        public bool IsNegative() => (x < 0) && (y < 0) && (z < 0);

        public bool IsZeroOrPositive() => (x >= 0) && (y >= 0) && (z >= 0);

        public bool IsPositive() => (x > 0) && (y > 0) && (z > 0);

        public bool IsUnitVector() => (x == y) && (x == z) && (y == z) && (z == x);

        public Vector2 ToVector2() => this;

        public Vector3 ToVector3() => this;

        public Vector4 ToVector4() => this;

        public Vector2I ToVector2I() => this;

        public Vector3I ToVector3I() => this;

        public Vector4I ToVector4I() => this;

        public Vector3I Copy() => new Vector3I(this);

        public static Vector3I operator -(Vector3I left) => new Vector3I(-left.x, -left.y, -left.z);

        public static Vector3I operator +(Vector3I left) => new Vector3I(+left.x, +left.y, +left.z);

        public static Vector3I operator -(Vector3I left, Vector3I right) => new Vector3I(left.x - right.x, left.y - right.y, left.z - right.z);

        public static Vector3I operator +(Vector3I left, Vector3I right) => new Vector3I(left.x + right.x, left.y + right.y, left.z + right.z);

        public static Vector3I operator *(Vector3I left, Vector3I right) => new Vector3I(left.x * right.x, left.y * right.y, left.z * right.z);

        public static bool operator ==(Vector3I left, int right) => left.Equals(right);

        public static bool operator !=(Vector3I left, int right) => !left.Equals(right);

        public static bool operator ==(Vector3I left, Vector3I right) => left.Equals(right);

        public static bool operator !=(Vector3I left, Vector3I right) => !left.Equals(right);

        public static implicit operator Vector2(Vector3I input) => new Vector2(input.x, input.y);

        public static implicit operator Vector3(Vector3I input) => new Vector3(input.x, input.y, input.z);

        public static implicit operator Vector4(Vector3I input) => new Vector4(input.x, input.y, input.z);

        public static implicit operator Vector3I(Vector2 input) => new Vector3I(input.x, input.y);

        public static implicit operator Vector3I(Vector3 input) => new Vector3I(input.x, input.y, input.z);

        public static implicit operator Vector3I(Vector4 input) => new Vector3I(input.x, input.y, input.z);

        public static implicit operator Vector3I(Vector2I input) => new Vector3I(input.x, input.y);

        public static implicit operator Vector3I(Vector4I input) => new Vector3I(input.x, input.y, input.z);

        public static implicit operator int[](Vector3I num) => new[] {num.x, num.y, num.z};

        public static implicit operator Vector3I(int[] num) {
            var Vector = new Vector3I();

            switch (num.Length) {
                case 0: return Vector;
                case 1:
                    Vector.x = num[0];

                    return Vector;
                case 2:
                    Vector.x = num[0];
                    Vector.y = num[1];

                    return Vector;
                case 3:
                    Vector.x = num[0];
                    Vector.y = num[1];
                    Vector.z = num[2];

                    return Vector;
                default:
                    Vector.x = num[0];
                    Vector.y = num[1];
                    Vector.z = num[2];

                    return Vector;
            }
        }

        public static implicit operator Vector3I(float[] num) {
            var Vector = new Vector3I();

            switch (num.Length) {
                case 0: return Vector;
                case 1:
                    Vector.x = (int)num[0];

                    return Vector;
                case 2:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];

                    return Vector;
                case 3:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];
                    Vector.z = (int)num[2];

                    return Vector;
                default:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];
                    Vector.z = (int)num[2];

                    return Vector;
            }
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;

            if (obj is Vector3I)
                return Equals((Vector3I)obj);

            if (obj is int)
                return Equals((int)obj);

            return false;
        }

        public bool Equals(Vector3I other) => (x == other.x) && (y == other.y) && (z == other.z);

        public bool Equals(int other) => (x == other) && (y == other) && (z == other);

        public int CompareTo(int other) {
            if (IsUnitVector())
                return x.CompareTo(other);

            return 1;
        }

        public int CompareTo(Vector3I other) {
            var xComparison = x.CompareTo(other.x);

            if (xComparison != 0)
                return xComparison;

            var yComparison = y.CompareTo(other.y);

            if (yComparison != 0)
                return yComparison;

            return z.CompareTo(other.z);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = x;
                hashCode = hashCode * 397 ^ y;
                hashCode = hashCode * 397 ^ z;

                return hashCode;
            }
        }

        public override string ToString() => $"X: {x}, Y: {y}, Z: {z}";

        public static Vector3I Zero {
            get {
                const int num = 0;

                return new Vector3I(num, true);
            }
        }

        public static Vector3I One {
            get {
                const int num = 1;

                return new Vector3I(num, true);
            }
        }

        public static Vector3I MinInt {
            get {
                const int num = int.MinValue;

                return new Vector3I(num, true);
            }
        }

        public static Vector3I MaxInt {
            get {
                const int num = int.MaxValue;

                return new Vector3I(num, true);
            }
        }
    }
}