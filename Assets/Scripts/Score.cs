using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public TextMesh currScore;
	public GameObject ballPrefab;
	public Transform paddleTransf;
	public int playerScore = 0;
	GameObject ball;

	void FixedUpdate () {
		ball = GameObject.FindGameObjectWithTag ("Ball");
		currScore.text = "" + playerScore;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ball") {
			playerScore++;
			Destroy (ball);
			(Instantiate (ballPrefab, new Vector3 (paddleTransf.transform.position.x + 2, paddleTransf.transform.position.y, 0), Quaternion.identity)
				as GameObject).transform.parent = paddleTransf;
		}
	}
	
}
