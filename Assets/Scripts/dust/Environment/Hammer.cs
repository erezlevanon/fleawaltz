using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust
{
	public class Hammer : MonoBehaviour
	{

		public enum NOTE {
			A,
			B,
			C,
			D,
			E,
		}

		public NOTE note;



		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

		public NOTE getNote() {
			return note;
		}
	}
}