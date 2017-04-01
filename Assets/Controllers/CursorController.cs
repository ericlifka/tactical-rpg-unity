using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

	private float tileSpacing;

	public void setup(float _tileSpacing) {
		tileSpacing = _tileSpacing;
	}

	public void moveToTile(GameObject tile) {
		transform.position = tile.transform.position;
	}
}
