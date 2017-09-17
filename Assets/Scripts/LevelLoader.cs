﻿using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// AdsController.instance.ShowInterstitialAds ();
		GameManager.instance.LoadLevel ();
		#if ADMOB
		AdsController.instance.ShowBanner ();
		#endif
	}

	void Update() {
		GameManager.instance.UpdateLevel ();
	}

}
