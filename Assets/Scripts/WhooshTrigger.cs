using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used on spherical trigger around player to activate whooshing noises (red / cancer cells).
// See WhooshSound.cs
public class WhooshTrigger : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		WhooshSound thing = other.gameObject.GetComponent<WhooshSound> ();
		if (thing) {
			thing.PlayWhooshSound ();
		}
	}
}
