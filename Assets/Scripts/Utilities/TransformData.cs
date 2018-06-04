using System;
using UnityEngine;

namespace ForestOfChaosLib.Utilities
{
	[Serializable]
	public class TransformData
	{
		public        Vector3       Position;
		public        Quaternion    Rotation;
		public        Vector3       Scale;
		public static TransformData Empty { get; } = new TransformData(Vector3.zero, Quaternion.identity, Vector3.one);

		public TransformData(Transform transform)
		{
			Rotation = transform.rotation;
			Scale    = transform.localScale;
			Position = transform.position;
		}

		public TransformData(TransformData transform)
		{
			Rotation = transform.Rotation;
			Scale    = transform.Scale;
			Position = transform.Position;
		}

		public TransformData(Vector3 position)
		{
			Rotation = Quaternion.identity;
			Scale    = Vector3.one;
			Position = position;
		}

		public TransformData(Vector3 position, Quaternion rotation)
		{
			Rotation = rotation;
			Scale    = Vector3.one;
			Position = position;
		}

		public TransformData(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Rotation = rotation;
			Scale    = scale;
			Position = position;
		}

		public virtual void SetData(Transform transform)
		{
			Rotation = transform.rotation;
			Scale    = transform.localScale;
			Position = transform.position;
		}

		public virtual void SetData(TransformData transform)
		{
			Rotation = transform.Rotation;
			Scale    = transform.Scale;
			Position = transform.Position;
		}

		public void SetData(Vector3 position)
		{
			Rotation = Quaternion.identity;
			Scale    = Vector3.one;
			Position = position;
		}

		public void SetData(Vector3 position, Quaternion rotation)
		{
			Rotation = rotation;
			Scale    = Vector3.one;
			Position = position;
		}

		public void SetData(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Rotation = rotation;
			Scale    = scale;
			Position = position;
		}

		public virtual void ApplyData(Transform transform)
		{
			transform.rotation   = Rotation;
			transform.localScale = Scale;
			transform.position   = Position;
		}

		public static implicit operator TransformData(Transform  input) => new TransformData(input);
		public static implicit operator TransformData(Component  input) => new TransformData(input.transform);
		public static implicit operator TransformData(GameObject input) => new TransformData(input.transform);

		public static TransformData Create(Transform transform)
		{
			var rectTransform = transform as RectTransform;

			if(rectTransform != null)
				return new RectTransformData(rectTransform);

			return new TransformData(transform);
		}
	}

	public static class TransformDataExtn
	{
		public static void Set(this Transform transform, TransformData data)
		{
			data.ApplyData(transform);
		}
	}
}
