#region © Forest Of Chaos Studios 2019 - 2020
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: Vector2I.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/10/11 | 10:09 PM
#endregion

using System;
using UnityEngine;

namespace ForestOfChaos.Unity.Types {
    [Serializable]
    public struct Vector2I: IEquatable<Vector2I>, IComparable<Vector2I>, IEquatable<int>, IComparable<int> {
        public int x;
        public int y;

        public Vector2I(int _x, int _y) {
            x = _x;
            y = _y;
        }

        public Vector2I(int _x, bool allValues = false) {
            if (allValues) {
                x = _x;
                y = _x;
            }
            else {
                x = _x;
                y = 0;
            }
        }

        public Vector2I(float _x, bool allValues = false): this((int)_x, allValues) { }

        public Vector2I(float _x, float _y): this((int)_x, (int)_y) { }

        public Vector2I(Vector2I other): this(other.x, other.y) { }

        public int Total => x + y;

        public bool IsZero() => (x == 0) && (y == 0);

        public bool IsZeroOrNegative() => (x <= 0) && (y <= 0);

        public bool IsNegative() => (x < 0) && (y < 0);

        public bool IsZeroOrPositive() => (x >= 0) && (y >= 0);

        public bool IsPositive() => (x > 0) && (y > 0);

        public bool IsUnitVector() => x == y;

        public Vector2 ToVector2() => this;

        public Vector3 ToVector3() => this;

        public Vector4 ToVector4() => this;

        public Vector2I ToVector2I() => this;

        public Vector3I ToVector3I() => this;

        public Vector4I ToVector4I() => this;

        public Vector3 FromX_Y2Z() => new Vector3(x, 0, y);

        public Vector2I Copy() => new Vector2I(this);

        public static Vector2I operator -(Vector2I left) => new Vector2I(-left.x, -left.y);

        public static Vector2I operator +(Vector2I left) => new Vector2I(+left.x, +left.y);

        public static Vector2I operator -(Vector2I left, Vector2I right) => new Vector2I(left.x - right.x, left.y - right.y);

        public static Vector2I operator +(Vector2I left, Vector2I right) => new Vector2I(left.x + right.x, left.y + right.y);

        public static Vector2I operator *(Vector2I left, Vector2I right) => new Vector2I(left.x * right.x, left.y * right.y);

        public static Vector2I operator *(Vector2I left, int right) => new Vector2I(left.x * right, left.y * right);

        public static Vector2I operator *(Vector2I left, float right) => new Vector2I(left.x * right, left.y * right);

        public static bool operator ==(Vector2I left, int right) => left.Equals(right);

        public static bool operator !=(Vector2I left, int right) => !left.Equals(right);

        public static bool operator ==(Vector2I left, Vector2I right) => left.Equals(right);

        public static bool operator !=(Vector2I left, Vector2I right) => !left.Equals(right);

        public static implicit operator Vector2(Vector2I input) => new Vector2(input.x, input.y);

        public static implicit operator Vector3(Vector2I input) => new Vector3(input.x, input.y);

        public static implicit operator Vector4(Vector2I input) => new Vector4(input.x, input.y);

        public static implicit operator Vector2I(Vector2 input) => new Vector2I(input.x, input.y);

        public static implicit operator Vector2I(Vector3 input) => new Vector2I(input.x, input.y);

        public static implicit operator Vector2I(Vector4 input) => new Vector2I(input.x, input.y);

        public static implicit operator Vector2I(Vector3I input) => new Vector2I(input.x, input.y);

        public static implicit operator Vector2I(Vector4I input) => new Vector2I(input.x, input.y);

        public static implicit operator int[](Vector2I num) => new[] {num.x, num.y};

        public static implicit operator Vector2I(int[] num) {
            var Vector = new Vector2I();

            switch (num.Length) {
                case 0: return Vector;
                case 1:
                    Vector.x = num[0];

                    return Vector;
                case 2:
                    Vector.x = num[0];
                    Vector.y = num[1];

                    return Vector;
                default:
                    Vector.x = num[0];
                    Vector.y = num[1];

                    return Vector;
            }
        }

        public static implicit operator Vector2I(float[] num) {
            var Vector = new Vector2I();

            switch (num.Length) {
                case 0: return Vector;
                case 1:
                    Vector.x = (int)num[0];

                    return Vector;
                case 2:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];

                    return Vector;
                default:
                    Vector.x = (int)num[0];
                    Vector.y = (int)num[1];

                    return Vector;
            }
        }

        public override bool Equals(object obj) {
            switch (obj) {
                case null:         return false;
                case Vector2I vec: return Equals(vec);
                case int intval:   return Equals(intval);
            }

            return false;
        }

        public bool Equals(Vector2I other) => (x == other.x) && (y == other.y);

        public bool Equals(int other) => (x == other) && (y == other);

        public override int GetHashCode() {
            unchecked {
                var hashCode = x;
                hashCode = hashCode * 397 ^ y;

                return hashCode;
            }
        }

        public int CompareTo(int other) {
            if (IsUnitVector())
                return x.CompareTo(other);

            return 1;
        }

        public int CompareTo(Vector2I other) {
            var xComparison = x.CompareTo(other.x);

            if (xComparison != 0)
                return xComparison;

            return y.CompareTo(other.y);
        }

        public override string ToString() => $"X: {x}, Y: {y}";

        public static Vector2I Zero => new Vector2I(0, true);

        public static Vector2I One => new Vector2I(1, true);

        public static Vector2I MinInt => new Vector2I(int.MinValue, true);

        public static Vector2I MaxInt => new Vector2I(int.MaxValue, true);

        public static Vector2I Up => new Vector2I(0, 1);

        public static Vector2I Down => new Vector2I(0, -1);

        public static Vector2I Left => new Vector2I(1, 0);

        public static Vector2I Right => new Vector2I(-1, 0);
    }
}