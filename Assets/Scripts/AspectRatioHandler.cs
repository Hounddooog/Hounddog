using UnityEngine;
using System.Collections;

namespace hd
{
	[RequireComponent (typeof(Camera))]
	public class AspectRatioHandler : MonoBehaviour 
	{
			
		public float newAspectRatio = 2560.0f / 1440.0f;

		void Awake()
		{
			Camera cam = gameObject.GetComponent<Camera> ();

			float variance = newAspectRatio / cam.aspect;
			if (variance < 1.0f) 
			{
				cam.rect = new Rect ((1.0f - variance) / 2.0f, 0f, variance, 1.0f);
			}
			else
			{
				variance = 1.0f / variance;
				cam.rect = new Rect (0f, (1.0f - variance) / 2.0f , 1.0f, variance);
			}
		}

	}

}
