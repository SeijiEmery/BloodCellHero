using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Utility script: Sets the initial velocity of a rigidbody.
// Currently unused (?)
public class SetVelocity : MonoBehaviour {

	public Vector3 initialVelocity;
		
	void Start () {
		GetComponent<Rigidbody> ().velocity = initialVelocity;
	}
}
