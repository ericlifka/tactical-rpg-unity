using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {
	public Sprite inactiveSprite;
	public Sprite activeSprite;

	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = inactiveSprite;
	}

	void Update() {

	}

	public void switchToActive() {
		spriteRenderer.sprite = activeSprite;
	}

	public void switchToInactive() {
		spriteRenderer.sprite = inactiveSprite;
	}
}
