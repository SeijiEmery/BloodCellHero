using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains systems to manage scores, level timers, etc.
// Only partially implemented.
//
// Note: has some super-crappy code (time-related stuff; constructing time with
// getMinutes() / getSeconds() is just _wrong_); in my defense, this was added in the 
// last ~1 hour of the game jam, when we desperately needed to finish UI
//
// (plan was to have points (accumulated by killing cancer cells) + level timer
// (fixed time to kill cancer cells in) that ticks down visually, in VR / desktop.
// Technically we succeeded, but the level doesn't end...).
//
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
	}

	public void UpdateScore(int ScoreIncrement) {
		GameManager.Instance.Score += ScoreIncrement;
	}
}
