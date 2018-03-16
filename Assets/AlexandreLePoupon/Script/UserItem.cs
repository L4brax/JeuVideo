﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserItem : MonoBehaviour {
	public GameObject gameManager;

	// public GameObject player;
	/**
		Element of the object : Can be 'Fire' or 'Forst'
	 */
	public string element;
	/**
		Type of the object : Can be 'Defense' or 'Attack'
	 */
	public string type;

	public AudioClip clip;

	private void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.name == "Player") {
			Debug.Log("Item picked !");
			if (element == "Fire"){
				if (type == "Defense"){
					gameManager.GetComponent<GameManagerMain>().fireDefense += 10;
				} else {
					gameManager.GetComponent<GameManagerMain>().fireAttack += 10;
				}
			} else {
				if (type == "Defense"){
					gameManager.GetComponent<GameManagerMain>().frostDefense += 10;
				} else {
					gameManager.GetComponent<GameManagerMain>().frostAttack += 10;
				}
			}
			AudioSource.PlayClipAtPoint(clip, transform.position);
			Destroy(gameObject);
		}
	}
}