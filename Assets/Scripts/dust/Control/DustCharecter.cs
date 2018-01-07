﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust {
	
public class DustCharecter : MonoBehaviour {

	public DustController controller;

		private Rigidbody2D body;
		private bool isJumping;
		private long  isPushing;

		[Header("Movement")]
		public float verticalMultiplier;
		public float horizontalMultiplier;

	// Use this for initialization
	void Start () {
			body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			Vector2 velocity = body.velocity;
			Action action = controller.getAction ();
			if (action == Action.JUMP && !isJumping) {
				velocity.y = verticalMultiplier;
				isJumping = true;
				Debug.Log ("JUMP");
			} else if (action == Action.RIGHT) {
				velocity.x = horizontalMultiplier;
			} else if (action == Action.LEFT) {
				velocity.x = -horizontalMultiplier;
			} else if (action == Action.STAY) {
				velocity.x = 0;
			}
			body.velocity = velocity;
	}

		void OnCollisionEnter2d(Collider2D coll) {
			Debug.Log ("COL!");
			Debug.Log(coll.gameObject.tag);
			if (isJumping && coll.gameObject.tag == "Ground") {
				isJumping = false;
			}
		}
}
}