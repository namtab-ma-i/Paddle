using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1;
	public Vector3 playerPos;

	void FixedUpdate() {
		float yPos = gameObject.transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
		playerPos = new Vector3(gameObject.transform.position.x, Mathf.Clamp(yPos, -13f, 13f), 0);
		gameObject.transform.position = playerPos;
	}
		
}
