using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopMaster : MonoBehaviour {

    public float timeToGoop;
    private float lastTimeGoop;

	// Update is called once per frame
	void Update () {
		if (Time.time - lastTimeGoop > timeToGoop) {
            lastTimeGoop = Time.time;
            Instantiate(Resources.Load("GoopTest"), this.gameObject.transform.position + Vector3.up + Random.insideUnitSphere/5, Quaternion.identity);
        }
	}
}
