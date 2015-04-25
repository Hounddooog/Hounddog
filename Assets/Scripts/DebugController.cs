using UnityEngine;
using System.Collections;

// Collection of stuff used in debugging purposes

namespace hd
{

	public class DebugController : MonoBehaviour 
	{

		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			if (Input.GetKey ("escape")) 
			{
				Application.Quit ();
			}
		}
	}

}