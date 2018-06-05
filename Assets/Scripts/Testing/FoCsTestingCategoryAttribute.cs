using NUnit.Framework;

namespace ForestOfChaosLib
{
	public class FoCsTestingCategoryAttribute: CategoryAttribute
	{
		public FoCsTestingCategoryAttribute(): base("ForestOfChaosLib") { }
	}
}