using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float movementSpeed = 100000.0f;

	public void SetTarget (Transform target) {
		GetComponent<Rigidbody> ().AddForce((target.position - transform.position).normalized * movementSpeed);
	}

	// Update is called once per frame
	void Update () {

	}
}
