using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	Vector3 original;

	void OnMouseEnter () {
		original = transform.localScale;
		transform.localScale *= 0.9f;
	}

	void OnMouseExit () {
		transform.localScale = original;
	}

	void OnMouseDown () {
		Application.Quit ();
	}

}
