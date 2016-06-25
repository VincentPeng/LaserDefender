using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject bullet;
	public float health = 250.0f;
	public float bulletSpeed = 20.0f;
	public float repeatRate = 4.0f;
	public float shotsPerSecond = 0.5f;
	public AudioClip destroyAudio;

	private Vector3 startPosition;
	//private bool gameStarted = false;
	private ScoreKeeper scoreKeeper;
	private static int scoreValue = 150;

	void Start() {
		//gameStarted = false;
		repeatRate = Random.value * 10000;
		Invoke("Fire", Random.Range(1.5f, 4.0f));
		scoreKeeper = GameObject.Find("ScoreBoard").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("hits");
		Projectile missile = other.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}

			//Debug.Log("hit by a projectile");
		}
	}

	void Update() {
//		if(gameStarted) {
//			// Limit the shooting rate using Time.deltaTime and Random.value
//			float probability = Time.deltaTime * shotsPerSecond;
//			Debug.Log("Time.deltaTime: "+Time.deltaTime+" probability: "+probability);
//			if(Random.value < probability) {
//				Fire();
//			}
//
//		} else if(Input.GetKeyDown(KeyCode.Space)) {
//			gameStarted = true;
//		}
	}

	void FireRamdom() {
		
	}

	// Fire a bullet
	void Fire() {
		startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject beam = Instantiate(bullet, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed, 0);
		Invoke("Fire", Random.Range(1.5f, 4.0f));
	}

	void Die() {
		scoreKeeper.AddScore(scoreValue);
		AudioSource.PlayClipAtPoint(destroyAudio, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
