using UnityEngine;
using System.Collections;

namespace hd
{

	public class Memo : MonoBehaviour 
	{
		private Camera uiCamera;
		private Vector3 m_offset = new Vector3(0f,0f,0f);

		// Use this for initialization
		void Start () 
		{
			uiCamera = GameObject.Find ("UICamera").GetComponent<Camera>();
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}

		public void BeginDrag()
		{
			Vector3 screenToWorld = uiCamera.ScreenToWorldPoint (Input.mousePosition);
			m_offset = transform.position - screenToWorld;
		}

		public void OnDrag()
		{
			transform.position = m_offset + uiCamera.ScreenToWorldPoint (Input.mousePosition);
			print ("memo position: " + transform.position);
			print ("mouse position: " + Input.mousePosition);
		}
	
	}

}