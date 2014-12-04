using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f; //Max movement speed
	public float rotSpeed = 180f; //Max rotation speed
	public float shipBoundaryRadius = 0.5f; //Ship radius

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

		//Restrict the player to the camera's boundaries
		//Vertical bound
		if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		//Calculate orthographic width based on screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		//Horizontal bounds
		if (pos.x + shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if (pos.x - shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}

		//Set position
		transform.position = pos; 
	}
}
