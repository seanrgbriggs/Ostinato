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
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].setText (notes [i].ToString ());
			buttons [i].setCorrect (false);
		}

		int rightAnswer = Random.Range (0, buttons.Length);
		buttons [rightAnswer].setCorrect (true);

	}

	public int numButtons(){
		return buttons.Length;
	}
	
	public void Reset () {

		AssignNotes ();

	}

	public void Message(bool correct){

			for(int i= 0; i < buttons.Length; i++){
				buttons [i].Reset ();
			}
			gm.Answer (correct);
	
	}
}