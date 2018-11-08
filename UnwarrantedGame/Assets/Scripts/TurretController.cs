using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	void Update () {
        Debug.DrawRay(this.transform.position, Vector3.forward * 5, Color.red, 1f);
        Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, 5f, 1 << 10);
        float dot;
        Vector3 characterToCollider;
		foreach (Collider col in cols) {
            characterToCollider = (col.transform.position - transform.position).normalized;
            dot = Vector3.Dot(characterToCollider, transform.forward);
            if (dot >= Mathf.Cos(55)) {
                col.gameObject.transform.localScale = Vector3.one / 1.2f;
            }
        }
	}
}
