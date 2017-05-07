using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawnable : MonoBehaviour
{
	public double lifetime = 10;
	public void SetLifetime (double time) { lifetime = time; }
	void Update () {
		if ((lifetime -= Time.deltaTime) < 0) {
			Destroy (this.gameObject);
		}
	}
}
