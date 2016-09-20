using UnityEngine;

public class Note 
{
	private int octave;
	private int note;

	private string[] noteStrs = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

	public Note(int o, int n){
		octave = o;
		note = n;
		while (note < 0) {
			octave--;
			note += 12;
		}
		while (note > 11) {
			octave++;
			note -= 12;
		}
		Debug.Log ("Note: " + note + " " + n);
	}

	public void Play(AudioSource speaker){
		speaker.pitch = 1 + 1.2f * octave + 0.1f * note;
		Debug.Log (speaker.pitch);
		speaker.Play ();
	}

	public string ToString(){
		return noteStrs [note];
	}


	private static Note getRandNote(int desOctave){
		return new Note(desOctave, Random.Range(0,11)); //there are 12 distinct notes in an octave
	}

	public static Note[] getRandNoteArr(int desOctave, int len, int range){
		Note center = getRandNote (desOctave);
		Note[] output = new Note[len];
		
		for (int i = 0; i < len; i++) {
			output[i] = new Note(desOctave, center.note + Random.Range(-range, range));
		}

		return output;
	}


}

