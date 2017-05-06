using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidMotion : MonoBehaviour {

	public float force = 10.0f;

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().AddForce (Vector3.back * force * Time.deltaTime);
	}
}
