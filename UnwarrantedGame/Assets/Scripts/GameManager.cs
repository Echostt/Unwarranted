using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//main player character, to be handled seperately between scenes
	public GameObject player;
	//base object for ground item
	public GameObject cubePrefab;
	public int gridWidth = 5;
	public int gridHeight = 10;

	//materials avialable to tiles
	public Material[] materialsList;

	//handle interactions between units
		//unit1 attacks unit2
			//check for damage taken, death sequence

	//handle game flow, turns, conditions (game state)

	void Start(){
		//find gameobjects
		materialsList = GameObject.FindGameObjectWithTag("MaterialList").GetComponent<MeshRenderer>().materials;
		//place some cubes 
		for (int i = 0; i < gridWidth; ++i){
			for (int j = 0; j < gridHeight; ++j){
				GameObject tile = Object.Instantiate(cubePrefab, new Vector3(
					i * cubePrefab.transform.localScale.x, 0,
					j * cubePrefab.transform.localScale.z), Quaternion.identity);
				tile.GetComponent<MeshRenderer>().material = materialsList[Mathf.Abs(i-j) % materialsList.Length];
			}
		}
	}
}
