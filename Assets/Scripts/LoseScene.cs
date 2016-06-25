using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseScene : MonoBehaviour {

	// Use this for initialization
	void Start() {
		Text finalScore = GameObject.Find("ScoreValue").GetComponent<Text>();
		Debug.Log("score is " + ScoreKeeper.myScore);
		finalScore.text = ScoreKeeper.myScore.ToString();
		ScoreKeeper.Reset();
	}
}
