using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this to things that should go "whoosh" (red cells, cancer cells).
// Specifically, it just plays back a single audio clip on an object with an audio
// source when that object hits a trigger around the player object.
// Thus, we get "whooshing" shounds as objects fly by.
public class WhooshSound : MonoBehaviour {
	public AudioClip audioClip;
	public void PlayWhooshSound () {
		if (audioClip) {
			GetComponent<AudioSource> ().PlayOneShot (audioClip);
		}
	}
}
