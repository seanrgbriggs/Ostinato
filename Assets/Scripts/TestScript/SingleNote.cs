using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SingleNote : MonoBehaviour {

	private AudioSource aso;

	Note n = new Note(0, 0);
	Note[] scale;
	int ptr;

	float curTime;

	public Text text;

	// Use this for initialization
	void Start () {
		aso = GetComponent<AudioSource> ();

		int[] noteInts = { 0, 2, 4, 5, 7, 9, 11, 12, 12, 11, 9, 7, 5, 4, 2, 0 };
		scale = new Note[noteInts.Length];

		for (int i = 0; i < scale.Length; i++) {
			scale [i] = new Note (0, noteInts [i]);
		}

		ptr = noteInts.Length + 1;
	}

	public void PlayScale(){
		if(ptr >= scale.Length)
			ptr = 0;
	}

	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		if (curTime > 0.5) {
			curTime = 0;
			Step ();
		}
	}

	// Step is called once per second
	void Step(){
		//n = new Note (n.getOctave (), n.getNote () + 1);
		if (ptr >= scale.Length) {
			aso.Stop ();
			text.text = "Play a Scale?";
			return;
		}

		text.text = scale [ptr].ToString();
		n = scale[ptr];
		n.Play (aso);

		ptr++;
	}
		
}
