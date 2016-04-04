using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	float unityx;
	float unityy;
	Vector3 heroPos;

	// Use this for initialization
	void Start () {
		heroPos = new Vector3(4.5f,1.0f,3.0f);
		this.transform.position = heroPos;
		print(Screen.width);
	}
	
	// Update is called once per frame
	void Update () {
		MoveWithMouse();
	}

	void MoveWithMouse() {
		// Input.mousePosition.x/Screen.width convert mouse position into 0~1
		unityx = Input.mousePosition.x/Screen.width*9;
		unityy = Input.mousePosition.y/Screen.height*12;

		//print(unityx+", "+unityy);
		heroPos.x = Mathf.Clamp(unityx, 0.61f, 8.39f);
		heroPos.y = Mathf.Clamp(unityy, 0.39f, 11.39f);
		this.transform.position = heroPos;
	}
}
