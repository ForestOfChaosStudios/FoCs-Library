using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			public class SkinRef
			{
				public GUIStyle   ScrollView
				{
					get { return GUI.skin.scrollView; }
				}

				public GUIStyle   VerticalSliderThumb
				{
					get { return GUI.skin.verticalSliderThumb; }
				}

				public GUIStyle   VerticalSlider
				{
					get { return GUI.skin.verticalSlider; }
				}

				public GUIStyle   VerticalScrollbarDownButton
				{
					get { return GUI.skin.verticalScrollbarDownButton; }
				}

				public GUIStyle   VerticalScrollbarUpButton
				{
					get { return GUI.skin.verticalScrollbarUpButton; }
				}

				public GUIStyle   VerticalScrollbarThumb
				{
					get { return GUI.skin.verticalScrollbarThumb; }
				}

				public GUIStyle   VerticalScrollbar
				{
					get { return GUI.skin.verticalScrollbar; }
				}

				public GUIStyle   HorizontalScrollbarRightButton
				{
					get { return GUI.skin.horizontalScrollbarRightButton; }
				}

				public GUIStyle   HorizontalScrollbarLeftButton
				{
					get { return GUI.skin.horizontalScrollbarLeftButton; }
				}

				public GUIStyle   HorizontalScrollbarThumb
				{
					get { return GUI.skin.horizontalScrollbarThumb; }
				}

				public GUIStyle   HorizontalScrollbar
				{
					get { return GUI.skin.horizontalScrollbar; }
				}

				public GUIStyle   HorizontalSliderThumb
				{
					get { return GUI.skin.horizontalSliderThumb; }
				}

				public GUIStyle   Window
				{
					get { return GUI.skin.window; }
				}

				public GUIStyle   Toggle
				{
					get { return GUI.skin.toggle; }
				}

				public GUIStyle   Button
				{
					get { return GUI.skin.button; }
				}

				public GUIStyle   TextArea
				{
					get { return GUI.skin.textArea; }
				}

				public GUIStyle   TextField
				{
					get { return GUI.skin.textField; }
				}

				public GUIStyle   Label
				{
					get { return GUI.skin.label; }
				}

				public GUIStyle   Box
				{
					get { return GUI.skin.box; }
				}

				public GUIStyle   HorizontalSlider
				{
					get { return GUI.skin.horizontalSlider; }
				}

				public GUIStyle[] CustomStyles
				{
					get { return GUI.skin.customStyles; }
				}

				public Font       Font
				{
					get { return GUI.skin.font; }
				}

				public Font       StandardFont
				{
					get { return EditorStyles.standardFont; }
				}

				public Font       BoldFont
				{
					get { return EditorStyles.boldFont; }
				}

				public Font       MiniFont
				{
					get { return EditorStyles.miniFont; }
				}

				public Font       MiniBoldFont
				{
					get { return EditorStyles.miniBoldFont; }
				}

				public GUIStyle   ObjectField
				{
					get { return EditorStyles.objectField; }
				}

				public GUIStyle   ObjectFieldThumb
				{
					get { return EditorStyles.objectFieldThumb; }
				}

				public GUIStyle   ObjectFieldMiniThumb
				{
					get { return EditorStyles.objectFieldMiniThumb; }
				}

				public GUIStyle   ColorField
				{
					get { return EditorStyles.colorField; }
				}

				public GUIStyle   LayerMaskField
				{
					get { return EditorStyles.layerMaskField; }
				}

				public GUIStyle   Toggle_Editor
				{
					get { return EditorStyles.toggle; }
				}

				public GUIStyle   Foldout
				{
					get { return EditorStyles.foldout; }
				}

				public GUIStyle   FoldoutPreDrop
				{
					get { return EditorStyles.foldoutPreDrop; }
				}

				public GUIStyle   ToggleGroup
				{
					get { return EditorStyles.toggleGroup; }
				}

				public GUIStyle   Toolbar
				{
					get { return EditorStyles.toolbar; }
				}

				public GUIStyle   ToolbarButton
				{
					get { return EditorStyles.toolbarButton; }
				}

				public GUIStyle   ToolbarPopup
				{
					get { return EditorStyles.toolbarPopup; }
				}

				public GUIStyle   ToolbarDropDown
				{
					get { return EditorStyles.toolbarDropDown; }
				}

				public GUIStyle   ToolbarTextField
				{
					get { return EditorStyles.toolbarTextField; }
				}

				public GUIStyle   InspectorDefaultMargins
				{
					get { return EditorStyles.inspectorDefaultMargins; }
				}

				public GUIStyle   InspectorFullWidthMargins
				{
					get { return EditorStyles.inspectorFullWidthMargins; }
				}

				public GUIStyle   Popup
				{
					get { return EditorStyles.toolbarPopup; }
				}

				public GUIStyle   MiniTextField
				{
					get { return EditorStyles.miniTextField; }
				}

				public GUIStyle   Label_Editor
				{
					get { return EditorStyles.boldLabel; }
				}

				public GUIStyle   MiniLabel
				{
					get { return EditorStyles.centeredGreyMiniLabel; }
				}

				public GUIStyle   LargeLabel
				{
					get { return EditorStyles.largeLabel; }
				}

				public GUIStyle   BoldLabel
				{
					get { return EditorStyles.boldLabel; }
				}

				public GUIStyle   MiniBoldLabel
				{
					get { return EditorStyles.miniBoldLabel; }
				}

				public GUIStyle   CenteredGreyMiniLabel
				{
					get { return EditorStyles.centeredGreyMiniLabel; }
				}

				public GUIStyle   WordWrappedMiniLabel
				{
					get { return EditorStyles.wordWrappedMiniLabel; }
				}

				public GUIStyle   WordWrappedLabel
				{
					get { return EditorStyles.wordWrappedLabel; }
				}

				public GUIStyle   WhiteLabel
				{
					get { return EditorStyles.whiteLabel; }
				}

				public GUIStyle   WhiteMiniLabel
				{
					get { return EditorStyles.whiteMiniLabel; }
				}

				public GUIStyle   WhiteLargeLabel
				{
					get { return EditorStyles.whiteLargeLabel; }
				}

				public GUIStyle   WhiteBoldLabel
				{
					get { return EditorStyles.whiteBoldLabel; }
				}

				public GUIStyle   RadioButton
				{
					get { return EditorStyles.radioButton; }
				}

				public GUIStyle   MiniButton
				{
					get { return EditorStyles.miniButton; }
				}

				public GUIStyle   MiniButtonLeft
				{
					get { return EditorStyles.miniButtonLeft; }
				}

				public GUIStyle   MiniButtonMid
				{
					get { return EditorStyles.miniButtonMid; }
				}

				public GUIStyle   MiniButtonRight
				{
					get { return EditorStyles.miniButtonRight; }
				}

				public GUIStyle   TextField_Editor
				{
					get { return EditorStyles.miniTextField; }
				}

				public GUIStyle   TextArea_Editor
				{
					get { return EditorStyles.textArea; }
				}

				public GUIStyle   NumberField
				{
					get { return EditorStyles.numberField; }
				}

				public GUIStyle   HelpBox
				{
					get { return EditorStyles.helpBox; }
				}
			}
		}
	}
}