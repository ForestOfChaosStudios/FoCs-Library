using System;
using ForestOfChaosLib.Types;
using UnityEngine;

namespace ForestOfChaosLib.TextureRenderer
{
	[Serializable]
	public class ScanBuffer
	{
		/// <summary>
		/// A 2D array of starting XMin draw positions to XMax draw positions
		/// </summary>
		public int[] Buffer;

		public ImageData ImageData;

		public ScanBuffer(ImageData imageData)
		{
			ImageData = imageData;
			Buffer = new int[imageData.Height * 2];
		}

		/// <summary>
		/// Adds to the buffer
		/// </summary>
		/// <param name="yCoord">Y Coord to add to</param>
		/// <param name="xMin">X pos of image to Start</param>
		/// <param name="xMax">X pos of image to Stop</param>
		public void AddToScanBuffer(int yCoord, int xMin, int xMax)
		{
			if(xMin >= 0 || xMin < Buffer.Length)
				Buffer[yCoord * 2] = xMin;
			if(xMax >= 0 || xMax < Buffer.Length)
				Buffer[yCoord * 2 + 1] = xMax;
		}

		/// <summary>
		/// Draws the buffer starting at Y Min to Y Max
		/// </summary>
		public ImageData DrawBuffer()
		{
			return DrawBuffer(0, ImageData.Height, Colour.Magenta);
		}

		/// <summary>
		/// Draws the buffer starting at Y Min to Y Max
		/// </summary>
		/// <param name="colour">The colour to draw the buffer</param>
		public ImageData DrawBuffer(Colour colour)
		{
			return DrawBuffer(0, ImageData.Height, colour);
		}

		/// <summary>
		/// Draws the buffer starting at Y Min to Y Max
		/// </summary>
		/// <param name="yMin">Min to draw from</param>
		/// <param name="yMax">Max to draw to</param>
		public ImageData DrawBuffer(int yMin, int yMax)
		{
			return DrawBuffer(yMin, yMax, Colour.Magenta);
		}

		/// <summary>
		/// Draws the buffer starting at Y Min to Y Max
		/// </summary>
		/// <param name="yMin">Min to draw from</param>
		/// <param name="yMax">Max to draw to</param>
		/// <param name="colour">The colour to draw the buffer</param>
		public ImageData DrawBuffer(int yMin, int yMax, Colour colour)
		{
			if(yMin < 0 || yMax < 0)
				return null;

			for(int j = yMin; j < yMax; j++)
			{
				if(j < 0 || j * 2 >= Buffer.Length)
					continue;
				int xMin = Buffer[j * 2];
				int xMax = Buffer[j * 2 + 1];
				for(int i = xMin; i < xMax; i++)
				{
					ImageData.DrawPixel(i, j, colour);
				}
			}
			return ImageData;
		}

		/// <summary>
		/// Adds a Triangle to the Draw buffer
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		public void FillTriangle(Vertex v1, Vertex v2, Vertex v3)
		{
			var minYVertex = v1;
			var midYVertex = v2;
			var maxYVertex = v3;

			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			if(midYVertex.Position.y < minYVertex.Position.y)
			{
				var temp = midYVertex;
				midYVertex = minYVertex;
				minYVertex = temp;
			}
			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			float area = TriangleAreaTimesTwo(minYVertex, maxYVertex, midYVertex);
			int handedness = area >= 0? 1 : 0;
			ScanConvertTriangle(minYVertex, midYVertex, maxYVertex, handedness);

			DrawBuffer((int)minYVertex.Position.y, (int)maxYVertex.Position.y);
		}

		/// <summary>
		/// Adds a Triangle to the Draw buffer
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		/// <param name="colour">The colour to draw the buffer</param>
		public void FillTriangle(Vertex v1, Vertex v2, Vertex v3, Colour colour)
		{
			var minYVertex = v1;
			var midYVertex = v2;
			var maxYVertex = v3;

			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			if(midYVertex.Position.y < minYVertex.Position.y)
			{
				var temp = midYVertex;
				midYVertex = minYVertex;
				minYVertex = temp;
			}
			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			float area = TriangleAreaTimesTwo(minYVertex, maxYVertex, midYVertex);
			int handedness = area >= 0? 1 : 0;
			ScanConvertTriangle(minYVertex, midYVertex, maxYVertex, handedness);

			DrawBuffer((int)minYVertex.Position.y, (int)maxYVertex.Position.y, colour);
		}

		/// <summary>
		/// Adds a Colour.Magenta Triangle to the Draw buffer with the screen space Matrix
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		public void FillTriangleM(Vertex v1, Vertex v2, Vertex v3)
		{
			FillTriangleM(v1, v2, v3, Colour.Magenta);
		}

		/// <summary>
		/// Adds a Coloured Triangle to the Draw buffer with the screen space Matrix
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		/// <param name="col">Colour to draw the Triangle.</param>
		public void FillTriangleM(Vertex v1, Vertex v2, Vertex v3, Colour col)
		{
			Matrix4by4 screanspaceTransform = new Matrix4by4().InitScreenSpaceTransform(ImageData.HalfWidth, ImageData.HalfHeight);

			var minYVertex = v1.Transform(screanspaceTransform).PerspectiveDivide();
			var midYVertex = v2.Transform(screanspaceTransform).PerspectiveDivide();
			var maxYVertex = v3.Transform(screanspaceTransform).PerspectiveDivide();

			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			if(midYVertex.Position.y < minYVertex.Position.y)
			{
				var temp = midYVertex;
				midYVertex = minYVertex;
				minYVertex = temp;
			}
			if(maxYVertex.Position.y < midYVertex.Position.y)
			{
				var temp = maxYVertex;
				maxYVertex = midYVertex;
				midYVertex = temp;
			}
			float area = TriangleAreaTimesTwo(minYVertex, maxYVertex, midYVertex);
			int handedness = area >= 0? 1 : 0;
			ScanConvertTriangle(minYVertex, midYVertex, maxYVertex, handedness);

			DrawBuffer((int)minYVertex.Position.y, (int)maxYVertex.Position.y, col);
		}

		public void FillTriangleH(Vector2[] arr, Colour col)
		{
			if(arr.Length != 3)
				return;
			FillTriangleH(arr[0], arr[1], arr[2], col);
		}

		public void FillTriangleH(Vector3[] arr, Colour col)
		{
			if(arr.Length != 3)
				return;
			FillTriangleH(arr[0], arr[1], arr[2], col);
		}

		public void FillTriangleH(Vector3 v1, Vector3 v2, Vector3 v3, Colour col)
		{
			var minMidMax = new MinMidMaxVector3(v1, v2, v3, ImageData);
			float area = TriangleAreaTimesTwo(minMidMax.LeftMost, minMidMax.RightMost, minMidMax.Middle);
			int handedness = area >= 0? 1 : 0;
			ScanConvertTriangle(minMidMax.LeftMost, minMidMax.Middle, minMidMax.RightMost, handedness);

			DrawBuffer((int)minMidMax.LeftMost.y, (int)minMidMax.RightMost.y, col);
		}

		public void FillTriangleH(Vertex v1, Vertex v2, Vertex v3, Colour col)
		{
			var minMidMax = new MinMidMaxVector3(v1, v2, v3, ImageData);
			float area = TriangleAreaTimesTwo(minMidMax.LeftMost, minMidMax.RightMost, minMidMax.Middle);
			int handedness = area >= 0? 1 : 0;
			ScanConvertTriangle(minMidMax.LeftMost, minMidMax.Middle, minMidMax.RightMost, handedness);

			DrawBuffer((int)minMidMax.LeftMost.y, (int)minMidMax.RightMost.y, col);
		}

		/// <summary>
		/// Caclulates 2 times the triangles size.
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		/// <returns>2x The area of the triangle</returns>
		public static float TriangleAreaTimesTwo(Vertex v1, Vertex v2, Vertex v3)
		{
			float x1 = v2.Position.x - v1.Position.x;
			float y1 = v2.Position.y - v1.Position.y;

			float x2 = v3.Position.x - v1.Position.x;
			float y2 = v3.Position.y - v1.Position.y;

			return (x1 * y2) - (x2 * y1);
		}

		/// <summary>
		/// Caclulates 2 times the triangles size.
		/// </summary>
		/// <param name="v1">Point v1 of the triangle. Any order.</param>
		/// <param name="v2">Point v2 of the triangle. Any order.</param>
		/// <param name="v3">Point v3 of the triangle. Any order.</param>
		/// <returns>2x The area of the triangle</returns>
		public static float TriangleAreaTimesTwo(Vector3 v1, Vector3 v2, Vector3 v3)
		{
			float x1 = v2.x - v1.x;
			float y1 = v2.y - v1.y;

			float x2 = v3.x - v1.x;
			float y2 = v3.y - v1.y;

			return (x1 * y2) - (x2 * y1);
		}

		/// <summary>
		/// Adds a triangle to the Draw buffer
		/// </summary>
		/// <param name="minYVertex"></param>
		/// <param name="midYVertex"></param>
		/// <param name="maxYVertex"></param>
		/// <param name="handedness">Will it right to the Left(0) or Right(1) of the buffer</param>
		public void ScanConvertTriangle(Vertex minYVertex, Vertex midYVertex, Vertex maxYVertex, int handedness)
		{
			ScanConvertLine(minYVertex, maxYVertex, 0 + handedness);
			ScanConvertLine(minYVertex, midYVertex, 1 - handedness);
			ScanConvertLine(midYVertex, maxYVertex, 1 - handedness);
		}

		/// <summary>
		/// Adds a line to the draw buffer
		/// </summary>
		/// <param name="minYVertex">The Left most on the Y vertex</param>
		/// <param name="maxYVertex">The Right most on the Y vertex</param>
		/// <param name="handedness">Will it right to the Left(0) or Right(1) of the buffer</param>
		public void ScanConvertLine(Vertex minYVertex, Vertex maxYVertex, int handedness)
		{
			int yStart = (int)minYVertex.Position.y;
			int yEnd = (int)maxYVertex.Position.y;
			int xStart = (int)minYVertex.Position.x;
			int xEnd = (int)maxYVertex.Position.x;
			int yDist = yEnd - yStart;
			int xDist = xEnd - xStart;

			if(yDist <= 0 || yDist >= Buffer.Length)
				return;
			float xStep = (float)xDist / (float)yDist;
			float curX = xStart;
			if(xStart < 0 || yStart < 0)
				return;
			for(int j = yStart; j < yEnd; j++)
			{
				if(j < 0 || j * 2 >= Buffer.Length)
					continue;
				Buffer[(j * 2) + handedness] = (int)curX;
				curX += xStep;
			}
		}

		/// <summary>
		/// Adds a line to the draw buffer
		/// </summary>
		/// <param name="minYVertex">The Left most on the Y vertex</param>
		/// <param name="maxYVertex">The Right most on the Y vertex</param>
		/// <param name="handedness">Will it right to the Left(0) or Right(1) of the buffer</param>
		public void ScanConvertLineH(Vertex minYVertex, Vertex maxYVertex, int handedness)
		{
			int yStart = (int)(minYVertex.Position.y + ImageData.HalfHeight);
			int yEnd = (int)(maxYVertex.Position.y + ImageData.HalfHeight);
			int xStart = (int)(minYVertex.Position.x + ImageData.HalfWidth);
			int xEnd = (int)(maxYVertex.Position.x + ImageData.HalfWidth);
			int yDist = yEnd - yStart;
			int xDist = xEnd - xStart;

			if(yDist <= 0 || yDist >= Buffer.Length)
				return;
			float xStep = (float)xDist / (float)yDist;
			float curX = xStart;
			if(xStart < 0 || yStart < 0)
				return;
			for(int j = yStart; j < yEnd; j++)
			{
				if(j < 0 || j * 2 >= Buffer.Length)
					continue;
				Buffer[(j * 2) + handedness] = (int)curX;
				curX += xStep;
			}
		}

		public struct MinMidMaxVector3
		{
			public Vector3 LeftMost;
			public Vector3 Middle;
			public Vector3 RightMost;

			public MinMidMaxVector3(Vector3 v1, Vector3 v2, Vector3 v3)
			{
				LeftMost = v1;
				Middle = v2;
				RightMost = v3;

				if(RightMost.y < Middle.y)
				{
					var temp = RightMost;
					RightMost = Middle;
					Middle = temp;
				}
				if(Middle.y < LeftMost.y)
				{
					var temp = Middle;
					Middle = LeftMost;
					LeftMost = temp;
				}
				if(RightMost.y < Middle.y)
				{
					var temp = RightMost;
					RightMost = Middle;
					Middle = temp;
				}
			}

			public MinMidMaxVector3(Vector3 v1, Vector3 v2, Vector3 v3, ImageData ImageData)
			{
				LeftMost = v1;
				Middle = v2;
				RightMost = v3;

				LeftMost.y += ImageData.HalfHeight;
				Middle.y += ImageData.HalfHeight;
				RightMost.y += ImageData.HalfHeight;

				LeftMost.x += ImageData.HalfWidth;
				Middle.x += ImageData.HalfWidth;
				RightMost.x += ImageData.HalfWidth;

				if(RightMost.y < Middle.y)
				{
					var temp = RightMost;
					RightMost = Middle;
					Middle = temp;
				}
				if(Middle.y < LeftMost.y)
				{
					var temp = Middle;
					Middle = LeftMost;
					LeftMost = temp;
				}
				if(RightMost.y < Middle.y)
				{
					var temp = RightMost;
					RightMost = Middle;
					Middle = temp;
				}
			}
		}
	}
}