using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;

	public float invulnTimer = 0.5f;
	int correctLayer;

	void Start(){
		correctLayer = gameObject.layer;
	}

	//Collision triggered
	void OnTriggerEnter2D(){

		health--;

		gameObject.layer = 10;
	}

	void Update(){
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <= 0) {
			gameObject.layer = correctLayer;
		}
		if (health <= 0) {
				Die ();
		}
	}

	void Die(){
		Destroy (gameObject);
	}
}
