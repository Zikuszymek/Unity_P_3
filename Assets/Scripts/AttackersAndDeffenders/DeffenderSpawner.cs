using UnityEngine;
using System.Collections;

public class DeffenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject projectileParentTest;
	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		projectileParentTest = GameObject.Find ("Deffenders");
		if (!projectileParentTest) {
			projectileParentTest = new GameObject("Deffenders");
		}
	}

	void OnMouseDown(){
		GameObject deffender = Button.selectedDefender;
		int deffenderCost = deffender.GetComponent<Deffender> ().starCost;
		StarDisplay.Status status = starDisplay.UseStars (deffenderCost);
		if (status == StarDisplay.Status.SUCCESS) {
			spawnDeffender ();
		} else {
			doNotSpawnDeffender();
		}
	}

	void doNotSpawnDeffender(){
		print ("No star today");
	}

	void spawnDeffender(){
		Vector2 rawPos = SnapToGrid (CalculateWorldPointOfMouseClick ());
		GameObject deffender = Instantiate (Button.selectedDefender, rawPos, Quaternion.identity) as GameObject;
		deffender.transform.parent = projectileParentTest.transform;
	}

	Vector2 SnapToGrid(Vector2 vectorRound){
		float roundX = Mathf.RoundToInt(vectorRound.x);
		float roundY = Mathf.RoundToInt(vectorRound.y);
		return new Vector2 (roundX, roundY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 vectorTest = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worlPosition = myCamera.ScreenToWorldPoint (vectorTest);
		return worlPosition;
	}
}
