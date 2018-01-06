using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust
{

	public class KeyBoardController : DustController
	{

		public KeyCode rightKey;
		public KeyCode leftKey;
		public KeyCode jumpKey;
		public KeyCode pushKey;
	
		public override Action getAction ()
		{

			if (Input.GetKey (jumpKey)) {
				return Action.JUMP;
			} else if (Input.GetKey (pushKey)) {
				return Action.PUSH;
			} else if (Input.GetKey (rightKey)) {
				return Action.RIGHT;
			} else if (Input.GetKey (leftKey)) {
				return Action.LEFT;
			} else {
				return Action.STAY;
			}
		}
	}
}