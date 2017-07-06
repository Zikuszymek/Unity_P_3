using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float speed, damage;

	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		Health healt = collider.gameObject.GetComponent<Health> ();
		if (attacker && healt) {
			healt.DealDmg(damage);
			Destroy(gameObject);
		}
	}

}
