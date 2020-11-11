using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this script is for the camrea to follow the player
 * component of maincamera
 */
namespace world {
    public class CameraFollow : MonoBehaviour {

        //player's position
        private Transform playerTransform;

		private void Start() {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		}

		//making the camera's position the same as the player's
		private void LateUpdate() {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x;
            temp.y = playerTransform.position.y;
            temp.z = playerTransform.position.z - 6;
            transform.position = temp;
        }
    }
}
