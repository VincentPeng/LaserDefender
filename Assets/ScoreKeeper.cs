using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private int myScore = 0;
	private Text scoreBoard;

	// Use this for initialization
	void Start () {
		scoreBoard = GetComponent<Text>();
		scoreBoard.text = myScore.ToString();
	}

	public void AddScore(int score) {
		myScore += score;
		scoreBoard.text = myScore.ToString();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
