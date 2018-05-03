using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles collisions made by the character when moving
public class PlayerColliderMaster : MonoBehaviour {
	public void checkCollideList(Collider col){
		switch (col.gameObject.tag){
		case "Enemy":
			clsUnitBase hitEnemy = col.gameObject.GetComponent<clsUnitBase>();
			hitEnemy.reduceHP(1);
			break;
		}
	}
}
