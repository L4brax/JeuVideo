﻿// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// namespace vivion {
// 	public struct MyDestination {
// 		public MyNode node;
// 		public float distance;
// 		public MyDestination (MyNode n, float d) {
// 			node = n;
// 			distance = d;  // distance parcourue entre le noeud courant et le depart(g)
// 		}
// 	}

// 	public class MyNode {
// 		public float[] position;
// 		public MyNode parent;
// 		public float cout;
// 		public float heuristique;
// 		public MyDestination[] destinations;
// 		public int num;

// 		public MyNode (int tnum, float[] n, float h) {
// 			position = n;		// position du noeud [x, y]
// 			cout = 0;			// total entre g et h
// 			heuristique = h; 	// distance entre le noeud courant et la fin (h) (vole d'oiseau)
// 			destinations = null;
// 			parent = null;
// 			num = tnum;			// profondeur dans le jeux
// 		}
// 		public MyNode(int tnum, float[] n, float h , float f){
// 			parent = null;
// 			position = n;		// position du noeud [x, y]
// 			cout = f;			// total entre g et h
// 			heuristique = h; 	// distance entre le noeud et la fin (h)
// 			destinations = null;
// 			num = tnum;
// 		}
// 		public MyNode(int tnum, float[] n, float h , float f, MyNode myNodeParent){
// 			parent = myNodeParent;
// 			position = n;		// position du noeud [x, y]
// 			cout = f;			// total entre g et h
// 			heuristique = h; 	// distance entre le noeud et la fin (h)
// 			destinations = null;
// 			num = tnum;
// 		}
// 	}

// 	public class pathfinding : MonoBehaviour {

// 		public Transform personnage;

// 		private float unPas = 1;

// 		private MyNode nodeDuMob;

// 		private int numEnCours = 0;
		
// 		private GameObject myCam;

// 		private Tracking myScript;


// 		void Start () {
// 			myCam = GameObject.FindWithTag("MainCamera");
// 			myScript = (Tracking) myCam.GetComponent(typeof(Tracking));
// 			float x = this.transform.position.x;
// 			float y = this.transform.position.y;
// 			// a l'init ont définit au mob le chemin a prendre // nodeDuMob = exploreWithPathFinding(new List<MyNode>(), new List<MyNode>());
// 			nodeDuMob = exploreWithPathFinding2();
// 		}
		
// 		int nbFrame = 10;

// 		void Update () {
// 			if(nodeDuMob != null){
// 				float[] direction = directionAPrendreDuMob();				
// 				mouve(direction[0], direction[1]);
// 			}
// 			// if(nbFrame == 0){
// 			// 	nbFrame = 10;
// 			// 	nodeDuMob = exploreWithPathFinding(new List<MyNode>(), new List<MyNode>());
// 			// }
// 			// nbFrame++;
// 		}

// 		// grace a la node genrerer depuis la fonction exploreWithPathFinding()
// 		// nous pouvons recuperer le dernier parent, cela représente le premier deplacement du mob5
// 		public float[] directionAPrendreDuMob(){
// 			bool stop = true;
			
// 			MyNode node = nodeDuMob;
			
// 			float[] direction = new float[2];
// 			direction[0] = 0;
// 			direction[1] = 0;
// 			while(stop){
// 				if(node.parent == null) return direction;
// 				if(node.parent.num == numEnCours){
// 					if(leMobTaTape(node, personnage.transform.position.x, personnage.transform.position.y)){
// 						//Debug.Log(node.position[0] +" "+ node.position[1]);
// 						return direction;
// 					}
// 					if(node.position[0] > this.transform.position.x) direction[0] = diffPOs(node.position[0], this.transform.position.x);
// 					if(node.position[0] < this.transform.position.x) direction[0] = -diffPOs(node.position[0], this.transform.position.x);
// 					if(node.position[1] > this.transform.position.y) direction[1] = diffPOs(node.position[1], this.transform.position.y);
// 					if(node.position[1] < this.transform.position.y) direction[1] = -diffPOs(node.position[1], this.transform.position.y);
// 					//Debug.Log("bef"+node.position[0]+ " " + node.position[1] + " || " +this.transform.position.x +" "+this.transform.position.y);
// 					// tant que notre mob n'est pas arriver a ca position ont continue a le faire avancer
// 					//if(bienArriver(node.position[0], node.position[1])){
// 						numEnCours = node.num;
// 					//}
// 					// sortie de la boucle
// 					stop = false;
// 				}else{
// 					node = node.parent;
// 				}
				
// 			}		
// 			// renvoyer 1 ou -1 pour x et y
// 			return direction;
// 		}
// 		public float diffPOs(float f1, float f2){
// 			return Mathf.Max(f1,f2) - Mathf.Min(f1,f2);
// 		}

// 		public bool bienArriver(float x, float y){
// 			if(x.Equals(this.transform.position.x) && y.Equals(this.transform.position.y)) return true;
			
// 			//if(x.Equals(Mathf.Round(this.transform.position.x*100f)/100f) && y.Equals(Mathf.Round(this.transform.position.y*100f)/100f)) return true;
// 			return false;
// 		}

// 		public MyNode exploreWithPathFinding2(){

// 			// Ajout de mon premier noeud (représente le mob)
// 			float[] pathPos = new float[2];
// 			pathPos[0] = this.transform.position.x;
// 			pathPos[1] = this.transform.position.y;
			
// 			bool fin = true;
// 			int loopStop = 0;
// 			while(fin || loopStop < 1000){
				
// 				MyNode myNode = new MyNode(0, pathPos, calculHeuristique(this.transform.position.x, this.transform.position.y, personnage.position.x, personnage.position.y), 0);


// 			}

// 			return null;
// 		}

// 		public MyNode exploreWithPathFinding(List<MyNode> mesNodesListOuverte, List<MyNode> mesNodesListFerme){
// 			// Ajout de mon premier noeud (représente le mob)
// 			float[] pathPos = new float[2];
// 			pathPos[0] = this.transform.position.x;
// 			pathPos[1] = this.transform.position.y;
			
// 			MyNode pathMyNode = new MyNode(0, pathPos, calculHeuristique(this.transform.position.x, this.transform.position.y, personnage.position.x, personnage.position.y));
// 			mesNodesListFerme.Add(pathMyNode);
// 			bool tape = true;
// 			while(tape){

// 				List<MyNode> pathMesNodes;
// 				MyNode pathMaNodesAvecDirections;
// 				MyNode pathMyNextNode;
// 				// Ajout des nodes suivantes + les directions vers les nodes
// 				pathMesNodes = addNodeSuivante(pathMyNode);
// 				// ajout dans la liste ouverte
// 				foreach (var item in pathMesNodes){
// 					mesNodesListOuverte.Add(item);
// 				}
				
// 				pathMaNodesAvecDirections = addDirectionToMyNode(pathMyNode, pathMesNodes);
				
// 				// ajouter la node parente au enfant 			
// 				pathMaNodesAvecDirections = addParent(pathMaNodesAvecDirections, pathMesNodes);
				
// 				// choix de la node suivante (celle qui a le cout le plus faible)
// 				pathMyNextNode = choixNodeSuivante(/*pathMaNodesAvecDirections,*/ mesNodesListFerme,mesNodesListOuverte);

// 				// si pas de solution
// 				if(pathMyNextNode == null) return pathMyNode;

// 				// une fois une node calculer ont l'ajoute a la liste déjà parcourue et ont la vire de la liste ouverte
// 				mesNodesListFerme.Add(pathMyNextNode);
// 				mesNodesListOuverte.Remove(pathMyNextNode);

// 				// passage a la variable pour continuer la boucle
// 				pathMyNode = pathMyNextNode;

// 				// si arrive au personnage ont garde le chemin
// 				if(leMobTaTape(pathMyNextNode, personnage.position.x, personnage.position.y)){
// 					// jackpot on retourne ont sort de la boucle
// 					tape = false;
// 				}
				
// 			}
// 			return pathMyNode;
// 		}
	
// 		// ont verifie si nous somme arrivé a la position du personnage 
// 		// ont vérifie sur la position personne + unPas (le deplacement ce fait unPas par unPas, ont peut donc ne pas tomber pile poile sur la position du personnage)
// 		// return true si ont y est
// 		public bool leMobTaTape(MyNode myNode, float persoX, float persoY){
// 			float xnode = myNode.position[0];
// 			float ynode = myNode.position[1];
// 			float xpers = persoX;
// 			float ypers = persoY;
// 			if(xnode < 0) xnode =xnode*-1;
// 			if(ynode < 0) ynode =ynode*-1;
// 			if(xpers < 0) xpers =xpers*-1;
// 			if(ypers < 0) ypers =ypers*-1;

// 			if(Mathf.Abs(xnode-xpers) < unPas && Mathf.Abs(ynode-ypers) < unPas){	
// 				return true;
// 			}
// 			return false;
// 		}

// 		public MyNode choixNodeSuivante(/*MyNode maNode,*/ List<MyNode> mesNodesListFerme,List<MyNode> mesNodesListOuverte){
// 			// todo
// 			MyNode node = null;
// 			float maxCout = 99999999999;
		
// 			// for (int i = 0; i < maNode.destinations.Length; i++)
// 			// {
// 			// 	if(maNode.destinations[i].node.cout < maxCout){
// 			// 		// si deja dans la liste ferme ont y repasse pas
// 			// 		if(detectListFerme(maNode.destinations[i].node, mesNodesListFerme)){
// 			// 			maxCout = maNode.destinations[i].node.cout;
// 			// 			node = maNode.destinations[i].node;
// 			// 		}
// 			// 	}
// 			// }
// 			for (int i = 0; i < mesNodesListOuverte.Count; i++){
// 				if(mesNodesListOuverte[i].cout < maxCout){
// 					// si deja dans la liste ferme ont y repasse pas
// 					if(detectListFerme(mesNodesListOuverte[i], mesNodesListFerme)){
// 						maxCout = mesNodesListOuverte[i].cout;
// 						node = mesNodesListOuverte[i];
// 					}
// 				}
// 			}
// 			return node;
// 		}

// 		// Prend en params la position courante et la position a atteindre
// 		// Calcul de type vole d'oiseau
// 		public float calculHeuristique(float posx, float posy, float persoX, float persoY){
// 			float tempoPersoX =persoX;
// 			float tempoPersoY =persoY;
// 			float tempoPosX =posx;
// 			float tempoPosY =posy;
// 			float retourx = 0;
// 			float retoury = 0;

// 			if(persoX < 0) tempoPersoX = persoX*-1;
// 			if(persoY < 0) tempoPersoY = persoY*-1;
// 			if(posx < 0) tempoPosX = posx*-1;
// 			if(posy < 0) tempoPosY = posy*-1;

// 			retourx = Mathf.Max(tempoPosX,tempoPersoX) -  Mathf.Min(tempoPosX,tempoPersoX);
// 			if(retourx < 0) retourx = retourx*-1;

// 			retoury = Mathf.Max(tempoPosY,tempoPersoY) -  Mathf.Min(tempoPosY,tempoPersoY);
// 			if(retoury < 0) retoury = retoury*-1;

// 			return retourx+retoury;
// 		}
		
// 		// Ajout des nodes suivante a la node passer en param
// 		public List<MyNode> addNodeSuivante(MyNode myNode){
// 			List<MyNode> mesNodes = new List<MyNode>();
// 			//prepa des futurs positions
// 			List<float[]> mesPositionsfuturNodes = preparePositionNextNode(myNode.position);
// 			// pour toutes les positions des futurs nodes
// 			mesPositionsfuturNodes.ForEach(items =>{
// 				// if de la collision == true pas de colision sinon ont ne créer pas de node // 
// 				if(detectColision(items)){
// 					MyNode myNodeNext = new MyNode(myNode.num+1, items, calculHeuristique(items[0], items[1], personnage.position.x, personnage.position.y));
// 					mesNodes.Add(myNodeNext);
// 				}
// 			});
			
// 			return mesNodes;
// 		}
		
// 		// renvoi true si non compris dans la liste ferme
// 		public bool detectListFerme(MyNode node , List<MyNode> mesNodesListFerme){
// 			for (int i = 0; i < mesNodesListFerme.Count; i++){ 
// 				if(node.position[0] == mesNodesListFerme[i].position[0] && node.position[1] == mesNodesListFerme[i].position[1]) return false;
// 			}
// 			return true;	
// 		}

// 		// Prend en parametre les positions d'une node 
// 		// Renvoi la liste des positions des nodes autour
// 		public List<float[]> preparePositionNextNode(float[] position){
// 			var list = new List<float[]>();
// 			// celle du dessus
// 			float[] dessus = new float[2];
// 			dessus[0] = position[0];
// 			dessus[1] = position[1]+unPas;
// 			// celle du dessous
// 			float[] dessous = new float[2];
// 			dessous[0] = position[0];
// 			dessous[1] = position[1]-unPas;
// 			// celle du gauche
// 			float[] gauche = new float[2];
// 			gauche[0] = position[0]-unPas;
// 			gauche[1] = position[1];
// 			// celle du droite
// 			float[] droite = new float[2];
// 			droite[0] = position[0]+unPas;
// 			droite[1] = position[1];

// 			list.Add(dessus);
// 			list.Add(dessous);
// 			list.Add(droite);
// 			list.Add(gauche);
// 			return list;
// 		}

// 		// Calcul la distance entre le noeud courant et le point de depart
// 		// Prend en param la node parent + la node en cours d'ajout
// 		// Retourne la distance
// 		public float calculDistance(MyNode myNode, MyNode NodeEnCours){
// 			int distanceUneCase = 1;
// 			// Si pas de parent alors ont est au debut, ont init la distance a 1
// 			if(myNode.parent == null) return distanceUneCase;

// 			float dest = 0;
			
// 			for(int i = 0; i < myNode.parent.destinations.Length; i++){
// 				if(myNode.parent.destinations[i].Equals(NodeEnCours)){
// 					dest = myNode.parent.destinations[i].distance;
// 				}
// 			}
// 			// toujours 1 de distance vu qu'on le fait toutes les 1x ou 1y ? 
// 			return dest + distanceUneCase;
// 		}

// 		// params : une node et les nodes qui lui doivent être liée
// 		// ajoute les directions entres les nodes
// 		public MyNode addDirectionToMyNode(MyNode myNode, List<MyNode> mesNodes){
// 			MyNode MyNodeReturn = new MyNode(myNode.num, myNode.position, myNode.heuristique, myNode.cout, myNode.parent);
// 			MyDestination[] listdestinations = new MyDestination[mesNodes.Count];

// 			// pour chaque node ont ajoute une destinations pour l'atteindre avec le calcul de la distance
// 			for(int i = 0; i < mesNodes.Count; i++){
// 				float dist = calculDistance(myNode, mesNodes[i]);
// 				// mise a jour du cout
// 				mesNodes[i].cout = mesNodes[i].heuristique + dist;
// 				listdestinations[i] = new MyDestination(mesNodes[i], dist);
// 			}
			
// 			MyNodeReturn.destinations = listdestinations;
// 			return MyNodeReturn;
// 		}

// 		public MyNode addParent(MyNode myNode, List<MyNode> mesNodes){
// 			for(int i = 0; i < myNode.destinations.Length; i++){
// 				foreach (MyNode node in mesNodes)
// 				{
// 					if(myNode.destinations[i].node.Equals(node)){
// 						node.parent = myNode;
// 						myNode.destinations[i].node = node;
// 					}
// 				}
// 			}
// 			return myNode;
// 		}
		

// 		public List<float[]> preparePositionForDetect(float[] position){
// 			var list = new List<float[]>();
// 			// celle du dessus
// 			float[] dessus = new float[2];
// 			dessus[0] = position[0];
// 			dessus[1] = position[1]+unPas;
// 			// celle du dessus droite
// 			float[] dessusDroite = new float[2];
// 			dessusDroite[0] = position[0]+unPas;
// 			dessusDroite[1] = position[1]+unPas;
// 			// celle du dessus gauche
// 			float[] dessusGauche = new float[2];
// 			dessusGauche[0] = position[0]-unPas;
// 			dessusGauche[1] = position[1]+unPas;
// 			// celle du dessous
// 			float[] dessous = new float[2];
// 			dessous[0] = position[0];
// 			dessous[1] = position[1]-unPas;
// 			// celle du dessous droite
// 			float[] dessousDroite = new float[2];
// 			dessousDroite[0] = position[0]+unPas;
// 			dessousDroite[1] = position[1]-unPas;
// 			// celle du dessous gauche
// 			float[] dessousGauche = new float[2];
// 			dessousGauche[0] = position[0]-unPas;
// 			dessousGauche[1] = position[1]-unPas;
// 			// celle du gauche
// 			float[] gauche = new float[2];
// 			gauche[0] = position[0]-unPas;
// 			gauche[1] = position[1];
// 			// celle du droite
// 			float[] droite = new float[2];
// 			droite[0] = position[0]+unPas;
// 			droite[1] = position[1];

// 			list.Add(dessus);
// 			list.Add(dessusDroite);
// 			list.Add(dessusGauche);
// 			list.Add(dessous);
// 			list.Add(dessousDroite);
// 			list.Add(dessousGauche);
// 			list.Add(droite);
// 			list.Add(gauche);
// 			return list;
// 		}

// 		// Check si la position passé  en param est en colision avec le decor
// 		// Params : float[x, y] position du mob
// 		// Return true si pas de colision
// 		public bool detectColision(float[] futurPosition){
// 			GameObject map = myScript.mapEnCour();
// 			Tilemap tilemap = null;
// 			TileBase maTile = null;
// 			int x = 0;
// 			int y = 0;
// 			for (int i = 0; i < map.transform.childCount; i++){
// 				if(map.transform.GetChild(i).name == "Tilemap_col"){
// 					tilemap = map.transform.GetChild(i).GetComponent<Tilemap>();
// 				}
// 			}
		
// 			x = 0;
// 			if(futurPosition[0] < 0){
// 				x = Mathf.CeilToInt(futurPosition[0]);
// 			}else{
// 				x = Mathf.FloorToInt(futurPosition[0]);
// 			}
// 			y = 0;
// 			if(futurPosition[1] < 0){
// 				y = Mathf.CeilToInt(futurPosition[1]);
// 			}else{
// 				y = Mathf.FloorToInt(futurPosition[1]);
// 			}
// 			maTile = tilemap.GetTile(new Vector3Int(x, y, 0));
// 			if(!(maTile == null)) return false;

// 			List<float[]> posF= preparePositionForDetect(futurPosition);
// 			for (int i = 0; i < posF.Count; i++){
// 				x = 0;
// 				if(posF[i][0] < 0){
// 					x = Mathf.CeilToInt(posF[i][0]);
// 				}else{
// 					x = Mathf.FloorToInt(posF[i][0]);
// 				}
// 				y = 0;
// 				if(posF[i][1] < 0){
// 					y = Mathf.CeilToInt(posF[i][1]);
// 				}else{
// 					y = Mathf.FloorToInt(posF[i][1]);
// 				}
// 				maTile = tilemap.GetTile(new Vector3Int(x, y, 0));
// 				if(!(maTile == null)) return false;
// 			}
// 			if(maTile==null) return true;
// 			return false;
// 		}

// 		// Debut deplacement du mob // 
// 		public float acceleration = 1f; // unit per second, per second
// 		public float maxSpeed = 1f; // unit per second
// 		public Vector3 currentSpeed;
// 		public void mouve(float x, float y){
			
// 			this.transform.position += new Vector3(x,y,0);

// 			// de -1 a 1 le retour de inputgetaxis
// 			// Vector3 currentAcceleration = new Vector3 (
// 			// 	x * acceleration,
// 			// 	y * acceleration,
// 			// 	0
// 			// );
// 			// currentSpeed += currentAcceleration * Time.deltaTime;
// 			// currentSpeed = Vector3.ClampMagnitude(currentSpeed, maxSpeed);
// 			// if (currentAcceleration.magnitude == 0) currentSpeed *= 0.8f;
// 			// this.transform.position += currentSpeed * Time.deltaTime;
// 		}
// 		// Fin deplacement du mob //
// 	}

// }