using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public uint levelDuration_minutes = 2;
	public uint levelDuration_seconds = 30;
	private float levelEndTime;

	public uint minutesRemaining;
	public uint secondsRemaining;

	//
	// Usage: OnLevelEnded += <your method>
	//

	public delegate void LevelEndAction ();
	public static event LevelEndAction OnLevelEnded;

	public int Score;
	// public static int ScoreIncrement;

	public static GameManager Instance {
		get;
		protected set;
	}
		
	public void Awake() 
	{
		// destroy game instances if they already exist
		if ( Instance != null )
		{
			Destroy( Instance.gameObject );
		}

		Instance = this;
		DontDestroyOnLoad( gameObject );

		levelEndTime = Time.time + ((float)levelDuration_minutes * 60 + (float)levelDuration_seconds);
	}

	private float GetLevelTimeRemaining () {
		return levelEndTime - Time.time;
	}
	private static uint getMinutes (float time) {
		return (uint)time / 60;
	}
	private static uint getSeconds (float time) {
		return (uint)time % 60;
	}
		
	// Use this for initialization
	void Start () {
		Score = 0;
	}

	// Update is called once per frame
	void Update () {
		float time = levelEndTime - Time.time;
		minutesRemaining = (uint)time / 60;
		secondsRemaining = (uint)time % 60;
		if (time < 0) {
			OnLevelEnded ();
		}
		Debug.Log ("Time remaining: " + minutesRemaining + ":" + secondsRemaining);

//		Debug.Log (GameManager.Instance.Score);
//		Debug.Log ("Score");
	}

	public void UpdateScore(int ScoreIncrement) {
		GameManager.Instance.Score += ScoreIncrement;
	}
}
