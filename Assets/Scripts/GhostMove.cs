using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {

	public Transform[] waypoints;
	int cur=0;

	public float speed = 0.3f;

	void FixedUpdate(){

		//If waypoint is not reached
		if (transform.position != waypoints [cur].position) {
			Vector2 p = Vector2.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody2D> ().MovePosition (p);
		}
		//If waypoint is reached
		else {
			cur = (cur + 1) %waypoints.Length;
		}

		//Set Animation Parameters
		Vector2 dir = waypoints [cur].position - transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);


	}

	void OnTriggerEnter2D(Collider2D co){
		if (co.name == "pacman") {
			Destroy(co.gameObject);
		}
	}


}
