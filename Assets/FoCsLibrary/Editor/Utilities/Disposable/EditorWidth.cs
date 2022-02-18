#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs-Library
//    Project: FoCs.Unity.Library.Editor
//       File: EditorWidth.cs
//    Created: 2019/05/21
// LastEdited: 2022/02/19
#endregion

using System;
using UnityEditor;

namespace ForestOfChaos.Unity.Editor.Utilities.Disposable {
    public class EditorWidth: IDisposable {
        public enum ChangeType {
            Add,
            Set
        }

        public enum WidthType {
            Label,
            Field,
            Both
        }

        private readonly float     StoredFieldSize;
        private readonly float     StoredLabelSize;
        private readonly WidthType widthType;

        private static float EditorLabelWidth {
            get => EditorGUIUtility.labelWidth;
            set => EditorGUIUtility.labelWidth = value;
        }

        private static float EditorFieldWidth {
            get => EditorGUIUtility.fieldWidth;
            set => EditorGUIUtility.fieldWidth = value;
        }

        public EditorWidth(float size, WidthType _widthType, ChangeType changeType = ChangeType.Add) {
            widthType = _widthType;

            switch (widthType) {
                case WidthType.Label: {
                    StoredLabelSize = EditorLabelWidth;

                    switch (changeType) {
                        case ChangeType.Add:
                            EditorLabelWidth += size;

                            break;
                        case ChangeType.Set:
                            EditorLabelWidth = size;

                            break;
                    }

                    break;
                }
                case WidthType.Field: {
                    StoredFieldSize = EditorFieldWidth;

                    switch (changeType) {
                        case ChangeType.Add:
                            EditorFieldWidth += size;

                            break;
                        case ChangeType.Set:
                            EditorFieldWidth = size;

                            break;
                    }

                    break;
                }
                case WidthType.Both: {
                    StoredLabelSize = EditorLabelWidth;
                    StoredFieldSize = EditorFieldWidth;

                    switch (changeType) {
                        case ChangeType.Add:
                            EditorLabelWidth += size;
                            EditorFieldWidth += size;

                            break;
                        case ChangeType.Set:
                            EditorLabelWidth = size;
                            EditorFieldWidth = size;

                            break;
                    }

                    break;
                }
            }
        }

        public void Dispose() {
            switch (widthType) {
                case WidthType.Label:
                    EditorLabelWidth = StoredLabelSize;

                    break;
                case WidthType.Field:
                    EditorFieldWidth = StoredFieldSize;

                    break;
                case WidthType.Both:
                    EditorFieldWidth = StoredFieldSize;
                    EditorLabelWidth = StoredLabelSize;

                    break;
            }
        }
    }
}