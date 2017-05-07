using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhooshSound : MonoBehaviour {
	public AudioClip audioClip;
	public void PlayWhooshSound () {
		if (audioClip) {
			GetComponent<AudioSource> ().PlayOneShot (audioClip);
		}
	}
}
