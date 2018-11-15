using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public float fireRate;

    private float lastFireTime;

    void Update () {
        if (Time.time - lastFireTime > fireRate) {
            lastFireTime = Time.time;
            Debug.DrawRay(this.transform.position, Vector3.forward * 5, Color.red, 1f);
            Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, 5f, 1 << 10); //5f detect distance
            float dot;
            Vector3 characterToCollider;
            foreach (Collider col in cols) {
                characterToCollider = (col.transform.position - transform.position).normalized;
                dot = Vector3.Dot(characterToCollider, transform.forward);
                if (dot >= Mathf.Cos(55)) {
                    //calculate firing angle
                    Vector3 dir = (col.gameObject.transform.position - this.gameObject.transform.position).normalized;
                    //Quaternion rotation = Quaternion.LookRotation(dir);
                    transform.LookAt(col.gameObject.transform);
                    //this.gameObject.transform.rotation = rotation;
                    GameObject sp = (GameObject)Resources.Load("SimpleProjectile");
                    sp.transform.LookAt(col.gameObject.transform);

                    Instantiate(sp, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    return;
                }
            }
        }
	}
}
