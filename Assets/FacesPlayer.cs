using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {

	public float rotSpeed = 90;

	Transform player;

	// Update is called once per frame
	void Update () {
		if (player == null) {
			//Find player's ship
			GameObject ps = GameObject.Find("PlayerShip");

			if(ps != null) {
				player = ps.transform;
			}
		}

		if (player == null)
			return; //Skip frame

		//Face player
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
	}
}
