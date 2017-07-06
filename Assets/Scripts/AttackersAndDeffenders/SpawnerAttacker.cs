using UnityEngine;
using System.Collections;

public class SpawnerAttacker : MonoBehaviour {

	public GameObject[] attackerPrefab;
	
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefab) {
			if(isTimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		if (Time.deltaTime > meanSpawnDelay) {
		
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		return (Random.value < threshold);
	}

	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
