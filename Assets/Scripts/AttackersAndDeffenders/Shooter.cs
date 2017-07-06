using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject projectiles, gun;
	private GameObject projectileParentTest;
	private Animator animator;
	private SpawnerAttacker spawnerAttacker;

	void Start(){
		setMyLaneSpawner ();
		animator = GetComponent<Animator> ();
		projectileParentTest = GameObject.Find ("Projectiles");
		if (!projectileParentTest) {
			projectileParentTest = new GameObject("Projectiles");
		}
	}

	void Update(){
		if (isAttackerAheadInLane ()) {
			animator.SetBool ("Attack", true);
		} else {
			animator.SetBool ("Attack", false);
		}
	}

	void setMyLaneSpawner(){
		SpawnerAttacker[] spawnersAttackerList = GameObject.FindObjectsOfType <SpawnerAttacker>();
		foreach (SpawnerAttacker spawner in spawnersAttackerList) {
			if(spawner.transform.position.y == transform.position.y){
				spawnerAttacker = spawner; 
				return;
			}
		}
		Debug.LogError ("No spawner found");
	}

	bool isAttackerAheadInLane(){
		if (spawnerAttacker.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform child in spawnerAttacker.transform) {
			if(child.transform.position.x > transform.position.x){
				return true;
			}
		}
		return false;
	}

	private void Fire(){
		GameObject newProjectile = Instantiate (projectiles) as GameObject;
		newProjectile.transform.parent = projectileParentTest.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}