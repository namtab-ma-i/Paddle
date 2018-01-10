using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour {

	public float ballSpeed = 500; 
	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (ballSpeed, ballSpeed, 0));
	}

}
