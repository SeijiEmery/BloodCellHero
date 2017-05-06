using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float movementSpeed = 100000.0f;

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Projectile")) {
			DeleteRecursive (this.transform);
			DeleteRecursive (other.transform);
		}
	}
	static void DeleteRecursive (Transform obj) {
		while (obj.parent) {
			obj = obj.parent;
		}
		Destroy(obj.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
