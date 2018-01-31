﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust {
	
public class DustCharecter : MonoBehaviour {

	public DustController controller;

		private Rigidbody2D body;
		private bool isJumping;
		private long  isPushing;
		private int facing;

		[Header("Movement")]
		public float verticalMultiplier;
		public float horizontalMultiplier;
		public float turboMul;
		public float turboCooldown;

		private float lastTurbo;

		private bool alive;


		private Animator animator;

	// Use this for initialization
	void Start () {
			body = GetComponent<Rigidbody2D> ();
			animator = GetComponent<Animator> ();
			lastTurbo = Time.time;
			facing = 1;
			alive = true;

	}
			
	// Update is called once per frame
	void FixedUpdate () {
			if (!alive)
				return;
			Vector2 velocity = body.velocity;
			Vector2 scale = body.transform.localScale;
			Action action = controller.getAction ();
			if (action == Action.JUMP && this.transform.localPosition.y < -1f) {
				velocity.y = verticalMultiplier;
			} else if (action == Action.RIGHT) {
				facing = 1;
				velocity.x = horizontalMultiplier;
			} else if (action == Action.LEFT) {
				velocity.x = -horizontalMultiplier;
				facing = -1;
			} else if (action == Action.PUSH && Time.time - lastTurbo > turboCooldown) {
				velocity.x = facing * turboMul;
				lastTurbo = Time.time;
				animator.SetTrigger ("Turbo");
			} else if (action == Action.STAY) {
				velocity.x = velocity.x;
			}
			body.velocity = velocity;
			scale.x = Mathf.Abs(scale.x) * facing;
			body.transform.localScale = scale;
	}

		void OnCollisionEnter2D (Collision2D col) {
			if (col.gameObject.tag == "hammer") {
				body.velocity = new Vector2 (0f, 0f);
				body.gravityScale = 0.7f;
				GetComponent<Collider2D> ().enabled = false;
				GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,0.3f);
				animator.SetTrigger ("Hit");
				alive = false;

			};
		}
}
}