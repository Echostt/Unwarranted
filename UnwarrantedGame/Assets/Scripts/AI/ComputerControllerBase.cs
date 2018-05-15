using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ComputerControllerBase : MonoBehaviour {

	public void computerTurnHandler(){
        
	}

	///Returns the x or y direction required for target 1 to reach target 2 in the shortest distance.
	public Vector3 moveTowardSimple(GameObject target1, GameObject target2){
		//get positions of object moving (target1), and destination target (target2)
		Vector3Int currentTile1 = new Vector3Int((int)target1.transform.position.x, (int)target1.transform.position.z, 0);
		Vector3Int currentTile2 = new Vector3Int((int)target2.transform.position.x, (int)target2.transform.position.z, 0);
		int xDiff = currentTile1.x - currentTile2.x;
		int yDiff = currentTile1.y - currentTile2.y;
		if (Mathf.Abs(xDiff) > Mathf.Abs(yDiff)){ //further off in x
			if(xDiff > 0)
				return Vector3.left;
			else
				return Vector3.right;
		} else if (Mathf.Abs(xDiff) < Mathf.Abs(yDiff)) { //further off in y
			if(yDiff > 0)
				return Vector3.back;
			else
				return Vector3.forward;
		} else { //even values
			if(yDiff > 0)
				return Vector3.back;
			else if (yDiff < 0)
				return Vector3.forward;
			else if (xDiff > 0)
				return Vector3.left;
			else if (xDiff < 0)
				return Vector3.right;
		}
		return Vector3.zero;
	}
}
