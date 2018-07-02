using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using NUnit.Framework;
using UnityEngine;

namespace ForestOfChaosLib.RectEdits
{
	[FoCsTestingCategory]
	[Category("Rect Edit")]
	internal static class SetTests
	{
		private const           float NUM         = 354745;
		private const           float CHANGED_NUM = 23477;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void SetX()
		{
			var rect = Value.Edit(RectEdit.SetX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(CHANGED_NUM, NUM, NUM, NUM));
		}

		[Test]
		public static void SetY()
		{
			var rect = Value.Edit(RectEdit.SetY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void SetWidth()
		{
			var rect = Value.Edit(RectEdit.SetWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, CHANGED_NUM, NUM));
		}

		[Test]
		public static void SetHeight()
		{
			var rect = Value.Edit(RectEdit.SetHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM, CHANGED_NUM));
		}

		[Test]
		public static void SetPos()
		{
			var rect = Value.Edit(RectEdit.SetPos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(CHANGED_NUM, CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void SetSize()
		{
			var rect = Value.Edit(RectEdit.SetSize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, CHANGED_NUM, CHANGED_NUM));
		}
	}

	[FoCsTestingCategory]
	[Category("Rect Edit")]
	internal static class AddTests
	{
		private const           float NUM         = 5641234;
		private const           float CHANGED_NUM = 423423;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void AddX()
		{
			var rect = Value.Edit(RectEdit.AddX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM + CHANGED_NUM, NUM, NUM, NUM));
		}

		[Test]
		public static void AddY()
		{
			var rect = Value.Edit(RectEdit.AddY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM + CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void AddWidth()
		{
			var rect = Value.Edit(RectEdit.AddWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM + CHANGED_NUM, NUM));
		}

		[Test]
		public static void AddHeight()
		{
			var rect = Value.Edit(RectEdit.AddHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM, NUM + CHANGED_NUM));
		}

		[Test]
		public static void AddPos()
		{
			var rect = Value.Edit(RectEdit.AddPos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM + CHANGED_NUM, NUM + CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void AddSize()
		{
			var rect = Value.Edit(RectEdit.AddSize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM + CHANGED_NUM, NUM + CHANGED_NUM));
		}
	}

	[FoCsTestingCategory]
	[Category("Rect Edit")]
	internal static class MultiplyTests
	{
		private const           float NUM         = 243;
		private const           float CHANGED_NUM = 123;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void MultiplyX()
		{
			var rect = Value.Edit(RectEdit.MultiplyX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM * CHANGED_NUM, NUM, NUM, NUM));
		}

		[Test]
		public static void MultiplyY()
		{
			var rect = Value.Edit(RectEdit.MultiplyY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM * CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void MultiplyWidth()
		{
			var rect = Value.Edit(RectEdit.MultiplyWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM * CHANGED_NUM, NUM));
		}

		[Test]
		public static void MultiplyHeight()
		{
			var rect = Value.Edit(RectEdit.MultiplyHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM, NUM * CHANGED_NUM));
		}

		[Test]
		public static void MultiplyPos()
		{
			var rect = Value.Edit(RectEdit.MultiplyPos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM * CHANGED_NUM, NUM * CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void MultiplySize()
		{
			var rect = Value.Edit(RectEdit.MultiplySize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM * CHANGED_NUM, NUM * CHANGED_NUM));
		}
	}

	[FoCsTestingCategory]
	internal static class SubtractTests
	{
		private const           float NUM         = 7863;
		private const           float CHANGED_NUM = 3453;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void SubtractX()
		{
			var rect = Value.Edit(RectEdit.SubtractX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM - CHANGED_NUM, NUM, NUM, NUM));
		}

		[Test]
		public static void SubtractY()
		{
			var rect = Value.Edit(RectEdit.SubtractY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM - CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void SubtractWidth()
		{
			var rect = Value.Edit(RectEdit.SubtractWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM - CHANGED_NUM, NUM));
		}

		[Test]
		public static void SubtractHeight()
		{
			var rect = Value.Edit(RectEdit.SubtractHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM, NUM - CHANGED_NUM));
		}

		[Test]
		public static void SubtractPos()
		{
			var rect = Value.Edit(RectEdit.SubtractPos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM - CHANGED_NUM, NUM - CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void SubtractSize()
		{
			var rect = Value.Edit(RectEdit.SubtractSize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM - CHANGED_NUM, NUM - CHANGED_NUM));
		}
	}

	[FoCsTestingCategory]
	[Category("Rect Edit")]
	internal static class ChangeTests
	{
		private const           float NUM         = 345;
		private const           float CHANGED_NUM = 423;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void ChangeX()
		{
			var rect = Value.Edit(RectEdit.ChangeX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM + CHANGED_NUM, NUM, NUM - CHANGED_NUM, NUM));
		}

		[Test]
		public static void ChangeY()
		{
			var rect = Value.Edit(RectEdit.ChangeY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM + CHANGED_NUM, NUM, NUM - CHANGED_NUM));
		}

		[Test]
		public static void ChangeWidth()
		{
			var rect = Value.Edit(RectEdit.ChangeWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM - CHANGED_NUM, NUM, NUM + CHANGED_NUM, NUM));
		}

		[Test]
		public static void ChangeHeight()
		{
			var rect = Value.Edit(RectEdit.ChangeHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM - CHANGED_NUM, NUM, NUM + CHANGED_NUM));
		}

		[Test]
		public static void ChangePos()
		{
			var rect = Value.Edit(RectEdit.ChangePos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM + CHANGED_NUM, NUM + CHANGED_NUM, NUM - CHANGED_NUM, NUM - CHANGED_NUM));
		}

		[Test]
		public static void ChangeSize()
		{
			var rect = Value.Edit(RectEdit.ChangeSize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM - CHANGED_NUM, NUM - CHANGED_NUM, NUM + CHANGED_NUM, NUM + CHANGED_NUM));
		}
	}

	[FoCsTestingCategory]
	[Category("Rect Edit")]
	internal static class ModuloTests
	{
		private const           float NUM         = 1234;
		private const           float CHANGED_NUM = 72;
		private static readonly Rect  Value       = new Rect(NUM, NUM, NUM, NUM);

		[Test]
		public static void ModuloX()
		{
			var rect = Value.Edit(RectEdit.ModuloX(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM % CHANGED_NUM, NUM, NUM, NUM));
		}

		[Test]
		public static void ModuloY()
		{
			var rect = Value.Edit(RectEdit.ModuloY(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM % CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void ModuloWidth()
		{
			var rect = Value.Edit(RectEdit.ModuloWidth(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM % CHANGED_NUM, NUM));
		}

		[Test]
		public static void ModuloHeight()
		{
			var rect = Value.Edit(RectEdit.ModuloHeight(CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM, NUM % CHANGED_NUM));
		}

		[Test]
		public static void ModuloPos()
		{
			var rect = Value.Edit(RectEdit.ModuloPos(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM % CHANGED_NUM, NUM % CHANGED_NUM, NUM, NUM));
		}

		[Test]
		public static void ModuloSize()
		{
			var rect = Value.Edit(RectEdit.ModuloSize(CHANGED_NUM, CHANGED_NUM));
			Assert.AreEqual(rect, new Rect(NUM, NUM, NUM % CHANGED_NUM, NUM % CHANGED_NUM));
		}
	}
}