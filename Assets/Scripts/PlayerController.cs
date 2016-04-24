using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	

	float unityx;
	float unityy;
	Vector3 heroPos;
	public float speed = 0.5f;
	public float padding = 0.5f;

	// Defining the edge of the screen which should not be crossed
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		Vector3 startPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.2f,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
		ymin = leftMost.y + padding;
		ymax = upMost.y - padding;
		heroPos = startPoint;
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
			unityy -= speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			typed = true;
			unityy += speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			typed = true;
			unityx -= speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			typed = true;
			unityx += speed * Time.deltaTime;
		}

		if(typed) {
			// Restrict Player in the box
			unityx = Mathf.Clamp(unityx, xmin, xmax);
			unityy = Mathf.Clamp(unityy, ymin, ymax);
			//Debug.Log(unityx + "," + unityy);
			heroPos.x = unityx;
			heroPos.y = unityy;
			this.transform.position = heroPos;
		}
	}


}
