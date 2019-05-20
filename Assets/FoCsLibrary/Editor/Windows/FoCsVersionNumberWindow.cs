using System.Linq;
using ForestOfChaosLibrary.Editor.UnitySettings;
using ForestOfChaosLibrary.Editor.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLibrary.Editor.Windows
{
	[FoCsWindow]
	public class FoCsVersionNumberWindow: FoCsWindow<FoCsVersionNumberWindow>
	{
		private const           string             TITLE   = "Version Number";
		private static readonly GUIContent         Heading = new GUIContent("Bundle Version");
		private static          SerializedObject   SerializedObject;
		private                 string             versionNumber;
		private static          SerializedProperty BundleVersion => SerializedObject.FindProperty("bundleVersion");

		[MenuItem(FileStrings.FORESTOFCHAOS_TOOLS_ + TITLE)]
		internal static void Init()
		{
			GetWindowAndShow();
			Window.titleContent.text = TITLE;
		}

		private void OnEnable()
		{
			SerializedObject = new SerializedObject(UnitySettingsReader.ProjectSettings.Assets.First());
			versionNumber    = BundleVersion.stringValue;
		}

		protected override void OnGUI()
		{
			FoCsGUI.Layout.Label(Heading);

			using(Disposables.HorizontalScope())
			{
				using(var cc = Disposables.ChangeCheck())
				{
					versionNumber = FoCsGUI.Layout.DelayedTextField(versionNumber);

					if(cc.changed)
					{
						BundleVersion.stringValue = versionNumber;
						SerializedObject.ApplyModifiedProperties();
					}
				}
			}
		}
	}
}
