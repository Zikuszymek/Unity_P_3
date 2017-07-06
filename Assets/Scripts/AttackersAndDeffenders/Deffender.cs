using UnityEngine;
using System.Collections;

public class Deffender : MonoBehaviour {

	private StarDisplay starDisplay;
	public int starCost = 100;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	void addSomeStars(int stars){
		starDisplay.AddStars (stars);
	}
}
