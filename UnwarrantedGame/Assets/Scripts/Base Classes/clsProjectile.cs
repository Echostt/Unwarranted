using UnityEngine;

public class clsProjectile : MonoBehaviour {
    public float moveSpeed;
    public float knockbackPower;

    private Vector3 moveDirection = Vector3.forward;

    public void Update() {
        this.gameObject.transform.Translate(moveDirection * moveSpeed, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Projectile hit " + other);
        if (other.gameObject.CompareTag("Goop")) {
            other.gameObject.gameObject.transform.position -= this.gameObject.transform.TransformDirection(moveDirection) * knockbackPower;
            other.gameObject.GetComponent<clsUnitBase>().reduceHP(1);
            Destroy(this.gameObject);
        }
    }
}
