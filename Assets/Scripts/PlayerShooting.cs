using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject bulletPrefab;

	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);

	float cooldownTimer = 0;
	public float fireDelay = 0.25f;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (Input.GetButton ("Fire1") && cooldownTimer <= 0) {
			//Shoot!
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
		}
	}
}
