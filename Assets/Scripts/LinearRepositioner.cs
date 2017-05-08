using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resposible for moving and creating the illusion of an infinitely receding tube.
// Requires that tube / vein geometry tile (ie. is identical), and has uniform width;
// our setup uses 40 units, and rescales the parent object to scale further.
//
// See the LinearRepeatingVein / VeinSegment prefabs.
//
// Note: when used properly, the illusion works perfectly, but too short tube, too
// close end caps, improperly set fog values, or imperfections in the tube itself
// (is there one in MainScene?) can cause this to break somewhat (can see that the
// tube is jumping back every x seconds, albeit subtly).
//
public class LinearRepositioner : MonoBehaviour {
	public double  velocity;
//	public string targetTag = "Vein";
	public double segmentLength = 40;
	public int    numSegments   = 1; 	// number of segments until loop. Could be 2, 3, etc., though 1 works fine.
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
