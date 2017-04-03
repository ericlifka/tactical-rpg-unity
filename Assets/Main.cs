using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject tilePrefab;

	public CameraController cameraController;
	public CursorController cursorController;

	public LevelLoader levelLoader;


	private float tileScale = 0.1F;
	private float tileSpacing = 2.1F;

	private GameObject[,] tiles;
//	private int gridWidth = 9;
//	private int gridHeight = 5;
//	private int activeX = 0;
//	private int activeY = 0;
	private Vector2 mapDimensions = new Vector2(9, 5);
	private Vector2 active;

	private bool inputReleased = true;

	void Start() {
		cursorController.setup(tileSpacing);

		tiles = new GameObject[(int)mapDimensions.x, (int)mapDimensions.y];

		for (int x = 0; x < mapDimensions.x; x++) {
			for (int y = 0; y < mapDimensions.y; y++) {

				GameObject tile = Instantiate(tilePrefab);
				tile.transform.position = new Vector2(tileSpacing * x, tileSpacing * y);
				tile.transform.localScale = new Vector2(tileScale, tileScale);

				tiles[x, y] = tile;
			}
		}

		active = new Vector2(mapDimensions.x / 2, mapDimensions.y / 2);

		cameraController.moveToPosition(getActiveTile().transform.position);
		cursorController.moveToTile(getActiveTile());
	}

	void Update() {
		checkInput();
	}

	void checkInput() {
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");

		if (!inputReleased) {
			if (xInput == 0 && yInput == 0) {
				inputReleased = true;
			}

			return;
		}

		Vector2 newActive = new Vector2(active.x, active.y);
		if (xInput < -0.5 && newActive.x > 0) {
			newActive.x--;
		}
		if (xInput > 0.5 && newActive.x < mapDimensions.x - 1) {
			newActive.x++;
		}
		if (yInput < -0.5 && newActive.y > 0) {
			newActive.y--;
		}
		if (yInput > 0.5 && newActive.y < mapDimensions.y - 1) {
			newActive.y++;
		}

		if (newActive.y != active.y || newActive.x != active.x) {
			active = newActive;

			GameObject tile = getActiveTile();
			cameraController.trackToPosition(tile.transform.position);
			cursorController.moveToTile(tile);
		}
	}

	private GameObject getActiveTile() {
		return tiles[(int) active.x, (int) active.y];
	}

//	// Update is called once per frame
//	void Update2() {
//		float valueX = Input.GetAxis("Horizontal");
//		float valueY = Input.GetAxis("Vertical");
//
//		GameObject currentActive = tiles[activeX, activeY];
//		GameObject newActive = null;
//
//		if (!inputReleased && valueX == 0 && valueY == 0) {
//			inputReleased = true;
//
//		}
//		else if (inputReleased && valueX < 0 && activeX > 0) {
//			inputReleased = false;
//			activeX--;
//			newActive = tiles[activeX, activeY];
//
//		}
//		else if (inputReleased && valueY < 0 && activeY > 0) {
//			inputReleased = false;
//			activeY--;
//			newActive = tiles[activeX, activeY];
//
//		}
//		else if (inputReleased && valueX > 0 && activeX < gridWidth - 1) {
//			inputReleased = false;
//			activeX++;
//			newActive = tiles[activeX, activeY];
//
//		}
//		else if (inputReleased && valueY > 0 && activeY < gridHeight - 1) {
//			inputReleased = false;
//			activeY++;
//			newActive = tiles[activeX, activeY];
//		}
//
//		if (newActive && newActive != currentActive) {
//			switchActiveTile(newActive, currentActive);
//		}
//	}
//
//	private void switchActiveTile(GameObject newActive, GameObject oldActive) {
//		if (oldActive) {
//			oldActive.GetComponent<TileController>().switchToInactive();
//		}
//
//		if (newActive) {
//			newActive.GetComponent<TileController>().switchToActive();
//
//			camera.trackToPosition(newActive.transform.position);
//			cursor.moveToTile(newActive);
//		}
//	}
}
