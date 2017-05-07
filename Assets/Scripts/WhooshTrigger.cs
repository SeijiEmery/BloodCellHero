using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhooshTrigger : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		WhooshSound thing = other.gameObject.GetComponent<WhooshSound> ();
		if (thing) {
			thing.PlayWhooshSound ();
		}
	}
}
