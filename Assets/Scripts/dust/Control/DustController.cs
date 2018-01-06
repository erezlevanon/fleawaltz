using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust
{
	
	public enum Action
	{
		RIGHT,
		LEFT,
		JUMP,
		PUSH,
		STAY,
	}

	public abstract class DustContoller : MonoBehaviour
	{
		/// <summary>
		/// Get the Action to preform at this time.
		/// </summary>
		/// <returns>The action.</returns>
		public abstract Action getAction ();
		
	}
}