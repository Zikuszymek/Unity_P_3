using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text textObject;
	private int totalStars = 1000;
	
	void Start () {
		textObject = GetComponent<Text> ();
		updateTextView();
	}

	public void AddStars(int amount){
		totalStars += amount;
		updateTextView ();
	}

	public Status UseStars(int amount){
		if (totalStars >= amount) {
			totalStars -= amount;
			updateTextView ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}

	private void updateTextView(){
		textObject.text = totalStars.ToString ();
	}
}
