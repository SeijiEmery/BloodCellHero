using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerA : MonoBehaviour {
	protected float sceneStartTime;
	public float waitTimeSeconds = 3.0f;
	public string nextSceneToLoadStr;

	// Use this for initialization
	void Start () {
		sceneStartTime = (float)Time.time;

	}

	// Update is called once per frame
	void Update () {
		if ((float)(Time.time - sceneStartTime) > (waitTimeSeconds)) {
			SceneManager.LoadScene (nextSceneToLoadStr);
		}
		Debug.Log (sceneStartTime);
	}
}
