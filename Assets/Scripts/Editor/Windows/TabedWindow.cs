using System;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	public abstract class TabedWindow<T>: FoCsWindow<T> where T: EditorWindow
	{
		public enum TitleBarPos
		{
			Top,
			Buttom,
			Left,
			Right
		}

		public          int         activeTab;
		private         Vector2     scrolPos           = Vector2.zero;
		public          float       TitleBarLabelWidth = 100;
		public          TitleBarPos TitleBarPosition   = TitleBarPos.Top;
		public          bool        TitleBarScrollable;
		public abstract Tab<T>[]    Tabs                    { get; }
		public          float       TitleBarLabelWidthTotal
		{
			get { return TitleBarScrollable? TitleBarLabelWidth + 20 : TitleBarLabelWidth; }
		}

		protected override void OnGUI()
		{
			switch(TitleBarPosition)
			{
				case TitleBarPos.Top:
					DrawTop();

					break;
				case TitleBarPos.Buttom:
					DrawButtom();

					break;
				case TitleBarPos.Left:
					DrawLeft();

					break;
				case TitleBarPos.Right:
					DrawRight();

					break;
				default: throw new ArgumentOutOfRangeException();
			}
		}

		private void DrawActiveTab()
		{
			if(!Tabs.IsNullOrEmpty())
				Tabs[activeTab].DrawTab(this);
		}

		private void DrawHeaderGUI()
		{
			for(var i = 0; i < Tabs.Length; i++)
			{
				if(Tabs[i] != null)
				{
					if(GUILayout.Toggle(i == activeTab, Tabs[i].TabName, EditorStyles.toolbarButton, GUILayout.MinWidth(TitleBarLabelWidth)))
						activeTab = i;
				}
			}
		}

		private void DrawTop()
		{
			if(TitleBarScrollable)
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					using(var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33)))
					{
						scrolPos = scrollViewScope.scrollPosition;

						using(FoCsEditor.Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
							DrawHeaderGUI();
					}

					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();
				}
			}
			else
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					using(FoCsEditor.Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
						DrawHeaderGUI();

					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();
				}
			}
		}

		private void DrawButtom()
		{
			if(TitleBarScrollable)
			{
				using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
					DrawActiveTab();

				using(FoCsEditor.Disposables.VerticalScope())
				{
					using(var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33)))
					{
						scrolPos = scrollViewScope.scrollPosition;

						using(FoCsEditor.Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
							DrawHeaderGUI();
					}
				}
			}
			else
			{
				using(FoCsEditor.Disposables.VerticalScope())
				{
					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();

					using(FoCsEditor.Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
						DrawHeaderGUI();
				}
			}
		}

		private void DrawLeft()
		{
			if(TitleBarScrollable)
			{
				using(FoCsEditor.Disposables.HorizontalScope(GUILayout.ExpandWidth(true)))
				{
					using(var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal)))
					{
						using(FoCsEditor.Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth)))
						{
							scrolPos = scrollViewScope.scrollPosition;
							DrawHeaderGUI();
						}
					}

					DrawActiveTab();
				}
			}
			else
			{
				using(FoCsEditor.Disposables.HorizontalScope())
				{
					using(FoCsEditor.Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
						DrawHeaderGUI();

					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
						DrawActiveTab();
				}
			}
		}

		private void DrawRight()
		{
			if(TitleBarScrollable)
			{
				using(FoCsEditor.Disposables.HorizontalScope(GUILayout.ExpandWidth(true)))
				{
					DrawActiveTab();

					using(var scrollViewScope = FoCsEditor.Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal)))
					{
						using(FoCsEditor.Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth)))
						{
							scrolPos = scrollViewScope.scrollPosition;
							DrawHeaderGUI();
						}
					}
				}
			}
			else
			{
				using(FoCsEditor.Disposables.HorizontalScope())
				{
					using(FoCsEditor.Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
						DrawActiveTab();

					using(FoCsEditor.Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
						DrawHeaderGUI();
				}
			}
		}
	}
}