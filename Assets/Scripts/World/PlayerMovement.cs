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

		private void Start() {
            
		}

		// Update is called once per frame
		void Update() {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate() {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }
}