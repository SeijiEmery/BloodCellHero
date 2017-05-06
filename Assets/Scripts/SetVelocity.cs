using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocity : MonoBehaviour {

	public Vector3 initialVelocity;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
