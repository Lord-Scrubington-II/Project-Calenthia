using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using world;

namespace world {
    public class Transition : MonoBehaviour {
        public Vector2 minChange;
        public Vector2 maxChange;
        public Vector3 playerChange;
        private CameraFollow camFollow;

        private PlayerMovement playerMovement;

        // Start is called before the first frame update
        void Start() {
            camFollow = Camera.main.GetComponent<CameraFollow>();
            //playerA = GetComponent<PlayerMovement>();
            //movePoint = GameObject.FindGameObjectWithTag("movePoint").transform;
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnTriggerEnter2D(Collider2D collision) {

            if (collision.CompareTag("Player")) {
                playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

                if (playerMovement.roomTransfer==true)
                    RoomTransfer(collision);

                if (playerMovement.enterDungeon)
                    EnterDungeon(collision);

            }
        }

        private void RoomTransfer(Collider2D collision) {
            camFollow.minPos = minChange;
            camFollow.maxPos = maxChange;
            collision.transform.position += playerChange;
            //playerA.movePos.x = collision.transform.position.x;
            //playerA.movePos.y = collision.transform.position.y;
            //movePoint.position = collision.transform.position;

            //gets the playermovement script on the player to update the
            //movePos when transitioning area


            //Debug.Log("X: " + playerMovement.movePos.x + ", Y: " + playerMovement.movePos.y);

            Debug.Log("x is: " + NearestX(collision.transform.position.x,collision));
            Debug.Log("y is: " + NearestY(collision.transform.position.y, collision));

            collision.transform.position = new Vector2(NearestX(collision.transform.position.x, collision),
                NearestY(collision.transform.position.y, collision));

            playerMovement.movePos.x = collision.transform.position.x;
            playerMovement.movePos.y = collision.transform.position.y;

            playerMovement.roomTransfer = false;
        }

        private void EnterDungeon(Collider2D collision) {
            playerMovement.enterDungeon = false;
		}

        public float NearestX(float a, Collider2D collision) {
            
            float temp = Mathf.Round(a);
            if (temp < a)
                temp += 0.5f;
            else
                temp -= 0.5f;

            return temp;
        }

        public float NearestY(float a, Collider2D collision) {
            return Mathf.Round(a) - 0.2f;
        }
    }
}