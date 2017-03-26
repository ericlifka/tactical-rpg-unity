using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	public GameObject tilePrefab;

	// Use this for initialization
	void Start () {
		
//		GameObject tile = Instantiate (tilePrefab);
//		tile.transform.position = new Vector2 (0, 0);
//		tile.transform.localScale = new Vector2 (0.05F, 0.05F);
//
//		GameObject tile2 = Instantiate (tilePrefab);
//		tile2.transform.position = new Vector2 (1, 1);
//		tile2.transform.localScale = new Vector2 (0.05F, 0.05F);

		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 3; j++) {

				GameObject tile = Instantiate (tilePrefab);
				tile.transform.position = new Vector2 (i, j);
				tile.transform.localScale = new Vector2 (0.05F, 0.05F);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
