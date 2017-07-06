using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeAray;
	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don destroy: " + name);
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}
	void Start () {
		audioSource.clip = levelMusicChangeAray [0];
		audioSource.loop = false;
		audioSource.Play ();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip audioClip = levelMusicChangeAray [level];
		Debug.Log ("Play " + audioClip);
		if (audioClip) {
			audioSource.Stop ();
			audioSource.clip = levelMusicChangeAray [level];
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void ChangeVolume(float volumeLevel){
		audioSource.volume = volumeLevel;
	}
}
