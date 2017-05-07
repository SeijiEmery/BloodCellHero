using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	void OnCollisionEnter (Collision collision) {
		Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
		if (enemy != null) {
			GameManager.Instance.UpdateScore(enemy.scoreValue);
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}
	}
}
