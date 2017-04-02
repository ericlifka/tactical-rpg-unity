using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Vector3 startMarker;
	public Vector3 endMarker;

	private float speed = 10.0F;

	private float startTime = -1;
	private float journeyLength;

	void Start() {
		
	}

	void Update() {
		if (startTime < 0) {
			return;
		}

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

		if (fracJourney >= 1.0) {
			startTime = -1;
		}
	}

	public void trackToPosition(Vector3 newPosition) {
		startTime = Time.time;
		startMarker = transform.position;
		endMarker = new Vector3(
			newPosition.x,
			newPosition.y,
			transform.position.z
		);

		journeyLength = Vector3.Distance(startMarker, endMarker);
	}

	public void moveToPosition(Vector3 newPosition) {
		startTime = -1;
		transform.position = new Vector3(
			newPosition.x,
			newPosition.y,
			transform.position.z);
	}
}
