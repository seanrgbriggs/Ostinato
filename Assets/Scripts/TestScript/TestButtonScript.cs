using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestButtonScript : MonoBehaviour {

	Note n;
	Text text;

	// Use this for initialization
	void Start () {
		n = new Note (1, 0);
		text = GetComponentInChildren<Text> ();
		text.text = n.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(){
		n.Play (GetComponent<AudioSource>());
	}

	public void increment(){
		n = new Note (n.getOctave(), n.getNote() + 1);
		text.text = n.ToString ();
		Play ();
	}
	public void decrement(){
		n = new Note (n.getOctave(), n.getNote() - 1);
		text.text = n.ToString();
		Play ();
	}
}
