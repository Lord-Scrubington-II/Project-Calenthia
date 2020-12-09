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

        // Start is called before the first frame update
        void Start() {
            camFollow = Camera.main.GetComponent<CameraFollow>();
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
				camFollow.minPos = minChange;
                camFollow.maxPos = maxChange;
                collision.transform.position += playerChange;
            }
        }
    }
}