using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour, IInteractObject {

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	public Sprite openSprite, closeSprite;

	private bool isOpen;

	public void Interact() {
		if (isOpen) {
			StopInteract();
		}
		else {
			isOpen = true;
			spriteRenderer.sprite = openSprite;
		}
	}

	public void StopInteract() {
		
	}

}
