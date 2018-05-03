using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//player characters
	public GameObject[] currentPlayers;
	//enemy objects
	public GameObject[] currentEnemies;

	private bool isPlayerTurn;

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
			//some easy player movement
			if(Input.anyKeyDown) {
				if(Input.GetKeyDown(KeyCode.UpArrow)) { 
					GameObject.FindGameObjectWithTag("Player").GetComponent<clsUnitBase>().checkMove(Vector3.forward);
				} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
					GameObject.FindGameObjectWithTag("Player").GetComponent<clsUnitBase>().checkMove(Vector3.back);
				} else if(Input.GetKeyDown(KeyCode.RightArrow)) {
					GameObject.FindGameObjectWithTag("Player").GetComponent<clsUnitBase>().checkMove(Vector3.right);
				} else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
					GameObject.FindGameObjectWithTag("Player").GetComponent<clsUnitBase>().checkMove(Vector3.left);
				}
				isPlayerTurn = false;
			}
		} else{
			//Computer's turn, AI implementations todo
			for (int i = 0; i < currentEnemies.Length; ++i){
				//currentEnemies[i].transform.Translate(Vector3.left);
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
