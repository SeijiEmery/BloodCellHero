using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

	public GameObject projectile;
	public double     fireDelay = 0.1;
	public float      fireVelocity = 1.0f;
	private double    fireTimer = 0;
	private uint 	  queuedProjectiles = 0;

	// Fires a projectile from this gun transform.
	// If cannot currently fire, queues a fire action.
	public void Fire () {
//		if (!MaybeFire ()) {
//			queuedProjectiles += 1;
//		}
		MaybeFire ();
	}
	private bool MaybeFire () {
		if (fireTimer <= 0) {
			GameObject instance = Instantiate (projectile, transform.position, transform.rotation);
			instance.GetComponent<Rigidbody> ().AddForce (transform.rotation * Vector3.forward * fireVelocity, ForceMode.VelocityChange); 
			fireTimer = fireDelay;
			return true;
		}
		return false;
	}
	public void Update () {
		fireTimer -= Time.deltaTime;

		// Should we queue projectiles?
		if (queuedProjectiles > 0 && MaybeFire()) {
			queuedProjectiles -= 1;
		}
	}
}
