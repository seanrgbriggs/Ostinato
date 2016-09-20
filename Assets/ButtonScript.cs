using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

	bool rightAnswer;

	// Use this for initialization
	void Start ()
	{
		rightAnswer = false;
	}
	
	// Update is called once per frame
	public void onPress ()
	{
		ButtonHandlerScript parScript = GetComponentInParent<ButtonHandlerScript> ();
		parScript.Message (rightAnswer);
	}

	public void setText(string new_text){
		GetComponentInChildren<Text>().text = new_text;
	}

	public void setCorrect(bool correctness){
		rightAnswer = correctness;
		GetComponentInChildren<Text> ().color = (correctness) ? Color.green : Color.red;
	}

	public void Reset(){
		setText ("");
		setCorrect (false);
	}
}

