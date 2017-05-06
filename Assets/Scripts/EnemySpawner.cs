using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	
	public Player 	player;
	public GameObject enemyToSpawn;
	public double   spawnFrequency = 1.0; // spawns per second
	private double  spawnTimer = 0;

	private SphereCollider spawnerSphere; 	// Must be attached to this object

	public void Start () {
		spawnerSphere = GetComponent<SphereCollider> ();
	}

	// Spawns an enemy within this spawner's spawn radius.
	public void Spawn (GameObject enemy) {
		Vector3 spawnPosition = transform.position + spawnerSphere.center + Random.insideUnitSphere * spawnerSphere.radius;
		GameObject instance = Instantiate (enemy, spawnPosition, transform.rotation);
	}
	public void Update () {
		if ((spawnTimer -= Time.deltaTime) < 0.0) {
			spawnTimer = spawnFrequency;
			Spawn (enemyToSpawn);
		}
	}
}
