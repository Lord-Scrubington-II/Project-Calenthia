using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this script is for the camrea to follow the player
 * component of maincamera
 */
namespace world {
    public class CameraFollow : MonoBehaviour {
        private float xOff, yOff, zOff;


        //player's position
        private Transform playerTransform;

		private void Start() {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            xOff = 0;
            yOff = 0;
            zOff = -6;
		}

		//making the camera's position the same as the player's
		private void LateUpdate() {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x + xOff;
            temp.y = playerTransform.position.y + yOff ;
            temp.z = playerTransform.position.z + zOff;
            transform.position = temp;
        }
    }
}
