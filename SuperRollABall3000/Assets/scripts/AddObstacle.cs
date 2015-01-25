using UnityEngine;
using System.Collections;

public class AddObstacle : MonoBehaviour
{
	public GameObject pickups;
	public GameObject pickup;	
	public GameObject obstacles;
	public GameObject block;

	public bool toggle=true;

	public void AddBlock()
	{
		GameObject newBlock =(GameObject) Instantiate(block, new Vector3(0,0,0), Quaternion.identity);
		newBlock.transform.parent = obstacles.transform;
	}

	public void AddPickup()
	{
		GameObject newPickup = (GameObject)Instantiate(pickup, new Vector3(0,0,0), Quaternion.identity);
		newPickup.transform.parent = pickups.transform;
	}
}