using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	//[FoCsWindow]
	public class EnumCreaterTester: EnumCreatorWindow<EnumCreaterTester>
	{
		protected override string EnumName
		{
			get { return "EnumTester"; }
		}

		protected override string EnumNewEntry
		{
			get { return "NewEnum"; }
		}

		protected override string[] EnumDefault
		{
			get { return new[] {"enumData"}; }
		}

		protected override List<string> EnumList
		{
			get { return DataList; }
			set { DataList = value; }
		}

		private const string WindowTitle = "Enum Tester Window";

		private static List<string> DataList = new List<string>();

		//[MenuItem(FileStrings.FORESTOFCHAOS_SYSTEMS_ + WindowTitle)]
		private static void Init()
		{
			// Get existing open window or if none, make a new one:
			GetWindowAndShow();
			Window.titleContent = new GUIContent(WindowTitle);

			Window.Show();
			Window.InitList();
		}

		protected override void OnGUI()
		{
			DrawList();
			if(GUILayout.Button("Write Tags to disk", GUILayout.Height(32)))
			{
				WriteDataFile();
				DefineManager.Init();
				Init();
			}
		}
	}
}