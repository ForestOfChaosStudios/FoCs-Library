using System;

namespace ForestOfChaosLib.AdvVar
{
	public class AdvFolderNameAttribute: Attribute, IComparable, IComparable<AdvFolderNameAttribute>
	{
		private readonly InternalNames _InternalNames;
		public string ToggleName;

		public AdvFolderNameAttribute()
		{
			ToggleName = "";
			_InternalNames = InternalNames.Other;
		}

		public AdvFolderNameAttribute(string toggleName)
		{
			ToggleName = toggleName;
			_InternalNames = InternalNames.Other;
		}

		protected AdvFolderNameAttribute(InternalNames toggleName)
		{
			ToggleName = toggleName.ToString();
			_InternalNames = toggleName;
		}

		public int CompareTo(object obj)
		{
			if(ReferenceEquals(null, obj))
				return 1;
			if(ReferenceEquals(this, obj))
				return 0;
			if(!(obj is AdvFolderNameAttribute))
				throw new ArgumentException($"Object must be of type {nameof(AdvFolderNameAttribute)}");
			return CompareTo((AdvFolderNameAttribute)obj);
		}

		public int CompareTo(AdvFolderNameAttribute other)
		{
			if(ReferenceEquals(this, other))
				return 0;
			if(ReferenceEquals(null, other))
				return 1;
			if(other._InternalNames == InternalNames.Other)
				return string.Compare(ToggleName, other.ToggleName, StringComparison.Ordinal);
			return (int)_InternalNames.CompareTo(other._InternalNames);
		}

		protected enum InternalNames
		{
			SystemTypes,
			SystemTypeLists,
			Unity,
			UnityLists,
			ForestOfChaos,
			ForestOfChaosLists,
			RunTime,
			Other
		}
	}
	#region Internal Classes
	internal class AdvFolderNameUnityAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameUnityAttribute()
			: base(InternalNames.Unity)
		{ }
	}

	internal class AdvFolderNameUnityListsAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameUnityListsAttribute()
			: base(InternalNames.UnityLists)
		{ }
	}

	internal class AdvFolderNameSystemAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameSystemAttribute()
			: base(InternalNames.SystemTypes)
		{ }
	}

	internal class AdvFolderNameSystemTypeListsAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameSystemTypeListsAttribute()
			: base(InternalNames.SystemTypeLists)
		{ }
	}

	internal class AdvFolderNameForestOfChaosAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameForestOfChaosAttribute()
			: base(InternalNames.ForestOfChaos)
		{ }
	}

	internal class AdvFolderNameForestOfChaosListsAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameForestOfChaosListsAttribute()
			: base(InternalNames.ForestOfChaosLists)
		{ }
	}

	internal class AdvFolderNameRunTimeAttribute: AdvFolderNameAttribute
	{
		public AdvFolderNameRunTimeAttribute()
			: base(InternalNames.RunTime)
		{ }
	}
	#endregion
}