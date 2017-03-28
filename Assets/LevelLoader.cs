using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	public GameObject tilePrefab;
	public Camera camera;

	private float tileScale = 0.1F;
	private float tileSpacing = 2.1F;

	private GameObject[,] tiles;
	private int gridWidth = 5;
	private int gridHeight = 3;
	private int activeX = 0;
	private int activeY = 0;

	private bool inputReleased = true;

	void Start () {
		tiles = new GameObject[gridWidth, gridHeight];

		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {

				GameObject tile = Instantiate (tilePrefab);
				tile.transform.position = new Vector2 (tileSpacing * x, tileSpacing * y);
				tile.transform.localScale = new Vector2 (0.1F, 0.1F);

				tiles [x, y] = tile;
			}
		}
//
//		tiles = GameObject.FindGameObjectsWithTag("LevelTile");
//		Debug.Log ("tiles:" + tiles.Length);

		TileActiveStateManager state = tiles [activeX, activeY].GetComponent<TileActiveStateManager> ();
		state.switchToActive ();
	}
	
	// Update is called once per frame
	void Update () {
		float valueX = Input.GetAxis ("Horizontal");
		float valueY = Input.GetAxis ("Vertical");

		GameObject currentActive = tiles [activeX, activeY];
		GameObject newActive = null;

		if (!inputReleased && valueX == 0 && valueY == 0) {
			inputReleased = true;

		} else if (inputReleased && valueX < 0 && activeX > 0) {
			inputReleased = false;
			activeX--;
			newActive = tiles [activeX, activeY];

		} else if (inputReleased && valueY < 0 && activeY > 0) {
			inputReleased = false;
			activeY--;
			newActive = tiles [activeX, activeY];

		} else if (inputReleased && valueX > 0 && activeX < gridWidth-1) {
			inputReleased = false;
			activeX++;
			newActive = tiles [activeX, activeY];

		} else if (inputReleased && valueY > 0 && activeY < gridHeight-1) {
			inputReleased = false;
			activeY++;
			newActive = tiles [activeX, activeY];
		}

		if (newActive && newActive != currentActive) {
			switchActiveTile (newActive, currentActive);
		}
	}

	private void switchActiveTile(GameObject newActive, GameObject oldActive) {
		oldActive.GetComponent<TileActiveStateManager> ().switchToInactive ();
		newActive.GetComponent<TileActiveStateManager> ().switchToActive ();

		Debug.Log (newActive.transform.position);
		Debug.Log (camera.transform.position);
		Vector3 newPosition = new Vector3 (newActive.transform.position.x, newActive.transform.position.y, camera.transform.position.z);

//		camera.transform.position = Vector3.Lerp (camera.transform.position, newPosition, 1.0f);
		camera.transform.position = newPosition;
	}
}
