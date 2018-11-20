using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public float fireRate;
    public float fireRange;
    public float fireAngle;

    private float lastFireTime;

    void Update () {
        if (Time.time - lastFireTime > fireRate) {
            lastFireTime = Time.time;

            Vector3 v = Vector3.forward;
            v = Quaternion.Euler(
                this.gameObject.transform.rotation.x,
                this.gameObject.transform.rotation.y + fireAngle,
                this.gameObject.transform.rotation.z) * v;
            Vector3 vv = Vector3.forward;
            vv = Quaternion.Euler(
                this.gameObject.transform.rotation.x,
                this.gameObject.transform.rotation.y + fireAngle * -1,
                this.gameObject.transform.rotation.z) * vv;

            Debug.DrawRay(this.transform.position, v * fireRange, Color.red, 1f);
            Debug.DrawRay(this.transform.position, vv * fireRange, Color.red, 1f);

            Debug.Log(vv);

            Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, fireRange, 1 << 10); //detect distance
            float dot;
            Vector3 characterToCollider;
            foreach (Collider col in cols) {
                characterToCollider = (col.transform.position - transform.position).normalized;
                dot = Vector3.Dot(characterToCollider, transform.forward);
                if (dot >= Mathf.Cos(fireAngle)) {
                    //calculate firing angle
                    Vector3 dir = (col.gameObject.transform.position - this.gameObject.transform.position).normalized;
                    transform.LookAt(col.gameObject.transform);
                    GameObject sp = (GameObject)Resources.Load("SimpleProjectile");
                    sp.transform.LookAt(col.gameObject.transform);

                    Instantiate(sp, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    return;
                }
            }
        }
	}
}
