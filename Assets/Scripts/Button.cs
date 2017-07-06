using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;

	private Text text;
	private Button[] buttonArray;
	public static GameObject selectedDefender;

	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		text = GetComponentInChildren<Text> ();
		if (!text) {
			Debug.LogWarning ("No Cost text for " + name);
		} else {
			text.text = defenderPrefab.GetComponent<Deffender>().starCost.ToString();
		}
	}
	
	void Update () {
	
	}

	void OnMouseDown(){
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}
}
