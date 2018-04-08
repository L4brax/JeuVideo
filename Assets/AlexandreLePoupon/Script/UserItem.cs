using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

	private bool picked = false;
	private float seconds = 2;

	void Start()
	{
		// Initialize DOTween (needs to be done only once).
		// If you don't initialize DOTween yourself,
		// it will be automatically initialized with default values.
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		
	}
	private void OnTriggerEnter2D (Collider2D other) {
		if(other.gameObject.name == "Player" && !picked) {
			picked = true;
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
			// Easing sur l'objet : Set relative est nécéssaire pour prendre en compte la taille de l'écran, setLoop permet de boucler l'animation.
			transform.DOMove(new Vector3(0, 0.6f, 0), 0.3f).SetRelative().SetLoops(-1, LoopType.Yoyo);
			
			//Avoir des bruitages : utilisation d'un audio clip lors de la récupération d'un item
			AudioSource.PlayClipAtPoint(clip, transform.position);
			seconds = 1.6f;
		}
	}

	void Update(){
		// Ce morceau de code indique à l'Udate d'attendre 3 seconde avant de détruire l'objet rammassé
		if (picked) {
			seconds -= 1 * Time.deltaTime;
			if (seconds <= 0) {
				Destroy(gameObject);
			}
		}
	}
}