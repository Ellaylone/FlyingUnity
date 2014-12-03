using UnityEngine;
using System.Collections;

public class PlayerShootin : MonoBehaviour {

	float cooldownTime = 0;
	public float fireDelay = 0.25f;

	// Update is called once per frame
	void Update () {
		cooldownTime -= Time.deltaTime;
		if (Input.GetButton ("Fire1")) {
			//Shoot!
			cooldownTime = fireDelay;
		}
	}
}
