using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject 	spawnable;
	public double   	spawnFrequency = 1.0; // spawns per second
	private double  	spawnTimer = 0;
	public  float 		spawnRangeMin = 0f;

	private SphereCollider spawnerSphere; 	// Must be attached to this object

	public void Start () {
		spawnerSphere = GetComponent<SphereCollider> ();
	}

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
		GameObject instance = Instantiate (obj, spawnPosition, Random.rotation);
		instance.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * 100);
	}
	public void Update () {
		if ((spawnTimer -= Time.deltaTime) < 0.0) {
			spawnTimer = 1f / spawnFrequency;
			Spawn (spawnable);
		}
	}
}
