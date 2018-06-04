using System.Collections.Generic;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	//[FoCsWindow]
	public class EnumCreaterTester: EnumCreatorWindow<EnumCreaterTester>
	{
		private const      string       WindowTitle = "Enum Tester Window";
		private static     List<string> DataList    = new List<string>();
		protected override string       EnumName     => "EnumTester";
		protected override string       EnumNewEntry => "NewEnum";
		protected override string[]     EnumDefault  => new[] {"enumData"};

		protected override List<string> EnumList
		{
			get { return DataList; }
			set { DataList = value; }
		}

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

			if(!GUILayout.Button("Write Tags to disk", GUILayout.Height(32)))
				return;

			WriteDataFile();
			DefineManager.Init();
			Init();
		}
	}
}
