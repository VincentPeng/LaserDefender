using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 250.0f;

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("hits");
		Projectile missile = other.gameObject.GetComponent<Projectile>();
		if(missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if(health<=0) {
				Destroy(gameObject);
			}
			//Debug.Log("hit by a projectile");
		}
	}
}
