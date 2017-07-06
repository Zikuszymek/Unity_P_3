using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	public float levelSeconds = 100; 
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		audioSource = GetComponent<AudioSource> ();
		slider = GetComponent<Slider> ();
	}
	
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		bool isTimesUp = Time.timeSinceLevelLoad >= levelSeconds;
		if (isTimesUp && !isEndOfLevel) {
			HandleWInCondition ();
		}
	}

	void HandleWInCondition ()
	{
		DestroyAllTaggedObjects ();
        if (audioSource)
        {
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
        else
        {
            Invoke("LoadNextLevel", 0);
        }
        isEndOfLevel = true;
	}

	void DestroyAllTaggedObjects(){
		GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag ("Destroy");
		foreach (GameObject taggedObject in objectsToDestroy) {
			Destroy(taggedObject);
		}
	}

	private void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
