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
		private static          float                                    scaleAmount = 1;
		private static          int                                      tabNum;
		private static readonly GUIContent                               ResetContent      = new GUIContent("Reset Global",         "Reset Transforms in global space");
		private static readonly GUIContent                               ResetLocalContent = new GUIContent("Reset Local",          "Reset Transforms in local space");
		private static readonly GUIContent                               CopyContent       = new GUIContent("Copy Transform Data",  "Copies a new TransformData");
		private static readonly GUIContent                               PasteContent      = new GUIContent("Paste Transform Data", "Pastes the TransformData");
		private static readonly GUIContent                               SetContent        = new GUIContent("Set:  ");
		private static readonly GUIContent                               TimesContent      = new GUIContent("Times:");
		private readonly        KeyValuePair<Func<bool, bool>, Action>[] TabName;
		public override         bool                                     ShowCopyPasteButtons      => true;
		public override         bool                                     AllowsSortingModeChanging => false;

		private static int TabNum
		{
			get { return tabNum; }
			set { EditorPrefs.SetInt("FoCsTE.TabNum", tabNum = value); }
		}

		private static GUILayoutOption[] SCALE_LABEL_OPTIONS => new[] {GUILayout.Width(60), SCALE_BUTTON_HEIGHT};
		private static GUILayoutOption   SCALE_BUTTON_HEIGHT => GUILayout.Height(16);

		public TransformEditor()
		{
			TabName = new[]
			{
					Pair.Create<Func<bool, bool>, Action>(a => NormalToolbarButton(a, new GUIContent("Nothing",       "Hides Any Extra Options")),                null),
					Pair.Create<Func<bool, bool>, Action>(a => NormalToolbarButton(a, new GUIContent("Scale Options", "Scale Preset Options")),                   ScaleButtonsEnabled),
					Pair.Create<Func<bool, bool>, Action>(a => NormalToolbarButton(a, new GUIContent("Global Values", "Force Display of Global Transform Data")), DrawGlobalTransformOptions),
					Pair.Create<Func<bool, bool>, Action>(a => NormalToolbarButton(a, new GUIContent("T Data",        "Transform Data Copy Paste")),              DrawTDCopyPaste),
					Pair.Create<Func<bool, bool>, Action>(PingObject,                                                                                             null)
			};
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			tabNum = EditorPrefs.GetInt("FoCsTE.TabNum");
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
						if(TabName[i].Key.Invoke(i == TabNum))
							TabNum = i;
					}
				}

				TabName[TabNum].Value.Trigger();
				serializedObject.ApplyModifiedProperties();
			}
		}

		private static bool NormalToolbarButton(bool active, GUIContent con) => FoCsGUI.Layout.Toggle(con, active, FoCsGUI.Styles.ToolbarButton, GUILayout.Height(16));

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

		private bool PingObject(bool val)
		{
			if(FoCsGUI.Layout.Toggle("Ping Object", val, FoCsGUI.Styles.ToolbarButton, GUILayout.Height(16)))
				EditorGUIUtility.PingObject(Target);

			return false;
		}

		private void DrawTDCopyPaste()
		{
			var cachedGuiColor = GUI.color;

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var                  copyBuff = CopyPasteUtility.CopyBuffer;
				var                  td       = new TransformData();
				var                  isType   = CopyPasteUtility.IsTypeInBuffer(td, copyBuff);
				var                  copyBtn  = FoCsGUI.Layout.Button(CopyContent, EditorStyles.toolbarButton);
				FoCsGUI.GUIEventBool pasteBtn;
				PasteContent.tooltip = "Pastes: " + copyBuff.Substring(0, copyBuff.Length >= 512? 512 : copyBuff.Length);

				using(Disposables.ColorChanger(isType? GUI.color : Color.red))
					pasteBtn = FoCsGUI.Layout.Button(PasteContent, EditorStyles.toolbarButton);

				if(copyBtn)
					CopyPasteUtility.Copy(new TransformData(Target));
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

		protected override void GetHeaderButtons(List<Action> headerButtons)
		{
			headerButtons.Add(ExtraHeader);
			base.GetHeaderButtons(headerButtons);
		}

		protected void ExtraHeader()
		{
			var transform = Target;
			var resetBtn  = FoCsGUI.Layout.Button(ResetContent, EditorStyles.toolbarButton);

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
		}

		private void ScaleButtonsEnabled()
		{
			ScaleArea();

			using(Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.Label(SetContent, SCALE_LABEL_OPTIONS);
				SetScaleBtn(0.5f);
				SetScaleBtn(1);
				SetScaleBtn(2);
				SetScaleBtn(5);
				SetScaleBtn(10);
				SetScaleBtn(20);
				SetScaleBtn(50);
				SetScaleBtn(100);
			}

			using(Disposables.HorizontalScope())
			{
				FoCsGUI.Layout.LabelField(TimesContent, SCALE_LABEL_OPTIONS);
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

		private void SetScaleBtn(float multi)
		{
			var resetContent = new GUIContent(string.Format("{0}x", multi), string.Format("Sets the Scale to ({0}, {1}, {2})", multi, multi, multi));

			if(FoCsGUI.Layout.Button(resetContent, SCALE_BUTTON_HEIGHT))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = Vector3.one * multi;
				scaleAmount          = transform.localScale.x;
			}
		}

		private void TimesScaleBtn(float multi)
		{
			var resetContent = new GUIContent(string.Format("{0}x", multi), string.Format("Multiplies the Scale to ({0}, {1}, {2})", Target.localScale.x * multi, Target.localScale.y * multi, Target.localScale.z * multi));

			if(FoCsGUI.Layout.Button(resetContent, SCALE_BUTTON_HEIGHT))
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

			using(Disposables.HorizontalScope())
			{
				var content = new GUIContent("Scale amount", "Set amount to uniformly scale the object");
				scaleAmount = FoCsGUI.Layout.FloatField(content, scaleAmount, SCALE_BUTTON_HEIGHT);
				var scaleContent = new GUIContent("Set Scale", string.Format("Sets the scale ({0},{1},{2})", scaleAmount, scaleAmount, scaleAmount));

				if(GUILayout.Button(scaleContent, SCALE_BUTTON_HEIGHT))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale = Vector3.one * scaleAmount;
				}

				var scaleTimesContent = new GUIContent("Times Scale", string.Format("Sets the scale ({0},{1},{2})", transform.position.x * scaleAmount, transform.position.y * scaleAmount, transform.position.z * scaleAmount));

				if(GUILayout.Button(scaleTimesContent, SCALE_BUTTON_HEIGHT))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale *= scaleAmount;
				}
			}
		}
	}
}
