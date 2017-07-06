using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range (-1f,1.5f)]
	public float currentSpeed;

	[Tooltip ("Average number od seconds between apperance")]
	public float seenEverySeconds;

	private GameObject currentTarget;
	private Animator animator;
	void Start () {
		animator = GetComponent<Animator> ();
	}

	
	void Update () {
		if (!currentTarget) {
			animator.SetBool ("Attack", false);
			transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(){
		Debug.Log ("test");
	}	

	public void setCurrentSpeed(float speed){
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage){
		Health healt = currentTarget.GetComponent<Health> ();
		if (healt)
			healt.DealDmg (damage);
	}

	public void Attack(GameObject gameObject){
		currentTarget = gameObject;
	}
}
