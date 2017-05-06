using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public static int ScoreIncrement = 10;

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Projectile")) {
			DeleteRecursive (this.transform);
			DeleteRecursive (other.transform);
			GameManager.Instance.UpdateScore (ScoreIncrement);
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
