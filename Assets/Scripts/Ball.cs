using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballSpeed = 1000;
	bool isMoving = false;
	int direction;
	Rigidbody rb; 

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		direction = Random.Range (1, 3);
	}

	void FixedUpdate () {
		moveBall ();
	}

	
	//todo: fix ball physics (now it can get stuck between walls moving ↑ ↓ up and down 90 degree angle)
	private void moveBall() {
		if (Input.GetKeyDown ("space") && !isMoving) {
			isMoving = true;
			transform.parent = null;
			rb.isKinematic = false;
			if (direction == 1) {
				rb.AddForce (new Vector3 (ballSpeed, ballSpeed, 0));
			} else if (direction == 2) {
				rb.AddForce (new Vector3 (-ballSpeed, -ballSpeed, 0));
			}
		}
	}

}
