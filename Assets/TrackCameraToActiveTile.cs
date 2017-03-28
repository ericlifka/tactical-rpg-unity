using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCameraToActiveTile : MonoBehaviour {

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void trackToPosition(Vector2 newPosition) {
		Vector3 newCameraPosition = new Vector3(
			                            newPosition.x,
			                            newPosition.y,
			                            transform.position.z
		                            );

		transform.position = newCameraPosition;


		//		camera.transform.position = Vector3.Lerp (camera.transform.position, newPosition, 1.0f);
		//			camera.transform.position = newPosition;
	}
}
