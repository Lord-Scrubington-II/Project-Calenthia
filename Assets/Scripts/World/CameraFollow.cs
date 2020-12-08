﻿using System.Collections;
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

        public Vector2 minPos;
        public Vector2 maxPos;

		private void Start() {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            xOff = 0;
            yOff = 0;
            zOff = -6; //"zoom distance away"
		}

		//making the camera's position the same as the player's
		private void LateUpdate() {
            if (transform.position != playerTransform.position) {

                Vector3 temp = transform.position;
                temp.x = playerTransform.position.x + xOff;
                temp.y = playerTransform.position.y + yOff;
                temp.z = playerTransform.position.z + zOff;

                //bounding the coordinates
                temp.x = Mathf.Clamp(temp.x, minPos.x, maxPos.x);
                temp.y = Mathf.Clamp(temp.y, minPos.y, maxPos.y);

                transform.position = temp;
            }
        }
    }
}
