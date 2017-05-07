using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var currentScoreObj = (GameObject) GameObject.FindWithTag ("PointsText");
		currentScoreObj.GetComponent<Text>().text = GameManager.Instance.Score.ToString() + " pts";
	}
}
