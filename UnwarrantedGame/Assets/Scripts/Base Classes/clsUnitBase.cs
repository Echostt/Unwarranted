﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsUnitBase : MonoBehaviour {
	//basic stats
		//level. Maybe used for wave insertion point, cosmetic atm
	public int lvl;
		//max health points
	public int maxHP;
		//current health points
	public int currentHP;
		//attack (atk - def = damage done)
	public int atk;
		// defence
	public int def;

	//Number used for identification within gamemanager
	public int ID;

	private GameObject gm;

	void Start(){
		gm = GameObject.Find("GameManager");
	}

	///Reduces hp by passed amount
	public void reduceHP(int value){
		this.currentHP -= value;
		//update hp bar to reflect current hp
		//scaleHPBar();
		//when hp is depleted, object gets destroyed
		if (this.currentHP <= 0){
			//remove from GameManager, each object needs to be checked. Maybe extrapolate
			if (this.gameObject.tag =="Enemy")
				gm.GetComponent<GameManager>().currentEnemies.Remove(this.gameObject);
			else if (this.gameObject.tag == "Player")
				gm.GetComponent<GameManager>().currentPlayers.Remove(this.gameObject);
			GameObject.Destroy(this.gameObject);
		}
	}
}
