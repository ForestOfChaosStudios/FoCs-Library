using NUnit.Framework;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[FoCsTestingCategory]
	[Category("AdvVar")]
	internal static class Bool_AdvVar_Testing
	{
		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Bool_Reference_OnChange_Event()
		{
			var b = false;
			var f = ScriptableObject.CreateInstance<BoolReference>();
			f.OnValueChange += () => b = true;
			f.Value         =  true;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Bool_Constant_OnChange_Event()
		{
			var          b = false;
			BoolVariable f = false;
			f.OnValueChange += () => b = true;
			f.Value         =  true;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Bool_Global_OnChange_Event()
		{
			var b = false;
			var f = new BoolVariable {UseLocal = false};
			f.InternalData.GlobalReference =  ScriptableObject.CreateInstance<BoolReference>();
			f.OnValueChange                += () => b = true;
			f.Value                        =  true;
			Assert.True(b);
		}
	}
}