using UnityEngine;
using System.Collections;

public class AspectRatioHandler : MonoBehaviour 
{
		
	public float newAspectRatio = 2560.0f / 1440.0f;
	public Camera camera;
	
	void Awake()
	{
		float variance = newAspectRatio / camera.aspect;
		if (variance < 1.0f) 
		{
			camera.rect = new Rect ((1.0f - variance) / 2.0f, 0f, variance, 1.0f);
		}
		else
		{
			variance = 1.0f / variance;
			camera.rect = new Rect (0f, (1.0f - variance) / 2.0f , 1.0f, variance);
		}
	}

}
