using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdater : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var timerObj = (GameObject) GameObject.FindWithTag ("TimerText");
		timerObj.GetComponent<Text>().text = GameManager.Instance.minutesRemaining.ToString() + ":" + GameManager.Instance.secondsRemaining.ToString();
	}
}

