using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	
	public Player 	player;
	public GameObject enemyToSpawn;
	public float 	spawnerRadius = 10.0f;
	public double   spawnFrequency = 1.0; // spawns per second
	private double  spawnTimer = 0;


	// Spawns an enemy within this spawner's spawn radius.
	public void Spawn (GameObject enemy) {
		GameObject instance = Instantiate (enemy, transform.position + Random.insideUnitSphere * spawnerRadius, transform.rotation);
		instance.GetComponent<Enemy>().SetTarget (player.transform);
	}
	public void Update () {
		if ((spawnTimer -= Time.deltaTime) < 0.0) {
			spawnTimer = spawnFrequency;
			Spawn (enemyToSpawn);
		}
	}
}
