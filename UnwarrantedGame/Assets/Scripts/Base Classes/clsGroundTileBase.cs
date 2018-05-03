using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsGroundTileBase : MonoBehaviour {
	public int moveCost; //number of moves deducted per travelled block
	public int defenseModifier; //amount defense is altered by tile
	public bool hasImprovement; //is there a current tile improvement on this block
}
