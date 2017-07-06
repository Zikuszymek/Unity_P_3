using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("wrong volume range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

	public static void SetDifficulty(float difficulty){
		if(difficulty >= 0f && difficulty <= 3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Wrong level number");
		}
	}

	public static void SetLevelKey(int level){
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1);
		} else {
			Debug.LogError("Wrong level number");
		}
	}

	public static bool GetLevelKey(int level){
		if (level <= Application.levelCount - 1) {
			if(PlayerPrefs.GetInt (LEVEL_KEY + level.ToString()) == 1){
				return true;
			} else {
				return false;
			}
		} else {
			Debug.LogError("Wrong level number");
			return false;
		}
	}
}
