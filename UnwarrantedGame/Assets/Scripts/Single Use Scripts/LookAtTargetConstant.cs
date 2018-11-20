using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetConstant : MonoBehaviour {

    public GameObject target;

	void Update () {
        this.transform.LookAt(target.gameObject.transform.position, Vector3.up);
    }
}
