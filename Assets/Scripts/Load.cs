using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load : MonoBehaviour {

	Vector3 original;

	void OnMouseEnter () {
		original = transform.localScale;
		transform.localScale *= 0.9f;
	}

	void OnMouseExit () {
		transform.localScale = original;
	}

	void OnMouseDown () {
		SceneManager.LoadScene (2); //todo: add custom level openings 
	}
	
}
