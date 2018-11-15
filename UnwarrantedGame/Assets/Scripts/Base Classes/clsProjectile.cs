using UnityEngine;

public class clsProjectile : MonoBehaviour {
    public float moveSpeed;
    public float knockbackPower;
    public float timeToDestroy;

    private Vector3 moveDirection = Vector3.forward;
    private float creationTime;

    public void Start() {
        creationTime = Time.time;
    }

    public void Update() {
        Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(moveDirection), Color.green, 1f);
        this.gameObject.transform.Translate(moveDirection * moveSpeed, Space.Self);
        if (Time.time - creationTime > timeToDestroy) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Goop")) {
            other.gameObject.GetComponent<ComputerControllerBase>().hitByProjectile(this.gameObject.transform.TransformDirection(moveDirection), this.knockbackPower);
            other.gameObject.GetComponent<clsUnitBase>().reduceHP(1);
            Destroy(this.gameObject);
        }
    }
}
