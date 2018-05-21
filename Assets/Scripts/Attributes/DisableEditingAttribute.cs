using UnityEngine;

namespace ForestOfChaosLib.Attributes
{
	public class DisableEditingAttribute: PropertyAttribute
	{
		public bool AllowConfirmedEdit;
		public bool CurrentlyEditable;

		public DisableEditingAttribute()
		{ }

		public DisableEditingAttribute(bool _AllowConfirmedEdit)
		{
			AllowConfirmedEdit = _AllowConfirmedEdit;
		}

		public DisableEditingAttribute(bool _AllowConfirmedEdit, bool _CurrentlyEditable): this(_AllowConfirmedEdit)
		{
			CurrentlyEditable = _CurrentlyEditable;
		}
	}
}