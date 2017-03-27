using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	public GameObject tilePrefab;

	private float tileScale = 0.1F;
	private float tileSpacing = 2.1F;

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++) {

				GameObject tile = Instantiate (tilePrefab);
				tile.transform.position = new Vector2 (tileSpacing * i, tileSpacing * j);
				tile.transform.localScale = new Vector2 (0.1F, 0.1F);
			}
		}

		GameObject[] tiles = GameObject.FindGameObjectsWithTag("LevelTile");
		Debug.Log ("tiles:" + tiles.Length);

		TileActiveStateManager state = tiles [0].GetComponent<TileActiveStateManager> ();
		state.switchToActive ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
