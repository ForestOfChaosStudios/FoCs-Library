#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: Vector4I.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using UnityEngine;

namespace ForestOfChaosLibrary.Types {
    [Serializable]
    public struct Vector4I: IEquatable<Vector4I>, IComparable<Vector4I>, IEquatable<int>, IComparable<int> {
        public int x;
        public int y;
        public int z;
        public int w;

        public Vector4I(int _x, bool allValues = false) {
            if (allValues) {
                x = _x;
                y = _x;
                z = _x;
                w = _x;
            }
            else {
                x = _x;
                y = 0;
                z = 0;
                w = 0;
            }
        }

        public Vector4I(int _x, int _y, int _z, int _w) {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public Vector4I(float _x): this((int)_x, 0, 0, 0) { }

        public Vector4I(float _x, bool allValues = false): this((int)_x, allValues) { }

        public Vector4I(int _x, int _y): this(_x, _y, 0, 0) { }

        public Vector4I(float _x, float _y): this((int)_x, (int)_x, 0, 0) { }

        public Vector4I(int _x, int _y, int _z): this(_x, _y, _z, 0) { }

        public Vector4I(float _x, float _y, float _z): this((int)_x, (int)_y, (int)_z, 0) { }

        public Vector4I(float _x, float _y, float _z, float _w): this((int)_x, (int)_y, (int)_z, (int)_w) { }

        public Vector4I(Vector4I other): this(other.x, other.y, other.z, other.w) { }

        public int Total() => x + y + z + w;

        public bool IsZero() => (x == 0) && (y == 0) && (z == 0) && (w == 0);

        public bool IsZeroOrNegative() => (x <= 0) && (y <= 0) && (z <= 0) && (w <= 0);

        public bool IsNegative() => (x < 0) && (y < 0) && (z < 0) && (w < 0);

        public bool IsZeroOrPositive() => (x >= 0) && (y >= 0) && (z >= 0) && (w >= 0);

        public bool IsPositive() => (x > 0) && (y > 0) && (z > 0) && (w > 0);

        public bool IsUnitVector() => (x == y) && (x == z) && (x == w) && (y == z) && (y == w) && (z == x) && (z == w) && (w == x) && (w == y);

        public Vector2 ToVector2() => this;

        public Vector3 ToVector3() => this;

        public Vector4 ToVector4() => this;

        public Vector2I ToVector2I() => this;

        public Vector3I ToVector3I() => this;

        public Vector4I ToVector4I() => this;

        public Vector4I Copy() => new Vector4I(this);

        public static Vector4I operator -(Vector4I left) => new Vector4I(-left.x, -left.y, -left.z, -left.w);

        public static Vector4I operator +(Vector4I left) => new Vector4I(+left.x, +left.y, +left.z, +left.w);

        public static Vector4I operator -(Vector4I left, Vector4I right) => new Vector4I(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);

        public static Vector4I operator +(Vector4I left, Vector4I right) => new Vector4I(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);

        public static Vector4I operator *(Vector4I left, Vector4I right) => new Vector4I(left.x * right.x, left.y * right.y, left.z * right.z, left.w * right.w);

        public static bool operator ==(Vector4I left, int right) => left.Equals(right);

        public static bool operator !=(Vector4I left, int right) => !left.Equals(right);

        public static bool operator ==(Vector4I left, Vector4I right) => left.Equals(right);

        public static bool operator !=(Vector4I left, Vector4I right) => !left.Equals(right);

        public static implicit operator Vector2(Vector4I input) => new Vector2(input.x, input.y);

        public static implicit operator Vector3(Vector4I input) => new Vector3(input.x, input.y, input.z);

        public static implicit operator Vector4(Vector4I input) => new Vector4(input.x, input.y, input.z, input.w);

        public static implicit operator Vector4I(Vector2 input) => new Vector4I(input.x, input.y);

        public static implicit operator Vector4I(Vector3 input) => new Vector4I(input.x, input.y, input.z);

        public static implicit operator Vector4I(Vector4 input) => new Vector4I(input.x, input.y, input.z, input.w);

        public static implicit operator Vector4I(Vector2I input) => new Vector4I(input.x, input.y);

        public static implicit operator Vector4I(Vector3I input) => new Vector4I(input.x, input.y, input.z);

        public static implicit operator int[](Vector4I num) => new[] {num.x, num.y, num.z, num.w};

        public static implicit operator Vector4I(int[] num) {
            var Vector = new Vector4I();

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
                case 4:
                    Vector.x = num[0];
                    Vector.y = num[1];
                    Vector.z = num[2];
                    Vector.w = num[3];

                    return Vector;
                default:
                    Vector.x = num[0];
                    Vector.y = num[1];
                    Vector.z = num[2];
                    Vector.w = num[3];

                    return Vector;
            }
        }

        public static implicit operator Vector4I(float[] num) {
            var Vector = new Vector4I();

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
                case 4:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];
                    Vector.z = (int)num[2];
                    Vector.w = (int)num[3];

                    return Vector;
                default:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];
                    Vector.z = (int)num[2];
                    Vector.w = (int)num[3];

                    return Vector;
            }
        }

        public bool Equals(Vector4I other) => (x == other.x) && (y == other.y) && (z == other.z) && (w == other.w);

        public bool Equals(int other) => (x == other) && (y == other) && (z == other) && (w == other);

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;

            if (obj is Vector4I)
                return Equals((Vector4I)obj);

            if (obj is int)
                return Equals((int)obj);

            return false;
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = x;
                hashCode = hashCode * 397 ^ y;
                hashCode = hashCode * 397 ^ z;
                hashCode = hashCode * 397 ^ w;

                return hashCode;
            }
        }

        public int CompareTo(int other) {
            if (IsUnitVector())
                return x.CompareTo(other);

            return 1;
        }

        public int CompareTo(Vector4I other) {
            var xComparison = x.CompareTo(other.x);

            if (xComparison != 0)
                return xComparison;

            var yComparison = y.CompareTo(other.y);

            if (yComparison != 0)
                return yComparison;

            var zComparison = z.CompareTo(other.z);

            if (zComparison != 0)
                return zComparison;

            return w.CompareTo(other.w);
        }

        public override string ToString() => $"X: {x}, Y: {y}, Z: {z}, W: {w}";

        public static Vector4I Zero {
            get {
                const int num = 0;

                return new Vector4I(num, true);
            }
        }

        public static Vector4I One {
            get {
                const int num = 1;

                return new Vector4I(num, true);
            }
        }

        public static Vector4I MinInt {
            get {
                const int num = int.MinValue;

                return new Vector4I(num, true);
            }
        }

        public static Vector4I MaxInt {
            get {
                const int num = int.MaxValue;

                return new Vector4I(num, true);
            }
        }
    }
}