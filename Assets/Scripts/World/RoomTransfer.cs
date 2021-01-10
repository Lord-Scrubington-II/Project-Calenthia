using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using world;

namespace world {
    public class RoomTransfer : MonoBehaviour {
        public Vector2 minChange;
        public Vector2 maxChange;
        public Vector3 playerChange;
        private CameraFollow camFollow;
        //private Transform movePoint;
        private PlayerMovement p;

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
				camFollow.minPos = minChange;
                camFollow.maxPos = maxChange;
                collision.transform.position += playerChange;
                //playerA.movePos.x = collision.transform.position.x;
                //playerA.movePos.y = collision.transform.position.y;
                //movePoint.position = collision.transform.position;

                //gets the playermovement script on the player to update the
                //movePos when transitioning area
                p = collision.gameObject.GetComponent<PlayerMovement>();

                Debug.Log("X: " + p.movePos.x +", Y: " + p.movePos.y );

                p.movePos.x = collision.transform.position.x;
                p.movePos.y = collision.transform.position.y;
            }
        }
    }
}