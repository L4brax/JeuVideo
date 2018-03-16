using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	private GameObject myCam;
	private Tracking trackingScript;
	public Transform player;

	// Use this for initialization
	void Start () {

		myCam = GameObject.FindWithTag("MainCamera");
		trackingScript = (Tracking) myCam.GetComponent(typeof(Tracking));
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isWindMap()) {
			Debug.Log("Wind Tile");
		}
	}

	bool isWindMap() {
		int x = trackingScript.matriceEnCoursX;
		int y = trackingScript.matriceEnCoursY;
		if(x==0 && y==0) {
			return true;
		} else {
			return false;
		}
	}
}
