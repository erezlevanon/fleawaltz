using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

namespace Dust
{
	public class HammersManager : MonoBehaviour
	{
		[Header("Song")]
		public TextAsset sourceMidiFile;

		public List<Hammer> hammers;

		private Dictionary<Hammer.NOTE, Hammer> hammersDict_;

		MidiFileContainer song;
		MidiTrackSequencer sequencer;

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