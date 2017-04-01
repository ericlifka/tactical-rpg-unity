using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Vector3 startMarker;
	public Vector3 endMarker;

	private float speed = 10.0F;

	private float startTime;
	private float journeyLength;

	void Start() {
		
	}

	void Update() {
		if (startTime == null) {
			return;
		}

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
	}

	public void trackToPosition(Vector2 newPosition) {
		startTime = Time.time;
		startMarker = transform.position;
		endMarker = new Vector3(
			newPosition.x,
			newPosition.y,
			transform.position.z
		);

		journeyLength = Vector3.Distance(startMarker, endMarker);
	}
}
