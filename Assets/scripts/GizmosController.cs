using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class GizmosController : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		//transform.Rotate
		//gameObject.transform.rotate
		//gameObject.transform.RotateAround(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z))+offset,Vector3.up, 20 * Time.deltaTime);
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint)+offset;
		transform.position = curPosition;

		//make it snap
		Vector3 worldPos = transform.position;
		float xSnap = Mathf.Round(worldPos.x);
		float zSnap = Mathf.Round(worldPos.z);
		if (Mathf.Round (worldPos.x) > 9) 
		{
			xSnap = 9;
		} 
		else if (Mathf.Round (worldPos.x) < -9) 
		{
			xSnap = -9;
		}
		if (Mathf.Round(worldPos.z) >9) 
		{
			zSnap = 9;
		} 
		else if (Mathf.Round(worldPos.z) <-9) 
		{
			zSnap=-9;
		}
		transform.position = new Vector3(xSnap,worldPos.y,zSnap);

	}
}
