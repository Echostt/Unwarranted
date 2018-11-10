using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopProjectile : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
