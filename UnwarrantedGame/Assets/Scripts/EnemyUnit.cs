using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {
	
	// Sprite attached to Enemy, can be changed as needed
	public Sprite sprite;
	// current facing direction, maybe needed for LoS
	// 0 - up, 1 - right, 2 - down, 3 - left
	public int dirFacing;

	//basic stats
		//enemy level. Maybe used for wave insertion point
	public int lvl;
		//enemy health points
	public int hp;
		//enemy attack (atk - def = damage done)
	public int atk;
		//enemy defence
	public int def;
		//enemy movement points
	public int moveCount;

}
