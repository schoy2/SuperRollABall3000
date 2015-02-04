using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject gamePlay;
	private Vector3 offset;
	private GameContext game;
	// Use this for initialization
	void Start () {
		offset = new Vector3(0.0f, 20.0f, -20.0f);
		game = GameContext.Game;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (game.GameState == GameContext.GameStates.Play)
		{
			transform.position = player.transform.position + offset;
		}
	}
}
