using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles collisions made by the character when moving
public class ColliderMaster : MonoBehaviour {
	///Passing a collider returns move cost deduction
	public int collideListHandlerTerrain(Collider col){
		return col.gameObject.GetComponent<clsGroundTileBase>().moveCost;
	}

	///interactor collides with unit's collider col, handle interaction
	public void collideListHandlerUnit(clsUnitBase interactor, Collider col){
		clsUnitBase target = col.gameObject.GetComponent<clsUnitBase>();
		Debug.Log("Int: " + interactor.atk + " Col: " + target.def);
		target.reduceHP(interactor.atk - target.def);
	}
}
