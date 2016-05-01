using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	private bool moveRight = true;
	public float padding = 0.5f;
	public float speed = 1.0f;
	Vector3 spawnerPos;

	float unitx = 1.0f;
	float unitt = 1.0f;
	// Defining the edge of the screen which should not be crossed
	float xmin;
	float xmax;
	float ymin;
	float ymax;

	// Use this for initialization
	void Start () {
		// distance is the between the gameObject and the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 upMost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		Vector3 startPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.2f,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
		ymin = leftMost.y + padding;
		ymax = upMost.y - padding;
		foreach( Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height,0));
	}
	
	// Update is called once per frame
	void Update () {
		if(moveRight){
			// if right edge hits the xmax, moveRight set to false;
			// position.x + width/2 + speed compares with xmax
			if(transform.position.x + width/2 + speed >= xmax) {
				moveRight = false;
			} else {// else transform.position + speed
				spawnerPos = transform.position;
				spawnerPos.x += speed;
				transform.position = spawnerPos;
			}
		} else {
			// if left edge hits the xmin, moveRight set to true
			// position.x - width/2 -speed compares with xmin
			if(transform.position.x - width/2 - speed <= xmin) {
				moveRight = true;
			} else {
				spawnerPos = transform.position;
				spawnerPos.x -= speed;
				transform.position = spawnerPos;
			}

		}
	}
}
