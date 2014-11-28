using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float maxSpeed = 5f; //Max movement speed
	float rotSpeed = 180f; //Max rotation speed

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Ship Rotation

		//Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		//Grab the Z euler angle
		float z = rot.eulerAngles.z;

		//Change the Z angle based on input
		z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

		//Recreate the quaternion
		rot = Quaternion.Euler (0, 0, z);

		//Feed the quaternion into our rotation
		transform.rotation = rot;

		//Ship Movement
		Vector3 pos = transform.position;
		
		//Change the Y based on input
		Vector3 velocity = new Vector3 (0, Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime, 0);

		pos += rot * velocity;

		//Set position
		transform.position = pos; 
	}
}
