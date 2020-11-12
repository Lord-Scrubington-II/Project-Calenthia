using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject currentObj;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Interactable")) {
            Debug.Log("player touching interactable object");
            currentObj = collision.gameObject;
        }
    }

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.CompareTag("Interactable")) {
            if (collision.gameObject == currentObj)
                currentObj = null;
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.E)) {
            if (currentObj != null)
                Debug.Log("interacting with " + currentObj);
		}
    }
}
