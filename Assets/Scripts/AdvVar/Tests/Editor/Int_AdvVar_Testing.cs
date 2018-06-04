using NUnit.Framework;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	internal static class Int_AdvVar_Testing
	{
		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Int_Reference_OnChange_Event()
		{
			var b = false;
			var f = ScriptableObject.CreateInstance<IntReference>();
			f.OnValueChange += () => b = true;
			f.Value         =  6;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Int_Constant_OnChange_Event()
		{
			var         b = false;
			IntVariable f = 5;
			f.OnValueChange += () => b = true;
			f.Value         =  6;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Int_Global_OnChange_Event()
		{
			var b = false;
			var f = new IntVariable {UseConstant = false};
			f.InternalData.GlobalVariable =  ScriptableObject.CreateInstance<IntReference>();
			f.OnValueChange               += () => b = true;
			f.Value                       =  6;
			Assert.True(b);
		}
	}
}
