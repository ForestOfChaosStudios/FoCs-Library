using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
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

		[MenuItem(FileStrings.JMILES42_SYSTEMS_ + WindowTitle)]
		private static void Init()
		{
			// Get existing open window or if none, make a new one:
			GetWindow();
			window.titleContent = new GUIContent(WindowTitle);

			window.Show();
			window.InitList();
		}

		protected override void DrawGUI()
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