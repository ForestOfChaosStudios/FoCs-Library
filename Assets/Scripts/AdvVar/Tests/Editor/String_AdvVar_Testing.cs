using UnityEngine;
using NUnit.Framework;

namespace ForestOfChaosLib.AdvVar
{
	internal static class String_AdvVar_Testing
	{
		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Reference_OnChange_Event()
		{
			var b = false;
			var f = ScriptableObject.CreateInstance<StringReference>();
			f.OnValueChange += () => b = true;
			f.Value = " ";
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Constant_OnChange_Event()
		{
			var b = false;
			StringVariable f = "";
			f.OnValueChange += () => b = true;
			f.Value = " ";
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Global_OnChange_Event()
		{
			var b = false;
			var f = new StringVariable
					{
						UseConstant = false
					};
			f.InternalData.GlobalVariable = ScriptableObject.CreateInstance<StringReference>();
			f.OnValueChange += () => b = true;
			f.Value = " ";
			Assert.True(b);
		}
	}
}