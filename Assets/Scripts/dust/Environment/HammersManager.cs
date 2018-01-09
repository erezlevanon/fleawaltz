using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SmfLite;

namespace Dust
{
	public class HammersManager : MonoBehaviour
	{
		[Header ("Song")]
		public TextAsset sourceMidiFile;

		public List<Hammer> hammers;

		private Dictionary<Hammer.NOTE, Hammer> hammersDict_;

		MidiFileContainer song;
		MidiTrackSequencer sequencer;

		void ResetAndPlay ()
		{
			//audio.Play ();
			sequencer = new MidiTrackSequencer (song.tracks [1], song.division, 131.0f);
			ApplyMessages (sequencer.Start ());
		}

		// Use this for initialization
		IEnumerator Start ()
		{
			hammersDict_ = new Dictionary<Hammer.NOTE, Hammer> ();
			foreach (Hammer hammer in hammers) {
				hammersDict_ [hammer.getNote ()] = hammer;
			}
			song = MidiFileLoader.Load (sourceMidiFile.bytes);
			yield return new WaitForSeconds (1.0f);
			ResetAndPlay ();
		}

		void Update ()
		{
			if (sequencer != null && sequencer.Playing) {
				ApplyMessages (sequencer.Advance (Time.deltaTime));
			}
		}

		void ApplyMessages (List<MidiEvent> messages)
		{
			if (messages != null) {
				foreach (var m in messages) {
					Debug.Log ("msg:");
					Debug.Log (m.status);
					if ((m.status & 0xf0) == 0x90) {
						Debug.Log (m.data1);
					}
				}
			}
		}
	}
}