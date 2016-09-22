using UnityEngine;

public class Note 
{
	const float noteInterval = 1.05946f;
	const int noteOfDefaultSound = 4;
		
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
	}

	public void Play(AudioSource speaker){
		speaker.pitch = 1;
		speaker.pitch *= Mathf.Pow(noteInterval, 12*octave + note - 12 - noteOfDefaultSound);
		speaker.Play ();
	}

	public int getOctave(){
		return octave;
	}

	public int getNote(){
		return note;
	}


	override public string ToString(){
		string toReturn = noteStrs [note];
		if (octave < 0) {
			toReturn += " " + octave;
		} else if (octave > 0) {
			toReturn += " +" + octave;
		}

		return toReturn;
	}



	public static bool operator ==(Note n1, Note n2){
		return (n1.octave == n2.octave && n1.note == n2.note);
	}

	public static bool operator !=(Note n1, Note n2){
		return !(n1 == n2);
	}

	private static Note getRandNote(int desOctave){
		return new Note(desOctave, Random.Range(0,11)); //there are 12 distinct notes in an octave
	}

	public static Note[] getRandNoteArr(int desOctave, int len, int range){
		Note center = getRandNote (desOctave);
		Note[] output = new Note[len];

		int centerpoint = Random.Range (0, len - 1);
		output [centerpoint] = center;

		for (int i = centerpoint - 1; i >= 0; i--) {
			output [i] = new Note (output [i + 1].getOctave (), output [i + 1].getNote () - range);
		}

		for (int i = centerpoint + 1; i < len; i++) {
			output [i] = new Note (output [i - 1].getOctave (), output [i - 1].getNote () + range);
		}
		/*
		for (int i = 0; i < len; i++) {
			
			Note toAdd = null;
			bool uniqueNote = false;

			while (!uniqueNote) {
				toAdd = new Note (desOctave, center.note + Random.Range (-range, range));
				uniqueNote = true;
				for (int j = 0; j < i; j++) {
					if (toAdd == output [j])
						uniqueNote = false;
				}
			}

			output [i] = toAdd;
		}*/

		return output;
	}
		


}

