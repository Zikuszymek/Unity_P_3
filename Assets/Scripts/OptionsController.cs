using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSLider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		LoadSettings ();
	}
	
	void Update () {
		musicManager.ChangeVolume (volumeSLider.value);
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSLider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
	}

	public void SetDefaults(){
		PlayerPrefsManager.SetMasterVolume (0.8f);
		PlayerPrefsManager.SetDifficulty (2f);
		LoadSettings ();
	}

	private void LoadSettings(){
		volumeSLider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
}
