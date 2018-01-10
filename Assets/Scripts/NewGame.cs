using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewGame : MonoBehaviour {

	Vector3 original;

	void OnMouseEnter () {
		original = transform.localScale;
		transform.localScale *= 0.9f; //todo: fix animation bug when mouse hovers the edge
	}

	void OnMouseExit () {
		transform.localScale = original;
	}

	void OnMouseDown () {
		Loader.Load(1);
	}

}
