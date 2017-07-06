using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[Range(0,1000)]
	public float health;

	public void DealDmg(float damage){
		health -= damage;
		if (health <= 0)
			Destroy (gameObject);
	}
}
