using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implements spawner behavior used to instantiate red / cancer cells.
// Has controls for spawn frequency, initial velocity (z), random velocity (xyz), 
// random angular velocity / torque, and object lifetime.
//
// Spawns evenly distributed objects in a ring, with:
//	– outer radius defined by radius of attached spherecollider (disabled; used only as visual marker)
//  – inner radius defined by spawnRangeMin
//
// This is important / useful, since:
//	– ring radius can match, or be slightly less than, diameter of veins / tubes (circular)
// 	- it's important that objects not get spawned right in front of the player (hits camera / chaotic).
//    objects *might* drift there ofc, which is considered acceptable.
//
// Note that all public fields are animabable; it was my original intention to define level behavior
// over time using these + animation curves, but due to time constriants, this didn't really get implemented.
// See also: ProceduralLevelController.cs
//
public class Spawner : MonoBehaviour {
	
	public GameObject 	spawnable; 							// thing to spawn; must have rigidbody
	public double   	spawnFrequency = 1.0; 				// spawns per second

	public float        spawnVelocity  = 10.0f; 			// scaled by mass
	public float        spawnVelocityRandomFactor = 0.0f; 	// scaled by mass
	public float        spawnTorqueRandomFactor = 1.0f; 	// scaled by mass
	public float 		spawnLifetime = 0;

	public  float 		spawnRangeMin = 0f; 				// min range (max range = sphere collider radius)

	private double  	spawnTimer = 0;
	private SphereCollider spawnerSphere; 	// Must be attached to this object

	public void Start () {
		spawnerSphere = GetComponent<SphereCollider> ();
	}

	// utility method
	private static Vector3 GetRandomPointInCircleRange (float rMin, float rMax) {
		// Adapted http://stackoverflow.com/questions/5837572/generate-a-random-point-within-a-circle-uniformly
		float t = Random.value * 360f;
		float u = Random.value + Random.value;
		float r = (rMax - rMin) * (u > 1f ? 2 - u : u) + rMin;
		return new Vector3 (r * Mathf.Cos (t), r * Mathf.Sin (t), 0f);
	}

	// Spawns an object within this spawner's spawn radius.
	public void Spawn (GameObject obj) {
		Vector3 spawnPosition = transform.position + spawnerSphere.center + GetRandomPointInCircleRange (spawnRangeMin, spawnerSphere.radius);
		GameObject instance   = Instantiate (obj, spawnPosition, Random.rotation);
	
		Rigidbody rb = instance.GetComponent<Rigidbody> ();

		Vector3 v0 = Vector3.back * spawnVelocity + new Vector3 (Random.value, Random.value, Random.value) * spawnVelocityRandomFactor;
		Vector3 t0 = new Vector3 (Random.value, Random.value, Random.value) * spawnTorqueRandomFactor;

		rb.AddForce(v0, ForceMode.VelocityChange);
		rb.AddTorque (t0, ForceMode.VelocityChange);

		instance.GetComponent<SelfDestruct> ().destructTime = spawnLifetime;
	}

	public void Update () {
		if ((spawnTimer -= Time.deltaTime) < 0.0) {
			spawnTimer = 1f / spawnFrequency;
			Spawn (spawnable);
		}
	}
}
