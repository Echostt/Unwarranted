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
	public void collideListHandlerUnit(clsUnitBase interactor, Collider col, int collideAt){
        clsUnitBase target = col.gameObject.GetComponent<clsUnitBase>();
        if (target != null) {
            RaycastHit[] hitInfo = Physics.RaycastAll(col.gameObject.transform.position + Vector3.up, Vector3.down, 1.0f);
            Debug.DrawRay(col.gameObject.transform.position, Vector3.down, Color.green, 100.0f);
            //get adjustments from tile improvements
            if (collideAt == 0) {
                target.reduceHP(interactor.atk - target.def);
            } else {
                int reduceAttackFromImprovement = hitInfo[collideAt - 1].collider.gameObject.GetComponent<clsTileImprovement>().defChange;
                target.reduceHP(interactor.atk - target.def - reduceAttackFromImprovement);
            }
        }
	}
}
