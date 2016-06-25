using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip loseClip;

	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			Debug.Log("Create Music Player");
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
		
	}

	void OnLevelWasLoaded(int level) {
		if(instance != this) return;
		Debug.Log("MusicPlayer: Loaded Level " + level);
		music.Stop();
		switch (level) {
		case 0: // Start Menu
			music.clip = startClip;
			music.loop = true;
			break;
		case 1: // Game Menu
			music.clip = gameClip;
			music.loop = true;
			break;
		case 2: // Lose Menu
			music.clip = loseClip;
			music.loop = false;
			break;
		default:
			break;
		}

		music.Play();
	}
}
