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
	public int currentMoveCount;
    public int maxMoveCount;

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
		scaleHPBar();
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

    /// <summary>
    /// Resets current move count to max value.
    /// </summary>
    public void resetMovePoints () {
        this.currentMoveCount = this.maxMoveCount;
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
		RaycastHit[] hitInfo = Physics.RaycastAll(this.gameObject.transform.position, checkDirection, 1.0f);
        //if an object is detected, handle the intervening object, otherwise check move cost
        int collideAt = -1; //used to see if moving to occupied tile
        for (int i = 0; i < hitInfo.Length; ++i)
            if (hitInfo[i].collider.gameObject.CompareTag("Enemy") || hitInfo[i].collider.gameObject.CompareTag("Player")) {
                collideAt = i;
            }
		if (collideAt != -1){
            gm.GetComponent<ColliderMaster>().collideListHandlerUnit(this, hitInfo[collideAt].collider, collideAt);
		} else {
            RaycastHit[] hitInfoGround = Physics.RaycastAll(this.gameObject.transform.position + checkDirection, Vector3.down, 1.0f);
            int nextMoveCost = gm.GetComponent<ColliderMaster>().collideListHandlerTerrain(hitInfoGround[0].collider);
            if (nextMoveCost <= currentMoveCount) {
                this.currentMoveCount -= nextMoveCost;
                this.gameObject.transform.Translate(checkDirection);
            }

            //TEMP FOR PLAYER TURN STOP 0-----------------------------------------------------------------------------0
            if (this.gameObject.CompareTag("Player") && currentMoveCount == 0)
                gm.GetComponent<GameManager>().setPlayerTurnFalse();
		}
	}

    public void checkTileImprovement () {
        RaycastHit[] hitInfoGround = Physics.RaycastAll(this.gameObject.transform.position + Vector3.up, Vector3.down, 1.0f);
        //only two objects are ever on the same tile. If you're idle on the tile this applies the affect.
        if (hitInfoGround.Length > 1)
            hitInfoGround[0].collider.gameObject.GetComponent<clsTileImprovement>().idleAction(this);
    }

}
