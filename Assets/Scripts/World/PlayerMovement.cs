﻿using System.Collections;
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
        private Vector2 moveInput;
        public Vector3 movePos;

        private Animator animator;
        
        private bool isMoving;

        //public Transform movePoint;
        public LayerMask stopMovement;

		private void Start() {
            //movePoint.parent = null;
            animator = GetComponent<Animator>();
		}

		// Update is called once per frame
		void Update() {

            if (!isMoving) {
                moveInput.x = Input.GetAxisRaw("Horizontal");
                moveInput.y = Input.GetAxisRaw("Vertical");

                //prevent diagonal movement
                if (moveInput.x != 0) moveInput.y = 0;

                //if any input given changed movePos, call function to move
                //player to that position
                if (moveInput != Vector2.zero) {

                    //grab float value for the animation direction
                    animator.SetFloat("MoveX", moveInput.x);
                    animator.SetFloat("MoveY", moveInput.y);

                    movePos = transform.position;
                    movePos.x += moveInput.x;
                    movePos.y += moveInput.y;
                    StartCoroutine(Move());
				}
            }

            animator.SetBool("isMoving", isMoving);
            /*
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
            */
        }

        private void FixedUpdate() {
            //MovePlayer();
            //rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }

        IEnumerator Move() {
            isMoving = true;
            //check player position vs movePosition, for player to move until
            //it reaches the position
            while((GetmovePos() - transform.position).sqrMagnitude > Mathf.Epsilon) {
                transform.position = Vector3.MoveTowards(transform.position,
                    movePos, moveSpeed * Time.deltaTime);

                yield return null;
			}
            transform.position = movePos;
            isMoving = false;
		}

        private Vector3 GetmovePos() {
            return movePos;
		}
    }
}