using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
{

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	private int numPickups = 12;
	public GameObject gamePlay;
	public GameObject levelDesign;
	public GameObject player;
	public GameObject btnContinue;
	public GameObject pickups;
	public AudioClip setupTheme;
	public AudioClip playTheme;
	public AudioSource cameraAudioSource;
	public GameObject mainCamera;
	public GameContext game = GameContext.Game;
	void Start()
	{
		count = 0;
		SetCountText ();
	}

	void LateStart()
	{		
		SetCameraPositionLevelDesign();
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup") 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText();
		}
		if (count >= numPickups) {
			winText.text="YOU WIN!";
			btnContinue.SetActive(true);
		}
	}

	void SetCountText()
	{
		countText.text = "count: "+count.ToString();
	}
	
	public void EnableLevelDesignMode () 
	{
		game.GameState = GameContext.GameStates.LevelDesign;
		SetCameraPositionLevelDesign();

		playSetupTheme();

		//Set Ball Position and velocity
		transform.position = new Vector3(0.0f, 0.5f, 0.0f);
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		winText.text = "";
		countText.text = "";

		//Set pickups to active
		resetPickups();

		gamePlay.SetActive(false);
		levelDesign.SetActive(true);
		player.SetActive(false);
		btnContinue.SetActive(true);
	}
		
	public void EnableGamePlayMode () 
	{
		game.GameState = GameContext.GameStates.Play;
		resetPickups();

		playPlayTheme();
		//Reset score
		count = 0;
		SetCountText ();

		//Set gui active status
		gamePlay.SetActive(true);
		levelDesign.SetActive(false);

		//Show the player and hide the continue button
		player.SetActive(true);
		btnContinue.SetActive(false);

		SetCameraPositionPlayMode();
	}

	void playSetupTheme()
	{
		cameraAudioSource.clip = setupTheme;
		cameraAudioSource.Play();
	}

	void playPlayTheme()
	{
		cameraAudioSource.clip = playTheme;
		cameraAudioSource.Play();
	}

	private void resetPickups()
	{
		numPickups = 0;
		foreach(Transform pickup in pickups.transform)
		{
			pickup.gameObject.SetActive(true);
			numPickups++;
		}
	}
	private void SetCameraPositionLevelDesign()
	{
		mainCamera.transform.position = new Vector3(0.0f, 20.0f, 0.0f);
		mainCamera.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}
	private void SetCameraPositionPlayMode()
	{
		mainCamera.transform.position = new Vector3(0.0f, 20.0f, -20.0f);
		mainCamera.transform.rotation = Quaternion.Euler(new Vector3(45,0,0));
	}
}
