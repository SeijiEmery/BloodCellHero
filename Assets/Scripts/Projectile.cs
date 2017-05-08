using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements projectile behavior (attached to the white blood cell object).
// Handles collision with objects with the Enemy component (cancer cells):
//	– calls a method that will destroy the other object (triggers death anim)
// 	– destroys self
//	– updates score
//
public class Projectile : MonoBehaviour {
	void OnCollisionEnter (Collision collision) {
		Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
		if (enemy != null) {
			GameManager.Instance.UpdateScore(enemy.scoreValue);
			enemy.PlayDeathAnimation ();
			Destroy(this.gameObject);
		}
	}
}
