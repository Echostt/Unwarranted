using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//main player character, to be handled seperately between scenes
	public GameObject[] currentPlayers;
	//generic enemy object
	public GameObject[] currentEnemies;

	private bool isPlayerTurn;

	//handle interactions between units
		//unit1 attacks unit2
			//check for damage taken, death sequence

	//handle game flow, turns, conditions (game state)

	void Start(){
		//find gameobjects
		currentPlayers = GameObject.FindGameObjectsWithTag("Player");
		currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

		startingGameCommands();
	}

	void startingGameCommands(){
		//launch tutorial, controls, info
		isPlayerTurn = true;
		turnHandler();
	}

	void turnHandler(){
		if (isPlayerTurn){
			//some easy fake player movement
			if(Input.GetKeyDown(KeyCode.UpArrow)) { 
				GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector3(0, 1, 0));
				isPlayerTurn = false;
			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector3(0, -1, 0));
				isPlayerTurn = false;
			}
		} else{
			for (int i = 0; i < currentEnemies.Length; ++i){
				currentEnemies[i].transform.position +=  Vector3.left;
			}
			isPlayerTurn = true;
		}
	}

	//simple turn ending function
	public void setPlayerTurnFalse(){
		isPlayerTurn = false;
	}
	//allows the player to gain control
	public void setPlayerTurnTrue(){
		isPlayerTurn = true;
	}

	void Update(){
		turnHandler();
	}

}
