using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ComputerControllerBase : MonoBehaviour {
    public Vector3 target;
    public NavMeshAgent agent;

    public void Start() {
        this.target = GameObject.FindGameObjectWithTag("Pillar").transform.position;
        agent.SetDestination(target);
    }

    public void hitByProjectile(Vector3 moveDirection, float knockbackPower) {
        IEnumerator routine = moveFromProjectile(moveDirection, knockbackPower);
        StartCoroutine(routine);
    }

    public IEnumerator moveFromProjectile(Vector3 moveDirection, float knockbackPower) {
        agent.isStopped = true;
        this.gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * knockbackPower, ForceMode.VelocityChange);
        yield return new WaitForSeconds(knockbackPower * 0.3f);
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        agent.velocity = Vector3.zero;
        agent.isStopped = false;
    }

	///Returns the x or y direction required for target 1 to reach target 2 in the shortest distance.
	public Vector3 moveTowardSimple(GameObject target1, GameObject target2){
		//get positions of object moving (target1), and destination target (target2)
		Vector3Int currentTile1 = new Vector3Int((int)target1.transform.position.x, (int)target1.transform.position.z, 0);
		Vector3Int currentTile2 = new Vector3Int((int)target2.transform.position.x, (int)target2.transform.position.z, 0);
		int xDiff = currentTile1.x - currentTile2.x;
		int yDiff = currentTile1.y - currentTile2.y;
		if (Mathf.Abs(xDiff) > Mathf.Abs(yDiff)){ //further off in x
			if(xDiff > 0)
				return Vector3.left;
			else
				return Vector3.right;
		} else if (Mathf.Abs(xDiff) < Mathf.Abs(yDiff)) { //further off in y
			if(yDiff > 0)
				return Vector3.back;
			else
				return Vector3.forward;
		} else { //even values
			if(yDiff > 0)
				return Vector3.back;
			else if (yDiff < 0)
				return Vector3.forward;
			else if (xDiff > 0)
				return Vector3.left;
			else if (xDiff < 0)
				return Vector3.right;
		}
		return Vector3.zero;
	}
}
