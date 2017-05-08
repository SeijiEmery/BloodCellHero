using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Centralized controller for level behavior; replaces spawner and reimplements its features.
// This is a super-hacky class that was added at the last minute to enable whole-scene animation
// (representing scene properties over time in an animation curve; made possible by exposing lots
//  of stuff in this single class).
// 
// This is an alternative / replacement for 2 spawner objects (RBC + CBC).
// Was not used in the final build, though there *is* a deactivated instance in MainScene, and 
// ScalingScene was constructed specifically to test this. 
//
// To use, replace the spawner scripts, and bind all fields (we could do this automatically in 
// Start(), but eh).
//
public class ProceduralLevelController : MonoBehaviour {
	public Transform 	spawnCenter;				// external transform
	public Transform 	levelRoot; 					// for scale
	public Player 		player; 					// may need this
	public PlayerGun    playerGun;
	public float     	levelRootInitialRadius; 	// base tunnel width / radius;

	// Prefabs
	public GameObject 	rbcPrefab;
	public GameObject 	cbcPrefab;

	// Controls player fire rate on PlayerGun object; detects changes via cached playerPrevFireRate
	public float 		PLAYER_FIRE_RATE = 1.0f;	// num shots / sec
	private float 		playerPrevFireRate = 0f;

	// Red blood cell / cancer blood cell spawn rates (objects / sec)
	public float 		RBC_SPAWN_RATE = 10.0f;
	public float 		CBC_SPAWN_RATE = 10.0f;

	// Cell scaling; not fully implemented.
	// Script behavior is fine, but red / cancer cell prefabs need to have a parent empty object
	// for this to work; setting scale directly will not work b/c this is also set by animations.
	public float 		RBC_SCALE  	  = 1.0f;
	public float 		CBC_SCALE     = 1.0f;

	// Re-scales root tunnel / vein object (assumes initial scale is 1), and that can accomodate arbitrary scaling.
	// Also adjusts spawn radius to compensate.
	public float 		TUNNEL_SCALE = 1f;
	private float 		tunnelPrevScale = 0f;

	// Bounds for inner / outer spawn rings for RBC / CBC.
	// These are normalized values: 
	//  	INNER_RADIUS = 0 => no hole in center
	//		INNER_RADIUS = 0.5 => hole 1/2 radius in center
	// 		OUTER_RADIUS = 0.5 => max extent is 1/2 of radius
	//		OUTER_RADIUS = 1.0 => max extent is full radius
	// where radius = levelRootInitialRadius * levelRoot.localScale.x (.x chosen arbitrarily)
	//
	public float 		RBC_INNER_SPAWN_RADIUS = 0.4f;
	public float 		CBC_INNER_SPAWN_RADIUS = 0.2f;

	public float 		RBC_OUTER_SPAWN_RADIUS = 0.8f;
	public float 		CBC_OUTER_SPAWN_RADIUS = 0.8f;

	// Sets initial velocity (z)
	public float 		RBC_VELOCITY = 15f;
	public float 		CBC_VELOCITY = 10f;

	// Sets max initial drift value (xyz each have values in [0, DRIFT_VEL])
	public float 		DRIFT_VEL    = 0.1f;

	// Sets angular velocity bounds (random value in [MIN, MAX])
	public float 		MAX_ANGULAR_VEL = 45f;
	public float 		MIN_ANGULAR_VEL = 0f;

	// Set object lifetime directly (assumes RBC, CBC prefabs have SelfDestruct.cs attached at root level)
	public float 		RBC_LIFETIME = 10.0f;
	public float 		CBC_LIFETIME = 10.0f;

	// Internal timer values
	private float 		rbcSpawnTimer = 0f;
	private float 		cbcSpawnTimer = 0f;

	private static Vector3 GetRandomPointInCircleRange (float rMin, float rMax) {
		// Adapted http://stackoverflow.com/questions/5837572/generate-a-random-point-within-a-circle-uniformly
		float t = Random.value * 360f;
		float u = Random.value + Random.value;
		float r = (rMax - rMin) * (u > 1f ? 2 - u : u) + rMin;
		return new Vector3 (r * Mathf.Cos (t), r * Mathf.Sin (t), 0f);
	}
	// Spawns an object within this spawner's spawn radius.
	public void Spawn (Transform center, GameObject obj, float v, float minAv, float maxAv, float driftv, float minRadius, float maxRadius, float scale, float lifetime) {
		Vector3 spawnPosition = center.position + GetRandomPointInCircleRange (minRadius, maxRadius);
		GameObject instance   = Instantiate (obj, spawnPosition, Random.rotation);

		Rigidbody rb = instance.GetComponent<Rigidbody> ();

		Vector3 v0 = new Vector3(0, 0, -v) + new Vector3 (Random.value, Random.value, Random.value) * driftv;
		Vector3 av0 = new Vector3 (Random.value, Random.value, Random.value).normalized * Random.Range(minAv, maxAv);

		rb.AddForce  (v0, ForceMode.VelocityChange);
		rb.AddTorque (av0, ForceMode.VelocityChange);

		instance.GetComponent<Transform> ().localScale = new Vector3 (scale, scale, scale);
		instance.GetComponent<SelfDestruct> ().destructTime = lifetime;
	}
	public void Update () {
		
		// When PLAYER_FIRE_RATE changes, set player.fireDelay
		if (PLAYER_FIRE_RATE != playerPrevFireRate) {
			playerPrevFireRate = PLAYER_FIRE_RATE;
			playerGun.fireDelay = 1f / PLAYER_FIRE_RATE;
		}

		// when TUNNEL_SCALE changes, set levelRoot.localScale (rescales all vein objects under levelRoot)
		if (TUNNEL_SCALE != tunnelPrevScale) {
			tunnelPrevScale = TUNNEL_SCALE;
			levelRoot.localScale = new Vector3 (TUNNEL_SCALE, TUNNEL_SCALE, TUNNEL_SCALE);
		}

		// Conditionally spawn red / cancer cells
		float radius = levelRootInitialRadius * levelRoot.localScale.x;
		if ((rbcSpawnTimer -= Time.deltaTime) < 0f) {
			rbcSpawnTimer = 1f / RBC_SPAWN_RATE;
			Spawn (spawnCenter, rbcPrefab, RBC_VELOCITY, MIN_ANGULAR_VEL, MAX_ANGULAR_VEL, DRIFT_VEL, 
				radius * RBC_INNER_SPAWN_RADIUS, radius * RBC_OUTER_SPAWN_RADIUS,
				RBC_SCALE,
				RBC_LIFETIME);
		}
		if ((cbcSpawnTimer -= Time.deltaTime) < 0f) {
			cbcSpawnTimer = 1f / CBC_SPAWN_RATE;
			Spawn (spawnCenter, cbcPrefab, CBC_VELOCITY, MIN_ANGULAR_VEL, MAX_ANGULAR_VEL, DRIFT_VEL,
				radius * CBC_INNER_SPAWN_RADIUS, radius * CBC_OUTER_SPAWN_RADIUS,
				CBC_SCALE,
				CBC_LIFETIME);
		}
	}
}
