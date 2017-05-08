using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Super-helpful utility script: implements self-destruction after X seconds for prefabs.
// Used for white, red, and cancer cells.
public class SelfDestruct : MonoBehaviour {

	public double destructTime;

	// Update is called once per frame
	void Update () {
		if ((destructTime -= Time.deltaTime) < 0) {
			Destroy (this.gameObject);
		}
	}
}
