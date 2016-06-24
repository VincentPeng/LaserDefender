using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private int myScore = 0;
	private Text scoreBoard;

	// Use this for initialization
	void Start () {
		scoreBoard = GetComponent<Text>();
		Reset();
	}

	public void AddScore(int score) {
		myScore += score;
		scoreBoard.text = myScore.ToString();
	}

	public void Reset() {
		myScore = 0;
		scoreBoard.text = myScore.ToString();
	}

	public int GetScore() {
		return myScore;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
