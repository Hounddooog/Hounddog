using UnityEngine;
using System.Collections;

namespace hd
{

public class WorldmapHandler : MonoBehaviour 
{
	private Vector3 m_startCoordinates;
	private bool m_bMoving = false;

	void Start () 
	{
		m_startCoordinates = Camera.main.transform.position;
		
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && !m_bMoving)
		{	
			if(Camera.main.transform.position == m_startCoordinates) 
			{
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) 
				{
					//print (hit.collider.name);
					//print (hit.point);
					Vector3 movePoint = hit.point + new Vector3(0f,0f,-1f);
					MoveCamera(movePoint);
				}
			} 
			else
			{
				print ("move camera back to start coordinates");
				MoveCamera(m_startCoordinates);
			}
		}
	}

	void MoveCamera(Vector3 pos)
	{
		m_bMoving = true;
		iTween.MoveTo(Camera.main.gameObject, iTween.Hash(
												"position", pos,
												"time", 1f,
												"oncompletetarget", gameObject,
												"oncomplete", "MoveFinished"));
	}

	void MoveFinished()
	{
		print("Camera move finished");
		m_bMoving = false;
	}
}

}
