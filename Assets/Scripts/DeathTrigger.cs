using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	const bool killEverything = true;
	public string[] killTags;

	public void OnTriggerEnter (Collider other) {
		if (killEverything) {
			Destroy (other.gameObject);
		} else {
			foreach (string tag in killTags) {
				if (other.gameObject.CompareTag (tag)) {
					Destroy (other.gameObject);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
