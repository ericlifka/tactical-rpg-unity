using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject tilePrefab;
	public CameraController camera;
	public LevelLoader levelLoader;
	public CursorController cursor;

	private float tileScale = 0.1F;
	private float tileSpacing = 2.1F;

	private GameObject[,] tiles;
	private int gridWidth = 9;
	private int gridHeight = 5;
	private int activeX = 0;
	private int activeY = 0;

	private bool inputReleased = true;

	void Start() {
		cursor.setup(tileSpacing);

		tiles = new GameObject[gridWidth, gridHeight];

		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {

				GameObject tile = Instantiate(tilePrefab);
				tile.transform.position = new Vector2(tileSpacing * x, tileSpacing * y);
				tile.transform.localScale = new Vector2(tileScale, tileScale);

				tiles[x, y] = tile;
			}
		}

		activeX = gridWidth / 2;
		activeY = gridHeight / 2;

		camera.moveToPosition(tiles[activeX, activeY].transform.position);
		cursor.moveToTile(tiles[activeX, activeY]);
	}

	// Update is called once per frame
	void Update() {
		float valueX = Input.GetAxis("Horizontal");
		float valueY = Input.GetAxis("Vertical");

		GameObject currentActive = tiles[activeX, activeY];
		GameObject newActive = null;

		if (!inputReleased && valueX == 0 && valueY == 0) {
			inputReleased = true;

		}
		else if (inputReleased && valueX < 0 && activeX > 0) {
			inputReleased = false;
			activeX--;
			newActive = tiles[activeX, activeY];

		}
		else if (inputReleased && valueY < 0 && activeY > 0) {
			inputReleased = false;
			activeY--;
			newActive = tiles[activeX, activeY];

		}
		else if (inputReleased && valueX > 0 && activeX < gridWidth - 1) {
			inputReleased = false;
			activeX++;
			newActive = tiles[activeX, activeY];

		}
		else if (inputReleased && valueY > 0 && activeY < gridHeight - 1) {
			inputReleased = false;
			activeY++;
			newActive = tiles[activeX, activeY];
		}

		if (newActive && newActive != currentActive) {
			switchActiveTile(newActive, currentActive);
		}
	}

	private void switchActiveTile(GameObject newActive, GameObject oldActive) {
		if (oldActive) {
			oldActive.GetComponent<TileController>().switchToInactive();
		}

		if (newActive) {
			newActive.GetComponent<TileController>().switchToActive();

			camera.trackToPosition(newActive.transform.position);
			cursor.moveToTile(newActive);
		}
	}
}
