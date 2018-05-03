using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsUnitBase : MonoBehaviour {

	// current facing direction, maybe needed for LoS
	// 0 - up, 1 - right, 2 - down, 3 - left
	public int dirFacing;

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
		//movement points
	public int moveCount;

	///Reduces hp by passed amount
	public void reduceHP(int value){
		this.currentHP -= value;
		//update hp bar to reflect current hp
		scaleHPBar();
		//when hp is depleted, object gets destroyed
		if (this.currentHP <= 0){
			Debug.Log("DESTROYED");
			GameObject.Destroy(this.gameObject);
		}
	}

	///Adjust hp bar to be proportially the size of hp current/total
	private void scaleHPBar(){
		Transform hpBarScale = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
		hpBarScale.localScale = new Vector3(
			(float)currentHP / maxHP, hpBarScale.localScale.y, hpBarScale.localScale.z
		);
	}

	///Look at object in direction and handle accordingly
	public void checkMove(Vector3 checkDirection){
		RaycastHit hitInfo;
		if (Physics.Raycast(this.gameObject.transform.position, checkDirection, out hitInfo, 1.0f)){
			//all moves need to be checked from player's side and computer's side
			if (this.gameObject.tag == "Player"){ //Player's Turn
				this.GetComponent<PlayerColliderMaster>().checkCollideList(hitInfo.collider);
			} else { //Computer's Turn
				
			}
		} else {
			this.gameObject.transform.Translate(checkDirection);
		}

	}
}
