using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	
	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);

	int bulletLayer;
	float cooldownTimer = 0;
	public float fireDelay = 0.5f;

	Transform player;

	void Start() {
		bulletLayer = gameObject.layer;
	}
	// Update is called once per frame
	void Update () {
		if (player == null) {
			//Find player's ship
			GameObject ps = GameObject.FindWithTag("Player");
			
			if(ps != null) {
				player = ps.transform;
			}
		}

		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 5) {
			//Shoot!
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;
			
			GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;		
		}
	}
}
