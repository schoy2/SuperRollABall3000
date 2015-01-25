using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
{

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	public GameObject gamePlay;
	public GameObject levelDesign;
	public GameObject player;
	public GameObject btnContinue;
	public GameObject pickups;
	public AudioClip setupTheme;
	public AudioClip playTheme;
	public AudioSource cameraAudioSource;

	void Start()
	{
		count = 0;
		SetCountText ();
	}
	void FixedUpdate () {
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
		if (count >= 12) {
			winText.text="YOU WIN!";
			btnContinue.SetActive(true);
		}
		//Destroy(other.gameObject);
	}
	void SetCountText()
	{
		countText.text = "count: "+count.ToString();
	}
	
	public void EnableLevelDesignMode () 
	{
		playSetupTheme();

		//Set Ball Position and velocity
		transform.position = new Vector3(0.0f, 0.5f, 0.0f);
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		winText.text = "";
		countText.text = "";

		//Set pickups to active
		foreach(Transform pickup in pickups.transform)
		{
			pickup.gameObject.SetActive(true);
		}


		gamePlay.SetActive(false);
		levelDesign.SetActive(true);
		player.SetActive(false);
		btnContinue.SetActive(true);
	}
		
	public void EnableGamePlayMode () 
	{
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
}
