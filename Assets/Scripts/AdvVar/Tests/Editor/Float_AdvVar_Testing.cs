using UnityEngine;
using NUnit.Framework;

namespace ForestOfChaosLib.AdvVar
{
	internal static class Float_AdvVar_Testing
	{
		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Float_Reference_OnChange_Event()
		{
			var b = false;
			var f = ScriptableObject.CreateInstance<FloatReference>();
			f.OnValueChange += () => b = true;
			f.Value = 6;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Float_Constant_OnChange_Event()
		{
			var b = false;
			FloatVariable f = 5;
			f.OnValueChange += () => b = true;
			f.Value = 6;
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void Float_Global_OnChange_Event()
		{
			var b = false;
			var f = new FloatVariable
					{
						UseConstant = false
					};
			f.InternalData.GlobalVariable = ScriptableObject.CreateInstance<FloatReference>();
			f.OnValueChange += () => b = true;
			f.Value = 6;
			Assert.True(b);
		}
	}
}