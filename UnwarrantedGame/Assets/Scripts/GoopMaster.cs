using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopMaster : MonoBehaviour {

    public float timeToGoop;
    public bool isAvailableToSpawn = true;

    private float lastTimeGoop;

	// Update is called once per frame
	void Update () {
		if (isAvailableToSpawn && Time.time - lastTimeGoop > timeToGoop) {
            isAvailableToSpawn = false;
            lastTimeGoop = Time.time;
            GameObject spawn = (GameObject)Resources.Load("GoopTest");
            spawn.GetComponent<clsUnitBase>().spawner = this.GetComponent<GoopMaster>();
            Instantiate(spawn, this.gameObject.transform.position + Vector3.back, Quaternion.identity);
        }
	}
}
