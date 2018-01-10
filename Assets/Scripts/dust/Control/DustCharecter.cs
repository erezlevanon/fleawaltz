using System.Collections;
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
			if (action == Action.JUMP && this.transform.localPosition.y < -1f) {
				velocity.y = verticalMultiplier;
			} else if (action == Action.RIGHT) {
				velocity.x = horizontalMultiplier;
			} else if (action == Action.LEFT) {
				velocity.x = -horizontalMultiplier;
			} else if (action == Action.STAY) {
				velocity.x = 0;
			}
			body.velocity = velocity;
	}

		void OnCollisionEnter2D (Collision2D col) {
			if (col.gameObject.name == "collider") {
				var vel = this.body.velocity;
				vel.y = 50f;
				vel.x = Random.Range(-5f,  5f);
				this.body.velocity = vel;
			};
		}
}
}