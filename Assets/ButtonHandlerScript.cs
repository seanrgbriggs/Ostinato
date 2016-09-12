using UnityEngine;
using System.Collections;

public class ButtonHandlerScript : MonoBehaviour {

	ButtonScript[] buttons;

	// Use this for initialization
	void Start () {
		buttons = GetComponentsInChildren<ButtonScript> ();
		for (int i = 0; i < buttons.Length; i++) {
			char to_set = 'C';
			buttons [i].setText (to_set.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
