using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//todo: make enemy not ai; or make it fucking smarter
	
	public float speed = 8;
	Vector3 ballPos;
	Vector3 playerPos;
	GameObject ball;

	void FixedUpdate () {
		ball = GameObject.FindGameObjectWithTag ("Ball");
		ballPos = Vector3.Lerp (gameObject.transform.position, ball.transform.position, Time.deltaTime * speed);
		playerPos = new Vector3(gameObject.transform.position.x, Mathf.Clamp(ballPos.y, -13f, 13f), 0);
		gameObject.transform.position = new Vector3 (20, playerPos.y, 0);
	}
}
