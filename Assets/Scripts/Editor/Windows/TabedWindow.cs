using System;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.Windows
{
	public abstract class TabedWindow<T>: FoCsWindow<T> where T: FoCsWindow
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
		public abstract Tab<T>[]    Tabs { get; }

		public float TitleBarLabelWidthTotal
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
				using(Disposables.VerticalScope())
				{
					using(var scrollViewScope = Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33)))
					{
						scrolPos = scrollViewScope.scrollPosition;

						using(Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
							DrawHeaderGUI();
					}

					using(Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();
				}
			}
			else
			{
				using(Disposables.VerticalScope())
				{
					using(Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
						DrawHeaderGUI();

					using(Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();
				}
			}
		}

		private void DrawButtom()
		{
			if(TitleBarScrollable)
			{
				using(Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
					DrawActiveTab();

				using(Disposables.VerticalScope())
				{
					using(var scrollViewScope = Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandWidth(true), GUILayout.Height(33)))
					{
						scrolPos = scrollViewScope.scrollPosition;

						using(Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
							DrawHeaderGUI();
					}
				}
			}
			else
			{
				using(Disposables.VerticalScope())
				{
					using(Disposables.VerticalScope(GUILayout.ExpandHeight(true)))
						DrawActiveTab();

					using(Disposables.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
						DrawHeaderGUI();
				}
			}
		}

		private void DrawLeft()
		{
			if(TitleBarScrollable)
			{
				using(Disposables.HorizontalScope(GUILayout.ExpandWidth(true)))
				{
					using(var scrollViewScope = Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal)))
					{
						using(Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth)))
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
				using(Disposables.HorizontalScope())
				{
					using(Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
						DrawHeaderGUI();

					using(Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
						DrawActiveTab();
				}
			}
		}

		private void DrawRight()
		{
			if(TitleBarScrollable)
			{
				using(Disposables.HorizontalScope(GUILayout.ExpandWidth(true)))
				{
					DrawActiveTab();

					using(var scrollViewScope = Disposables.ScrollViewScope(scrolPos, true, GUILayout.ExpandHeight(true), GUILayout.Width(TitleBarLabelWidthTotal)))
					{
						using(Disposables.VerticalScope(GUILayout.Width(TitleBarLabelWidth)))
						{
							scrolPos = scrollViewScope.scrollPosition;
							DrawHeaderGUI();
						}
					}
				}
			}
			else
			{
				using(Disposables.HorizontalScope())
				{
					using(Disposables.VerticalScope(GUILayout.ExpandWidth(true)))
						DrawActiveTab();

					using(Disposables.VerticalScope(EditorStyles.toolbar, GUILayout.Width(TitleBarLabelWidth)))
						DrawHeaderGUI();
				}
			}
		}
	}
}
