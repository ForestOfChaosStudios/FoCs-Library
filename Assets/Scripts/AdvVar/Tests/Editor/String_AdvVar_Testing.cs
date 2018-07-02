using NUnit.Framework;
using UnityEngine;

namespace ForestOfChaosLib.AdvVar
{
	[FoCsTestingCategory]
	[Category("AdvVar")]
	internal static class String_AdvVar_Testing
	{
		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Reference_OnChange_Event()
		{
			var b = false;
			var f = ScriptableObject.CreateInstance<StringReference>();
			f.OnValueChange += () => b = true;
			f.Value         =  " ";
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Constant_OnChange_Event()
		{
			var            b = false;
			StringVariable f = "";
			f.OnValueChange += () => b = true;
			f.Value         =  " ";
			Assert.True(b);
		}

		[Test(Author = "Jordan Miles", Description = "To Test the OnValueChanged Event")]
		public static void String_Global_OnChange_Event()
		{
			var b = false;
			var f = new StringVariable {UseLocal = false};
			f.InternalData.GlobalReference =  ScriptableObject.CreateInstance<StringReference>();
			f.OnValueChange                += () => b = true;
			f.Value                        =  " ";
			Assert.True(b);
		}
	}
}