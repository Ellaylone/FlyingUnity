using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
		//Bullet Movement
		Vector3 pos = transform.position;
		
		//Change the Y based on input
		Vector3 velocity = new Vector3 (0, maxSpeed * Time.deltaTime, 0);
		
		pos += transform.rotation * velocity;

		transform.position = pos;
	}
}
