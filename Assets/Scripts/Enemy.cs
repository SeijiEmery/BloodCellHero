using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements an enemy behavior, used by the cancer cell.
public class Enemy : MonoBehaviour {
	public int scoreValue = 10;

	// Begins a death animation that destroys this object.
	// Depends on the cancer cell animation controller.
	public void PlayDeathAnimation () {
		GetComponent<Animator> ().SetBool ("killed", true);
	}

	// Destroys this object (used by cancer_cell_dissolve_animation)
	public void DestroySelf () {
		Destroy (this.gameObject);
	}
}
