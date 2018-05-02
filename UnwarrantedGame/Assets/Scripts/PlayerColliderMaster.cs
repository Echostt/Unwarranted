using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderMaster : MonoBehaviour {
	void OnTriggerEnter(Collider col){
		Debug.Log("Collided with: " + col.gameObject);
	}
}
