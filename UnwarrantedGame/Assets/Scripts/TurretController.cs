using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public float fireRate;

    private GameManager gm;
    private float lastFireTime;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other) {
        //deduct turret hp/stam --------------------------
        Debug.Log("triggered! other: " + other.gameObject);
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 25, ForceMode.VelocityChange);
    }

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
                    Instantiate(Resources.Load("SimpleProjectile"), this.gameObject.transform.position + Vector3.forward, Quaternion.identity);
                }
            }
        }
	}
}
