using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int myScore = 0;
	private Text scoreBoard;

	// Use this for initialization
	void Start() {
		scoreBoard = GetComponent<Text> ();
	}

	public void AddScore(int score) {
		myScore += score;
		scoreBoard.text = myScore.ToString ();
	}

	public static void Reset() {
		myScore = 0;
	}

	public static int GetScore() {
		return myScore;
	}
}
