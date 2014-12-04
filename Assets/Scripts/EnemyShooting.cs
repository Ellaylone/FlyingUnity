using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	
	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);
	
	float cooldownTimer = 0;
	public float fireDelay = 0.5f;
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (cooldownTimer <= 0) {
			//Shoot!
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;
			
			GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = gameObject.layer;		
		}
	}
}
