using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearRepositioner : MonoBehaviour {
	public double  velocity;
//	public string targetTag = "Vein";
	public double segmentLength = 120;
	public int    numSegments   = 1;
//	void ResetPosition () {
//		transform.position.z = (float)(((double)transform.position.z) % (segmentLength * numSegments));
//	}
	void Update () {
		// Issue / limitation: operations done relative to origin
//		float truncOffset = (float)(segmentLength * numSegments);
		double zcoord = (double)transform.position.z - velocity * Time.deltaTime;
		double z1     = zcoord + segmentLength * numSegments * transform.localScale.z;
		transform.position = new Vector3 (transform.position.x, transform.position.y, z1 > 0 ? (float)zcoord : (float)z1);
//		if ((transform.position.z -= velocity * Time.deltaTime) >= truncOffset) {
//			transform.position.z += truncOffset;
//		}
	}
}
