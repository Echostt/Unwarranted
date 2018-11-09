using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//player characters
	public List<GameObject> currentPlayers;
	//enemy objects
	public List<GameObject> currentEnemies;
    public Text fpsText;
    public Text scoreText;

    private int score = 0;

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
        fpsText = GameObject.Find("FPS").GetComponent<Text>();
	}

    void Update() {
        fpsText.text = "FPS: " + 1.0f / Time.smoothDeltaTime;
    }

    public void AddToScore(int value) {
        score += value;
        scoreText.text = "# " + score;
    }

}
