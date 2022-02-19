#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library
//       File: RectExtensions.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using ForestOfChaos.Unity.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ForestOfChaos.Unity.Extensions {
    public static class RectExtensions {
        public static Vector2 GetRandomPosInRect(this Rect rect) => new Vector2(Random.Range(rect.min.x, rect.max.x), Random.Range(rect.min.y, rect.max.y));

        public static Rect GetModifiedRect(this Rect rect, RectEdit[] edits) {
            var output = new Rect(rect);

            foreach (var pair in edits)
                ProcessModification(ref output, pair);

            return output;
        }

        public static Rect GetModifiedRect(this Rect rect, RectEdit edits) {
            var output = new Rect(rect);
            ProcessModification(ref output, edits);

            return output;
        }

        public static Rect GetModifiedRect(this Rect rect, RectEdit edits, params RectEdit[] editParams) {
            var output = new Rect(rect);
            ProcessModification(ref output, edits);

            foreach (var pair in editParams)
                ProcessModification(ref output, pair);

            return output;
        }

        private static void ProcessModification(ref Rect output, RectEdit edit) {
            switch (edit.Type) {
                case RectEdit.RectEditType.Add:
                    RectEdit.Add(edit, ref output);

                    break;
                case RectEdit.RectEditType.Change:
                    RectEdit.Change(edit, ref output);

                    break;
                case RectEdit.RectEditType.Set:
                    RectEdit.Set(edit, ref output);

                    break;
                case RectEdit.RectEditType.Multiply:
                    RectEdit.Multiply(edit, ref output);

                    break;
                case RectEdit.RectEditType.Subtract:
                    RectEdit.Subtract(edit, ref output);

                    break;
                case RectEdit.RectEditType.Divide:
                    RectEdit.Divide(edit, ref output);

                    break;
                case RectEdit.RectEditType.Modulo:
                    RectEdit.Modulo(edit, ref output);

                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}