using System;
using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Types;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(Transform))]
	internal class TransformEditor: FoCsEditor<Transform>
	{
		private static          float                              scaleAmount       = 1;
		private static readonly GUIContent                         ResetContent      = new GUIContent("Reset Global","Reset Transforms in global space");
		private static readonly GUIContent                         ResetLocalContent = new GUIContent("Reset Local", "Reset Transforms in local space");
		private static          int                                _tabNum;
		private readonly        KeyValuePair<GUIContent, Action>[] TabName;
		public override         bool                               ShowCopyPasteButtons
		{
			get { return true; }
		}

		private static int TabNum
		{
			get { return _tabNum; }
			set { EditorPrefs.SetInt("FoCsTE.TabNum", _tabNum = value); }
		}

		public TransformEditor()
		{
			TabName = new[]
			{
					Pair.Create<GUIContent, Action>(new GUIContent("Nothing",       "Hides Any Extra Options"),                null),
					Pair.Create<GUIContent, Action>(new GUIContent("Scale Options", "Scale Preset Options"),                   ScaleButtonsEnabled),
					Pair.Create<GUIContent, Action>(new GUIContent("Global Values", "Force Display of Global Transform Data"), DrawGlobalTransformOptions),
					Pair.Create<GUIContent, Action>(new GUIContent("T Data", "Transform Data Copy Paste"),                     DrawTDCopyPaste),
			};
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		protected void OnEnable()
		{
			_tabNum = EditorPrefs.GetInt("FoCsTE.TabNum");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DoDrawHeader();

			using(Disposables.Indent())
			{
				DrawTransformOptions();

				using(Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				{
					for(var i = 0; i < TabName.Length; i++)
					{
						if(FoCsGUI.Layout.Toggle(TabName[i].Key, TabNum == i, FoCsGUI.Styles.ToolbarButton, GUILayout.Height(16)))
							TabNum = i;
					}
				}

				TabName[TabNum].Value.Trigger();
				serializedObject.ApplyModifiedProperties();
			}
		}

		private void DrawTransformOptions()
		{
			if(Target.parent == null)
				DrawGlobalTransformOptions();
			else
				DrawLocalTransformOptions();
		}

		private void DrawGlobalTransformOptions()
		{
			bool guiChanged;
			var  position = EditorHelpers.DrawVector3("Position", Target.position, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "position Changed");
				Target.position = position;
			}

			var eulerAngles = EditorHelpers.DrawVector3("Rotation", Target.eulerAngles, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "eulerAngles Changed");
				Target.eulerAngles = eulerAngles;
			}

			var scale = EditorHelpers.DrawVector3("Scale", Target.localScale, Vector3.one, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "scale Changed");
				Target.localScale = scale;
			}
		}
		private static readonly GUIContent CopyContent  = new GUIContent("Copy Transform Data", "Copies a new TransformData");
		private static readonly GUIContent PasteContent = new GUIContent("Paste Transform Data", "Pastes the TransformData");

		private void DrawTDCopyPaste()
		{
			var cachedGuiColor = GUI.color;
			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var copyBuff = CopyPasteUtility.CopyBuffer;
				var td = new TransformData();
				var isType = CopyPasteUtility.IsTypeInBuffer(td, copyBuff);


				var copyBtn  = FoCsGUI.Layout.Button(CopyContent,  EditorStyles.toolbarButton);
				FoCsGUI.GUIEventBool pasteBtn;
				PasteContent.tooltip = "Pastes: " + copyBuff.Substring(0, copyBuff.Length >= 512? 512 : copyBuff.Length);
				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
				{
					pasteBtn = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);
				}

				if(copyBtn)
				{
					CopyPasteUtility.Copy(new TransformData(Target));
				}

				else if(pasteBtn)
				{
					Undo.RecordObject(target, "TransformData Paste");
					Target.SetFromTD(CopyPasteUtility.Paste<TransformData>(copyBuff, true));
				}

			}
			GUI.color = cachedGuiColor;
		}

		private void DrawLocalTransformOptions()
		{
			bool guiChanged;
			var  position = EditorHelpers.DrawVector3("Local Position", Target.localPosition, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "position Changed");
				Target.localPosition = position;
			}

			var eulerAngles = EditorHelpers.DrawVector3("Local Rotation", Target.localEulerAngles, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "eulerAngles Changed");
				Target.localEulerAngles = eulerAngles;
			}

			var scale = EditorHelpers.DrawVector3("Local Scale", Target.localScale, Vector3.one, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "scale Changed");
				Target.localScale = scale;
			}
		}

		protected void DoDrawHeader()
		{
			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var transform     = Target;
				var resetBtn      = FoCsGUI.Layout.Button(ResetContent,      EditorStyles.toolbarButton);

				if(transform.parent)
				{
					var resetLocalBtn = FoCsGUI.Layout.Button(ResetLocalContent, EditorStyles.toolbarButton);

					if(resetLocalBtn)
					{
						Undo.RecordObject(transform, "ResetLocalPosRotScale");
						transform.ResetLocalPosRotScale();
					}
				}

				if(resetBtn)
				{
					Undo.RecordObject(transform, "ResetPosRotScale");
					transform.ResetPosRotScale();
				}

				DrawCopyPasteButtons();
			}
		}

		private static readonly GUIContent SetContent   = new GUIContent("Set:  ");
		private static readonly GUIContent TimesContent = new GUIContent("Times:");

		private void ScaleButtonsEnabled()
		{
			ScaleArea();

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				FoCsGUI.Layout.Label(SetContent, EditorStyles.toolbarButton, GUILayout.Width(60));
				SetScaleBtn(0.5f);
				SetScaleBtn(1);
				SetScaleBtn(2);
				SetScaleBtn(5);
				SetScaleBtn(10);
				SetScaleBtn(20);
				SetScaleBtn(50);
				SetScaleBtn(100);
			}

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				FoCsGUI.Layout.Label(TimesContent, EditorStyles.toolbarButton, GUILayout.Width(60));

				TimesScaleBtn(0.5f);
				TimesScaleBtn(1);
				TimesScaleBtn(2);
				TimesScaleBtn(5);
				TimesScaleBtn(10);
				TimesScaleBtn(20);
				TimesScaleBtn(50);
				TimesScaleBtn(100);
			}
		}

		private void SetScaleBtn(float multi = 1)
		{
			var resetContent = new GUIContent(string.Format("{0}x", multi), string.Format("Sets the Scale to ({0}, {1}, {2})", multi, multi, multi));

			if(FoCsGUI.Layout.Button(resetContent, EditorStyles.toolbarButton))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = Vector3.one * multi;
				scaleAmount          = transform.localScale.x;
			}
		}

		private void TimesScaleBtn(float multi = 1)
		{
			var resetContent = new GUIContent(string.Format("{0}x", multi), string.Format("Multiplies the Scale to ({0}, {1}, {2})", Target.localScale.x * multi, Target.localScale.y * multi, Target.localScale.z * multi));

			if(FoCsGUI.Layout.Button(resetContent, EditorStyles.toolbarButton))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = transform.localScale * multi;
				scaleAmount          = transform.localScale.x;
			}
		}

		private void ScaleArea()
		{
			var transform = Target;

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var content = new GUIContent("Scale amount", "Set amount to uniformly scale the object");
				scaleAmount = EditorGUILayout.FloatField(content, scaleAmount, EditorStyles.toolbarTextField);
				var scaleContent = new GUIContent("Set Scale", string.Format("Sets the scale ({0},{1},{2})", scaleAmount, scaleAmount, scaleAmount));

				if(GUILayout.Button(scaleContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale = Vector3.one * scaleAmount;
				}

				var scaleTimesContent = new GUIContent("Times Scale", string.Format("Sets the scale ({0},{1},{2})", transform.position.x * scaleAmount, transform.position.y * scaleAmount, transform.position.z * scaleAmount));

				if(GUILayout.Button(scaleTimesContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale *= scaleAmount;
				}
			}
		}
	}
}