using UnityEngine;
using System.Collections;

namespace hd
{

public class WorldmapHandler : MonoBehaviour 
{
	public GameObject cam;
	public float lerpTime = 1f;
	public float zoom = 2f;

	private Vector3 m_startCoordinates;
	private bool m_bZoomIn = false;
	private bool m_bZoomOut = false;
	private float m_currentLerpTime = 0f;
	private Vector3 m_targetPos;

	private Camera c;
	private float m_startSize;


	void Start () 
	{
		m_startCoordinates = cam.transform.position;
		c = cam.GetComponent<Camera>();
		m_startSize = c.orthographicSize;
		
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && !m_bZoomIn && !m_bZoomOut)
		{	
			if(c.transform.position == m_startCoordinates) 
			{
				RaycastHit2D hit = Physics2D.Raycast(new Vector2(c.ScreenToWorldPoint(Input.mousePosition).x,
					                                             c.ScreenToWorldPoint(Input.mousePosition).y), 
					                                     Vector2.zero, 0);
				if (hit.collider != null && hit.collider.tag == "City") 
				{
					Vector3 movePoint = new Vector3(hit.point.x, hit.point.y, 0f);
					m_targetPos = movePoint;
					m_bZoomIn = true;
					m_currentLerpTime = 0f;
				}
			}
			else if(c.transform.position != m_startCoordinates)
			{
				m_bZoomOut = true;
				m_currentLerpTime = 0f;
				m_targetPos = cam.transform.position;
			}
		}
		
		if (m_bZoomIn || m_bZoomOut) 
		{
			m_currentLerpTime += Time.deltaTime;
		}

		if (m_bZoomIn) 
		{
			c.orthographicSize = Mathf.Lerp(m_startSize, m_startSize/zoom, m_currentLerpTime/lerpTime);
			c.transform.position = Vector3.Lerp(m_startCoordinates, m_targetPos, m_currentLerpTime/lerpTime);
			if (m_currentLerpTime > lerpTime) 
			{
				c.transform.position = m_targetPos;
				m_bZoomIn = false;	
			}
	
		}
		else if(m_bZoomOut)
		{
			c.orthographicSize = Mathf.Lerp( m_startSize/zoom, m_startSize, m_currentLerpTime/lerpTime);
			c.transform.position = Vector3.Lerp(m_targetPos, m_startCoordinates, m_currentLerpTime/lerpTime);
			if(m_currentLerpTime > lerpTime) 
			{
				c.transform.position = m_startCoordinates;
				m_bZoomOut = false;
			}
		}
	}



	void MoveFinished()
	{
		print("Camera move finished");
		m_bZoomIn = false;
		m_bZoomOut = false;
	}
}

}
