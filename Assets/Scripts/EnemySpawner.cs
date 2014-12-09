using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	float enemyRate = 5;
	float nextEnemy = 1;
	float spawnDistance = 7f;

	// Update is called once per frame
	void Update () {
		nextEnemy -= Time.deltaTime;

		if (nextEnemy <= 0) {
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if(enemyRate < 1){
				enemyRate = 1;
			}

			Vector3 offset = Random.onUnitSphere;

			offset.z = 0;
			offset = offset.normalized * spawnDistance;

			Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
		}
	}
}
