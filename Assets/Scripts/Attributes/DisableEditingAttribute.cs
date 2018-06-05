using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class DisableEditingAttribute: PropertyAttribute
	{
		public bool AllowConfirmedEdit;
		public bool CurrentlyEditable;

		public DisableEditingAttribute()
		{
			AllowConfirmedEdit = false;
			CurrentlyEditable  = false;
		}

		public DisableEditingAttribute(bool allowConfirmedEdit)
		{
			AllowConfirmedEdit = allowConfirmedEdit;
		}

		public DisableEditingAttribute(bool allowConfirmedEdit, bool currentlyEditable): this(allowConfirmedEdit)
		{
			CurrentlyEditable = currentlyEditable;
		}
	}
}
