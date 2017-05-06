using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public double destructTime;

	// Update is called once per frame
	void Update () {
		if ((destructTime -= Time.deltaTime) < 0) {
			Destroy (this.gameObject);
		}
	}
}
