using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements very simple gun / firing behavior to shoot white blood cells.
// Should be attached to an empty object under whichever player object contains the camera.
// More complex mechanics weren't really considered due to time constraints.
// In my own words, this is "the simplest behavior that doesn't produce annoying results".
//
public class PlayerGun : MonoBehaviour {

	public GameObject projectile;
	public double     fireDelay = 0.1;
	public float      fireVelocity = 1.0f;
	private double    fireTimer = 0;

	// Fires a projectile from this gun transform.
	// redundant; was originally used to implement slightly different mechanics, and distinction
	// could prove useful in the future:
	//		Fire() is used to tell the gun to fire, and always succeeds
	//		MaybeFire() implements the actual firing action, and may fail (firing action on cooldown).
	//
	public void Fire () {
		MaybeFire ();
	}

	// Tries firing; returns true iff successful
	private bool MaybeFire () {
		if (fireTimer <= 0) {
			GameObject instance = Instantiate (projectile, transform.position, transform.rotation);
			instance.GetComponent<Rigidbody> ().AddForce (transform.rotation * Vector3.forward * fireVelocity, ForceMode.VelocityChange); 
			fireTimer = fireDelay;

			GetComponent<AudioSource> ().Play ();
			return true;
		}
		return false;
	}
	public void Update () {
		fireTimer -= Time.deltaTime;
	}
}
