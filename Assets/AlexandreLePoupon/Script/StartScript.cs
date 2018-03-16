using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartScript : MonoBehaviour {


	public Canvas cadreText;

	public Text startText;

	public AudioSource dragonRoar;
	
 	public AudioSource backgroundSound;

	public bool soundIsPlaying;

	public bool showText;

	// Use this for initialization
	void Start () {
		
		soundIsPlaying = false;

		showText = false;

        backgroundSound.Stop();

        dragonRoar.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dragonRoar.isPlaying && soundIsPlaying == false) {
			soundIsPlaying = true;
			showText = true;
			backgroundSound.Play();
		}

		if (showText == true) {
			showText = false;
			cadreText.sortingOrder = 8;
		}

		if (!dragonRoar.isPlaying && showText == false && (Input.GetButtonDown("Entrer"))) {
			cadreText.sortingOrder = -1;
		}
	}
}
