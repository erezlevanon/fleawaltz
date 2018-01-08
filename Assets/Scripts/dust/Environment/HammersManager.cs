using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dust
{
	public class HammersManager : MonoBehaviour
	{

		public List<Hammer> hammers;

		private Dictionary<Hammer.NOTE, Hammer> hammersDict_;

	// Use this for initialization
	void Start ()
		{
			hammersDict_ = new Dictionary<Hammer.NOTE, Hammer>();
			foreach (Hammer hammer in hammers) {
				hammersDict_ [hammer.getNote ()] = hammer;
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}