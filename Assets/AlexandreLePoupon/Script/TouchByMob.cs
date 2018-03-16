using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchByMob : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.name == "Playermob1") {
			Debug.Log("Touché");
		}
		if(other.gameObject.name == "Playermob2") {
			Debug.Log("Touché");
		}
		if(other.gameObject.name == "Playermob3") {
			Debug.Log("Touché");
		}
	}
}
