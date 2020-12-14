using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * player component
 * lets player move around the world using WASD or arrow keys
 */
namespace world {
    public class PlayerMovement : MonoBehaviour {

        public float moveSpeed = 5f;
        public Rigidbody2D rb;
        Vector2 move;

        public Transform movePoint;
        public LayerMask stopMovement;

		private void Start() {
            movePoint.parent = null;
		}

		// Update is called once per frame
		void Update() {
            //move.x = Input.GetAxisRaw("Horizontal");
            //move.y = Input.GetAxisRaw("Vertical");

            transform.position = Vector3.MoveTowards(transform.position,
                movePoint.position,
                moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .1f) {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                    if (!Physics2D.OverlapCircle(movePoint.position +
                        new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, stopMovement)) { 
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }

                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                    if (!Physics2D.OverlapCircle(movePoint.position +
                        new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, stopMovement)) {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
        }

        private void FixedUpdate() {
            //rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
}