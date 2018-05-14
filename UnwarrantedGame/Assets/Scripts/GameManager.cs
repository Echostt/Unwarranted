using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour {
	//player characters
	public List<GameObject> currentPlayers;
	//enemy objects
	public List<GameObject> currentEnemies;

	private bool isPlayerTurn;

	void Start(){
		//find gameobjects
		//load currently active players and enemies
		//have to find objects into an array, and then fill into List to be used for computer controller
		GameObject[] arrCurrPlayer = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < arrCurrPlayer.Length; ++i){
			GameObject cpy = arrCurrPlayer[i];
			cpy.GetComponent<clsUnitBase>().ID = i;
			currentPlayers.Add(cpy);
		}
		GameObject[] arrCurrEnemy = GameObject.FindGameObjectsWithTag("Enemy");
		for (int i = 0; i < arrCurrEnemy.Length; ++i){
			GameObject cpy = arrCurrEnemy[i];
			cpy.GetComponent<clsUnitBase>().ID = i;
			currentEnemies.Add(cpy);
		}

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
			if(Input.anyKeyDown) { //press key, char moves that direction
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
			for (int i = 0; i < currentEnemies.Count; ++i){
				Vector3 directionChoice = this.GetComponent<ComputerControllerBase>().moveTowardSimple(
					currentEnemies[i].gameObject, 
					GameObject.FindGameObjectWithTag("Player"));
				currentEnemies[i].GetComponent<clsUnitBase>().checkMove(directionChoice);
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


	/// <summary>
	/// Converts Player position to TileMap coords and removes the Tile at that location.
    /// Used to change/remove grid overlay at that tile
	/// </summary>
	void changeTileAtPlayerLoc(){
		//select the Grid for tile position
		//Debug.Log(tiles.LocalToCell(GameObject.Find("Player").transform.position));
		Vector3Int currentTile = new Vector3Int((int)this.gameObject.transform.position.x, (int)this.gameObject.transform.position.z, 0);
		UnityEngine.Tilemaps.Tilemap tilemap = GameObject.Find("Grid").GetComponent<Grid>().GetComponentInChildren<Tilemap>();
		tilemap.SetTile(currentTile, null);
	}

}
