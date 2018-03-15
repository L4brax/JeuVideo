using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace lepoupon {
	public class Finish : MonoBehaviour {

		private bool fightStarted;

		public Transform player;

		public Canvas cadreText;

		public Text endText;

		private List<string> text;

		private int inc;

		private bool dead;

		private GameObject myCam;

		private GameObject myPlayer;

		private Tracking trackingScript;

		private MovePlayer move;

		private GameObject gameManager;
		
		private GameManagerMain stats;

		private GameObject ambienceSound;

		private AudioSourceLoop myAudio;

		// Use this for initialization
		void Start () {
			fightStarted = false;
			dead = false;
			text = new List<string>();

			myCam = GameObject.FindWithTag("MainCamera");
			trackingScript = (Tracking) myCam.GetComponent(typeof(Tracking));
	
			myPlayer = GameObject.FindWithTag("Player");
			move = (MovePlayer) myPlayer.GetComponent(typeof(MovePlayer));

			gameManager = GameObject.FindWithTag("GameManager");
			stats = (GameManagerMain) gameManager.GetComponent(typeof(GameManagerMain));

			ambienceSound = GameObject.FindWithTag("Sound");
			myAudio = (AudioSourceLoop) ambienceSound.GetComponent(typeof(AudioSourceLoop));
		}
		
		// Update is called once per frame
		void Update () {
			if(fightStarted==false && isFinalMap()) {
				fightStarted = true;
				inc = 0;
				fight();
			}
			if(isFinalMap() && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))) {
				inc += 1;
				if(text[inc] == "Restarting") { 
					SceneManager.LoadScene("MapLPJ");
				}
				endText.text = text[inc];
			}
			if(Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}

		bool isFinalMap() {
			int x = trackingScript.matriceEnCoursX;
			int y = trackingScript.matriceEnCoursY;
			if(x==1 && y==1) {
				return true;
			}else {
				return false;
			}
		}

		void fight() {

			//Stop character
			move.canMove = false;

			myAudio.setIsBossFight(true);

			//Teleport character to the center of the map
			GameObject map = trackingScript.mapEnCour();
			float x = map.transform.position.x;
			float y = map.transform.position.y;
			player.position = new Vector3(x, y, 0);

			//Display text
			text.Add("Un dragon vous attaque ! Vous ne pouvez pas vous enfuir, vous allez devoir vous battre !");

			text.Add("Le dragon prépare son souffle ardent.");
			if(stats.fireDefense > 0) {
				text.Add("Vous vous protégez grâce à votre bouclier de feu.");
			} else if(stats.frostDefense > 0) {
				text.Add("Vous n'avez pas réussi à vous défendre. Votre bouclier de glace fond à cause du souffle du dragon. Vous brûlez et mourrez dans d'atroces souffrances.");
				dead = true;
			} else {
				text.Add("Vous n'avez pas de bouclier pour vous proteger du souffle du dragon ! Vous brulez et mourrez dans d'atroces souffrances.");
				dead = true;
			}

			if(!dead) {
				text.Add("C'est à votre tour d'attaquer !");
			}

			if(!dead && stats.frostAttack > 0) {
				text.Add("Votre coup d'épée glacée pourfend le dragon !");
			} else if(!dead && stats.fireAttack > 0) {
				text.Add("Votre épée enflammée est inefficace contre le dragon ! Il vous dévore ...");
				dead = true;
			} else if(!dead) {
				text.Add("Vous n'avez pas d'épée pour combattre le dragon. Il vous dévore ...");
				dead = true;
			}

			if(!dead) {
				text.Add("Vous avez gagné ce combat, bien joué !");
			} else {
				text.Add("Vous avez perdu pour cette fois... Réessayez !");
			}

			text.Add("Appuyez sur 'entrer' pour recommencer ou 'échap' pour quitter.");
			text.Add("Redémarrage ...");

			endText.text = text[inc];
			cadreText.sortingOrder = 3;

		}
	}
}