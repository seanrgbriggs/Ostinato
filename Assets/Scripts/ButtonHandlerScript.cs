using UnityEngine;
using System.Collections;

public class ButtonHandlerScript : MonoBehaviour {

	public GameController gm;
	public ReticleScript ret;

	ButtonScript[] buttons;

	// Use this for initialization
	void Start () {
		buttons = GetComponentsInChildren<ButtonScript> ();
		Reset ();
	}

	void AssignNotes(){

		Note[] notes = gm.getNoteArr ();
		int rightAnswer;

		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].Reset ();
			buttons [i].setText (notes [i].ToString ());
			if (notes [i] == gm.getNote ()) {
				rightAnswer = i;
				buttons [i].setCorrect (true);
			} else {
				buttons [i].setCorrect (false);
			}
		}

	}

	public int numButtons(){
		return buttons.Length;
	}
	
	public void Reset () {

		AssignNotes ();

	}

	public void Message(bool correct){

			for(int i= 0; i < buttons.Length; i++){
				buttons [i].reveal ();
			}
			gm.Answer (correct);
	
	}
}