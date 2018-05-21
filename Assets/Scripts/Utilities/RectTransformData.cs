using System;
using UnityEngine;

namespace ForestOfChaosLib.Utilities
{
	[Serializable]
	public class RectTransformData: TransformData
	{
		public Vector2 anchoredPosition;
		public Vector3 anchoredPosition3D;
		public Vector2 anchorMax;
		public Vector2 anchorMin;
		public Vector2 offsetMax;
		public Vector2 offsetMin;
		public Vector2 pivot;
		public Vector2 sizeDelta;

		public RectTransformData(RectTransform transform)
			: base(transform)
		{
			anchoredPosition = transform.anchoredPosition;
			anchoredPosition3D = transform.anchoredPosition3D;
			anchorMax = transform.anchorMax;
			anchorMin = transform.anchorMin;
			offsetMax = transform.offsetMax;
			offsetMin = transform.offsetMin;
			pivot = transform.pivot;
			sizeDelta = transform.sizeDelta;
		}

		public override void ApplyData(Transform transform)
		{
			base.SetData(transform);
			var rectTransform = transform as RectTransform;
			if(rectTransform == null)
				return;

			rectTransform.anchoredPosition = anchoredPosition;
			rectTransform.anchoredPosition3D = anchoredPosition3D;
			rectTransform.anchorMax = anchorMax;
			rectTransform.anchorMin = anchorMin;
			rectTransform.offsetMax = offsetMax;
			rectTransform.offsetMin = offsetMin;
			rectTransform.pivot = pivot;
			rectTransform.sizeDelta = sizeDelta;
		}

		public override void SetData(TransformData transform)
		{
			var data = transform as RectTransformData;
			if(data != null)
				SetData(data);
			else
				base.SetData(transform);
		}

		public void SetData(RectTransformData transform)
		{
			base.SetData(transform);
			anchoredPosition = transform.anchoredPosition;
			anchoredPosition3D = transform.anchoredPosition3D;
			anchorMax = transform.anchorMax;
			anchorMin = transform.anchorMin;
			offsetMax = transform.offsetMax;
			offsetMin = transform.offsetMin;
			pivot = transform.pivot;
			sizeDelta = transform.sizeDelta;
		}

		public override void SetData(Transform transform)
		{
			base.SetData(transform);
			var rectTransform = transform as RectTransform;
			if(rectTransform == null)
				return;

			anchoredPosition = rectTransform.anchoredPosition;
			anchoredPosition3D = rectTransform.anchoredPosition3D;
			anchorMax = rectTransform.anchorMax;
			anchorMin = rectTransform.anchorMin;
			offsetMax = rectTransform.offsetMax;
			offsetMin = rectTransform.offsetMin;
			pivot = rectTransform.pivot;
			sizeDelta = rectTransform.sizeDelta;
		}
	}
}