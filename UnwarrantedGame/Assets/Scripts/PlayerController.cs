using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float cameraSpeed;

    void Update() {
        if (Input.GetAxis("Mouse X") < 0) { //left
            this.gameObject.GetComponentInChildren<Camera>().transform.Rotate(Vector3.down, cameraSpeed, Space.World);
        }
        if (Input.GetAxis("Mouse X") > 0) { //right
            this.gameObject.GetComponentInChildren<Camera>().transform.Rotate(Vector3.up, cameraSpeed, Space.World);
        }
        if (Input.GetAxis("Mouse Y") > 0) { //down
            this.gameObject.GetComponentInChildren<Camera>().transform.Rotate(Vector3.left, cameraSpeed, Space.World);
        }
        if (Input.GetAxis("Mouse Y") < 0) { //up
            this.gameObject.GetComponentInChildren<Camera>().transform.Rotate(Vector3.right, cameraSpeed, Space.World);
        }
        if (Input.GetKey("w")) {
            this.gameObject.transform.Translate(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey("a")) {
            this.gameObject.transform.Translate(Vector3.left * moveSpeed);
        }
        if (Input.GetKey("s")) {
            this.gameObject.transform.Translate(Vector3.back * moveSpeed);
        }
        if (Input.GetKey("d")) {
            this.gameObject.transform.Translate(Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.Space)) {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}
