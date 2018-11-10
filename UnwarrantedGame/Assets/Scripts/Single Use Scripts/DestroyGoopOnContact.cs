using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGoopOnContact : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Goop"))
            Destroy(other.gameObject);
    }
}
