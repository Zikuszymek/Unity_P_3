using UnityEngine;
using System.Collections;

public class Shreeder : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider){
		Debug.Log ("Collision");
		Destroy (collider.gameObject);
	}
}
