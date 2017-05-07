using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int scoreValue = 10;

	public void PlayDeathAnimation () {
		Debug.Log ("Killing object");
		GetComponent<Animator> ().SetBool ("killed", true);
	}
	public void DestroySelf () {
		Destroy (this.gameObject);
	}
}
