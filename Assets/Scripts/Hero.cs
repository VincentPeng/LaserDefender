using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	// constant for defining the edge of the screen which should not be crossed
	const float EDGE_LEFT = 0.67f;
	const float EDGE_RIGHT = 8.34f;
	const float EDGE_UP = 11.36f;
	const float EDGE_DOWN = 0.41f;

	float unityx;
	float unityy;
	Vector3 heroPos;
	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		heroPos = new Vector3(4.5f,1.0f,3.0f);
		this.transform.position = heroPos;
	}
	
	// Update is called once per frame
	void Update () {
		MoveWithKeyboard();
	}

	void MoveWithKeyboard() {
		bool typed = false;
		unityx = this.transform.position.x;
		unityy = this.transform.position.y;
		if(Input.GetKey(KeyCode.DownArrow)){
			typed = true;
			unityy -= speed;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			typed = true;
			unityy += speed;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			typed = true;
			unityx -= speed;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			typed = true;
			unityx += speed;
		}

		if(typed) {
			Mathf.Clamp(unityx, EDGE_LEFT, EDGE_RIGHT);
			Mathf.Clamp(unityy, EDGE_DOWN, EDGE_UP);
			heroPos.x = unityx;
			heroPos.y = unityy;
			this.transform.position = heroPos;
		}
	}


}
