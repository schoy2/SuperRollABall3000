using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject splashScreen;

	public void removeSplashScreen()
	{
		splashScreen.SetActive(false);
	}
}
