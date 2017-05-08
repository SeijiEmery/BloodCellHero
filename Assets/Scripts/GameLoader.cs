using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Loads a game manager instance...?
public class GameLoader : MonoBehaviour {

	public GameObject gameManager;

	void Awake() {
		if (GameManager.Instance == null) {
			Instantiate (gameManager);
		}
	}
}
