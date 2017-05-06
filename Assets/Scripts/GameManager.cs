using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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
	}

	// Use this for initialization
	void Start () {
		Score = 0;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (GameManager.Instance.Score);
		Debug.Log ("Score");
	}

	public void UpdateScore(int ScoreIncrement) {
		GameManager.Instance.Score += ScoreIncrement;
	}
}
