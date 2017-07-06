using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	void Start(){
		if (autoLoadNextLevel <= 0) {
			Debug.Log("Autolad disable");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevel);
		}
	}

	public void loadLevel(string levelName){
		Application.LoadLevel (levelName);
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
