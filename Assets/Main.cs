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
	private Coord mapDimensions = new Coord(9, 5);
	private Coord active;

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

		active = new Coord(mapDimensions.x / 2, mapDimensions.y / 2);

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

		Coord newActive = new Coord(active.x, active.y);
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
			inputReleased = false;
			active = newActive;

			GameObject tile = getActiveTile();
			cameraController.trackToPosition(tile.transform.position);
			cursorController.moveToTile(tile);
		}
	}

	private GameObject getActiveTile() {
		return tiles[active.x, active.y];
	}
}
