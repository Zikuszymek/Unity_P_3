using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizzard : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;

	void Start () {
		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
	
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject colliderObject = collider.gameObject;
		if (!colliderObject.GetComponent<Deffender> ()) {
			return;
		} else {
			animator.SetBool("Attack", true);
			attacker.Attack(colliderObject);
		}
	}
}
