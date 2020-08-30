#region © Forest Of Chaos Studios 2019 - 2020
//    Project: FoCs.Unity.Library
//       File: Neighbours.cs
//    Created: 2019/05/21 | 12:00 AM
// LastEdited: 2020/08/31 | 7:48 AM
#endregion


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLibrary.Grid {
    [Serializable]
    public class Neighbours: IEnumerable<GridPosition> {
        [SerializeField]
        private GridPosition _center;

        public bool AllowCorners = true;

        /// 000
        /// 010
        /// 000
        public GridPosition Center {
            get => _center;
            set => _center = value;
        }

        /// 000
        /// 100
        /// 000
        public GridPosition Left {
            get {
                var retVal = Center;
                retVal.X -= 1;

                return retVal;
            }
        }

        /// 000
        /// 001
        /// 000
        public GridPosition Right {
            get {
                var retVal = Center;
                retVal.X += 1;

                return retVal;
            }
        }

        /// 010
        /// 000
        /// 000
        public GridPosition Up {
            get {
                var retVal = Center;
                retVal.Y += 1;

                return retVal;
            }
        }

        /// 000
        /// 000
        /// 010
        public GridPosition Down {
            get {
                var retVal = Center;
                retVal.Y -= 1;

                return retVal;
            }
        }

        /// 100
        /// 000
        /// 000
        public GridPosition UpLeft {
            get {
                var retVal = Center;
                retVal.Y += 1;
                retVal.X -= 1;

                return retVal;
            }
        }

        /// 001
        /// 000
        /// 000
        public GridPosition UpRight {
            get {
                var retVal = Center;
                retVal.Y += 1;
                retVal.X += 1;

                return retVal;
            }
        }

        /// 000
        /// 000
        /// 100
        public GridPosition DownLeft {
            get {
                var retVal = Center;
                retVal.Y -= 1;
                retVal.X -= 1;

                return retVal;
            }
        }

        /// 000
        /// 000
        /// 001
        public GridPosition DownRight {
            get {
                var retVal = Center;
                retVal.Y -= 1;
                retVal.X += 1;

                return retVal;
            }
        }

        public IEnumerator<GridPosition> GetEnumerator() {
            if (AllowCorners)
                yield return UpLeft;

            yield return Up;

            if (AllowCorners)
                yield return UpRight;

            yield return Left;
            yield return Right;

            if (AllowCorners)
                yield return DownLeft;

            yield return Down;

            if (AllowCorners)
                yield return DownRight;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}