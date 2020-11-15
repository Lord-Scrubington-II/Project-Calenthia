using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentObj;
    private ChestInteract chestInteract;
    private NPCInteract npcInteract;

    //assign currentObj to the object with collide with
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Interactable")) {
            Debug.Log("player touching interactable object");
            currentObj = collision.gameObject;
        }
    }

    //set currentObj to null once outside of collision
	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.CompareTag("Interactable")) {
            if (collision.gameObject == currentObj)
                currentObj = null;
		}
	}

	// Press E to interact
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
		}
    }

    void Interact() {
        if (currentObj != null) {
            Debug.Log("interacting with " + currentObj);
            Debug.Log("the name is " + currentObj.name);
            chestInteract = currentObj.GetComponent<ChestInteract>();
            npcInteract = currentObj.GetComponent<NPCInteract>();

            if(chestInteract!=null)
                chestInteract.Interact();

            if (npcInteract != null)
                npcInteract.Interact();
        }
	}
}
