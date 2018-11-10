using UnityEngine;

public class clsProjectile : MonoBehaviour {
    public float moveSpeed;
    public float knockbackPower;

    private Vector3 moveDirection;

    public void Start() {
        moveDirection = Vector3.forward; //temp for shooting straight
    }

    public void Update() {
        this.gameObject.transform.Translate(moveDirection * moveSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Projectile hit " + other);
        if (CompareTag("Goop")) {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * knockbackPower, ForceMode.Impulse);
            other.gameObject.GetComponent<clsUnitBase>().reduceHP(1);
            Destroy(this.gameObject);
        }
    }
}
