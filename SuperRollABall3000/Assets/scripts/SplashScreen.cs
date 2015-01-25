﻿using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject splashScreen;
	public GameObject levelDesign;

	public void removeSplashScreen()
	{
		splashScreen.SetActive(false);
		levelDesign.SetActive(true);
	}
}
