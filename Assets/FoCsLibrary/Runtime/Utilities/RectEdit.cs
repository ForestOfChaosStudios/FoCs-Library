using UnityEngine;

namespace ForestOfChaosLibrary.Utilities
{
	public class RectEdit
	{
		public enum RectAxis
		{
			X,
			Y,
			Width,
			Height
		}

		/// <summary>
		///     How would you like to edit an axis of the Rect
		/// </summary>
		public enum RectEditType
		{
			/// <summary>
			///     Add to selected axis.
			/// </summary>
			Add,

			/// <summary>
			///     Add to selected axis, remove from parallel axis. e.g. (X + 2 Width - 2)
			/// </summary>
			Change,

			/// <summary>
			///     Set to selected axis.
			/// </summary>
			Set,

			/// <summary>
			///     Multiply to selected axis.
			/// </summary>
			Multiply,

			/// <summary>
			///     Subtract to selected axis.
			/// </summary>
			Subtract,

			/// <summary>
			///     Divide to selected axis.
			/// </summary>
			Divide,

			/// <summary>
			///     Modulo to selected axis.
			/// </summary>
			Modulo
		}

		public float        Amount;
		public RectAxis     Axis;
		public RectEditType Type;

		public RectEdit(RectEditType type, RectAxis axis, float amount)
		{
			Type   = type;
			Axis   = axis;
			Amount = amount;
		}

		public static RectEdit Create(RectEditType    type, RectAxis axis, float amount) => new RectEdit(type, axis, amount);
		public static RectEdit AddX(float             amount) => Create(RectEditType.Add,      RectAxis.X,      amount);
		public static RectEdit AddY(float             amount) => Create(RectEditType.Add,      RectAxis.Y,      amount);
		public static RectEdit AddWidth(float         amount) => Create(RectEditType.Add,      RectAxis.Width,  amount);
		public static RectEdit AddHeight(float        amount) => Create(RectEditType.Add,      RectAxis.Height, amount);
		public static RectEdit ChangeX(float          amount) => Create(RectEditType.Change,   RectAxis.X,      amount);
		public static RectEdit ChangeY(float          amount) => Create(RectEditType.Change,   RectAxis.Y,      amount);
		public static RectEdit ChangeWidth(float      amount) => Create(RectEditType.Change,   RectAxis.Width,  amount);
		public static RectEdit ChangeHeight(float     amount) => Create(RectEditType.Change,   RectAxis.Height, amount);
		public static RectEdit SetX(float             amount) => Create(RectEditType.Set,      RectAxis.X,      amount);
		public static RectEdit SetY(float             amount) => Create(RectEditType.Set,      RectAxis.Y,      amount);
		public static RectEdit SetWidth(float         amount) => Create(RectEditType.Set,      RectAxis.Width,  amount);
		public static RectEdit SetHeight(float        amount) => Create(RectEditType.Set,      RectAxis.Height, amount);
		public static RectEdit MultiplyX(float        amount) => Create(RectEditType.Multiply, RectAxis.X,      amount);
		public static RectEdit MultiplyY(float        amount) => Create(RectEditType.Multiply, RectAxis.Y,      amount);
		public static RectEdit MultiplyWidth(float    amount) => Create(RectEditType.Multiply, RectAxis.Width,  amount);
		public static RectEdit MultiplyHeight(float   amount) => Create(RectEditType.Multiply, RectAxis.Height, amount);
		public static RectEdit SubtractX(float        amount) => Create(RectEditType.Subtract, RectAxis.X,      amount);
		public static RectEdit SubtractY(float        amount) => Create(RectEditType.Subtract, RectAxis.Y,      amount);
		public static RectEdit SubtractWidth(float    amount) => Create(RectEditType.Subtract, RectAxis.Width,  amount);
		public static RectEdit SubtractHeight(float   amount) => Create(RectEditType.Subtract, RectAxis.Height, amount);
		public static RectEdit DivideX(float          amount) => Create(RectEditType.Divide,   RectAxis.X,      amount);
		public static RectEdit DivideY(float          amount) => Create(RectEditType.Divide,   RectAxis.Y,      amount);
		public static RectEdit DivideWidth(float      amount) => Create(RectEditType.Divide,   RectAxis.Width,  amount);
		public static RectEdit DivideHeight(float     amount) => Create(RectEditType.Divide,   RectAxis.Height, amount);
		public static RectEdit ModuloX(float          amount) => Create(RectEditType.Modulo,   RectAxis.X,      amount);
		public static RectEdit ModuloY(float          amount) => Create(RectEditType.Modulo,   RectAxis.Y,      amount);
		public static RectEdit ModuloWidth(float      amount) => Create(RectEditType.Modulo,   RectAxis.Width,  amount);
		public static RectEdit ModuloHeight(float     amount) => Create(RectEditType.Modulo,   RectAxis.Height, amount);
		public static RectEdit[] AddPos(Vector2       newPos) => new[] {AddX(newPos.x), AddY(newPos.y)};
		public static RectEdit[] AddPos(float         x, float y) => new[] {AddX(x), AddY(y)};
		public static RectEdit[] AddSize(Vector2      newPos) => new[] {AddX(newPos.x), AddY(newPos.y)};
		public static RectEdit[] AddSize(float        width, float height) => new[] {AddWidth(width), AddHeight(height)};
		public static RectEdit[] ChangePos(Vector2    newPos) => new[] {ChangeX(newPos.x), ChangeY(newPos.y)};
		public static RectEdit[] ChangePos(float      x, float y) => new[] {ChangeX(x), ChangeY(y)};
		public static RectEdit[] ChangeSize(Vector2   newPos) => new[] {ChangeX(newPos.x), ChangeY(newPos.y)};
		public static RectEdit[] ChangeSize(float     width, float height) => new[] {ChangeWidth(width), ChangeHeight(height)};
		public static RectEdit[] SetPos(Vector2       newPos) => new[] {SetX(newPos.x), SetY(newPos.y)};
		public static RectEdit[] SetPos(float         x, float y) => new[] {SetX(x), SetY(y)};
		public static RectEdit[] SetSize(Vector2      newPos) => new[] {SetWidth(newPos.x), SetHeight(newPos.y)};
		public static RectEdit[] SetSize(float        width, float height) => new[] {SetWidth(width), SetHeight(height)};
		public static RectEdit[] MultiplyPos(Vector2  newPos) => new[] {MultiplyX(newPos.x), MultiplyY(newPos.y)};
		public static RectEdit[] MultiplyPos(float    x, float y) => new[] {MultiplyX(x), MultiplyY(y)};
		public static RectEdit[] MultiplySize(Vector2 newPos) => new[] {MultiplyWidth(newPos.x), MultiplyHeight(newPos.y)};
		public static RectEdit[] MultiplySize(float   width, float height) => new[] {MultiplyWidth(width), MultiplyHeight(height)};
		public static RectEdit[] SubtractPos(Vector2  newPos) => new[] {SubtractX(newPos.x), SubtractY(newPos.y)};
		public static RectEdit[] SubtractPos(float    x, float y) => new[] {SubtractX(x), SubtractY(y)};
		public static RectEdit[] SubtractSize(Vector2 newPos) => new[] {SubtractWidth(newPos.x), SubtractHeight(newPos.y)};
		public static RectEdit[] SubtractSize(float   width, float height) => new[] {SubtractWidth(width), SubtractHeight(height)};
		public static RectEdit[] DividePos(Vector2    newPos) => new[] {DivideX(newPos.x), DivideY(newPos.y)};
		public static RectEdit[] DividePos(float      x, float y) => new[] {DivideX(x), DivideY(y)};
		public static RectEdit[] DivideSize(Vector2   newPos) => new[] {DivideWidth(newPos.x), DivideHeight(newPos.y)};
		public static RectEdit[] DivideSize(float     width, float height) => new[] {DivideWidth(width), DivideHeight(height)};
		public static RectEdit[] ModuloPos(Vector2    newPos) => new[] {ModuloX(newPos.x), ModuloY(newPos.y)};
		public static RectEdit[] ModuloPos(float      x, float y) => new[] {ModuloX(x), ModuloY(y)};
		public static RectEdit[] ModuloSize(Vector2   newPos) => new[] {ModuloWidth(newPos.x), ModuloHeight(newPos.y)};
		public static RectEdit[] ModuloSize(float     width, float height) => new[] {ModuloWidth(width), ModuloHeight(height)};

		public static void Add(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x += pair.Amount;

					break;
				case RectAxis.Y:
					rect.y += pair.Amount;

					break;
				case RectAxis.Width:
					rect.width += pair.Amount;

					break;
				case RectAxis.Height:
					rect.height += pair.Amount;

					break;
			}
		}

		public static void Change(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x     += pair.Amount;
					rect.width -= pair.Amount;

					break;
				case RectAxis.Y:
					rect.y      += pair.Amount;
					rect.height -= pair.Amount;

					break;
				case RectAxis.Width:
					rect.width += pair.Amount;
					rect.x     -= pair.Amount;

					break;
				case RectAxis.Height:
					rect.height += pair.Amount;
					rect.y      -= pair.Amount;

					break;
			}
		}

		public static void Set(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x = pair.Amount;

					break;
				case RectAxis.Y:
					rect.y = pair.Amount;

					break;
				case RectAxis.Width:
					rect.width = pair.Amount;

					break;
				case RectAxis.Height:
					rect.height = pair.Amount;

					break;
			}
		}

		public static void Multiply(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x *= pair.Amount;

					break;
				case RectAxis.Y:
					rect.y *= pair.Amount;

					break;
				case RectAxis.Width:
					rect.width *= pair.Amount;

					break;
				case RectAxis.Height:
					rect.height *= pair.Amount;

					break;
			}
		}

		public static void Subtract(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x -= pair.Amount;

					break;
				case RectAxis.Y:
					rect.y -= pair.Amount;

					break;
				case RectAxis.Width:
					rect.width -= pair.Amount;

					break;
				case RectAxis.Height:
					rect.height -= pair.Amount;

					break;
			}
		}

		public static void Divide(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x /= pair.Amount;

					break;
				case RectAxis.Y:
					rect.y /= pair.Amount;

					break;
				case RectAxis.Width:
					rect.width /= pair.Amount;

					break;
				case RectAxis.Height:
					rect.height /= pair.Amount;

					break;
			}
		}

		public static void Modulo(RectEdit pair, ref Rect rect)
		{
			switch(pair.Axis)
			{
				case RectAxis.X:
					rect.x %= pair.Amount;

					break;
				case RectAxis.Y:
					rect.y %= pair.Amount;

					break;
				case RectAxis.Width:
					rect.width %= pair.Amount;

					break;
				case RectAxis.Height:
					rect.height %= pair.Amount;

					break;
			}
		}
	}
}
