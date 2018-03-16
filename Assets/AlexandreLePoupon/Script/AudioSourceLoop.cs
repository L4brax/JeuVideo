using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceLoop : MonoBehaviour {

 	public AudioSource backgroundSound;
	
	public AudioSource bossSound;

	public bool isBossFight;

    void Start()
    {
        // backgroundSound.Stop();
		
		isBossFight = false;
		
        // backgroundSound.Play();
    }

    void Update()
    {
		if(isBossFight && !bossSound.isPlaying) {
			backgroundSound.Stop();
			
        	bossSound.Play();

			bossSound.loop = true;

		} else {
			backgroundSound.loop = true;
		}
    }

	public void setIsBossFight(bool boss) {
		isBossFight = boss;
	}

}
