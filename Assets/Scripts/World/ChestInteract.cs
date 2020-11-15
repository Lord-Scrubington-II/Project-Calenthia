using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour, IInteract {

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	public Sprite closeSprite, openSprite;

	private bool isOpen = false;

	public new string name = "yellow_chest";

	//currently just changes the chest sprite from open to close
	public void Interact() {
		if (isOpen == false) {
			isOpen = true;
			spriteRenderer.sprite = openSprite;
			Debug.Log("opening chest!");
		}
		else
			StopInteract();
		/*
		if (isOpen) {
			StopInteract();
		}
		else {
			isOpen = true;
			spriteRenderer.sprite = openSprite;
		}
		*/
	}

	public void StopInteract() {
		Debug.Log("chest is already open");
	}

}
