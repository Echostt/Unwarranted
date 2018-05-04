using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private GameObject player;
	public float speed;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		if (player != null)
			this.gameObject.transform.position = Vector3.Lerp( 
				this.gameObject.transform.position, 
				new Vector3(player.transform.position.x, 10, player.transform.position.z),
				Time.deltaTime * speed);
	}

}
