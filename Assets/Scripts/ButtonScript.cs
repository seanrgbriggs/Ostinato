using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour
{

	bool rightAnswer;
	float timeSinceStart;
	CanvasRenderer cr;

	// Use this for initialization
	void Start ()
	{
		timeSinceStart = 0.0f;
		cr = GetComponent<CanvasRenderer> ();
		cr.SetAlpha (0);
		rightAnswer = false;
		GetComponentInChildren<Text> ().text = "";
	}

	void Update(){
		if (timeSinceStart < 1.0f) {
			timeSinceStart += Time.deltaTime;
		} else {
			cr.SetAlpha (1);
		}
	}

	// Update is called once per frame
	public void onPress ()
	{
		if (GetComponentInChildren<Text> ().color != Color.black)
			return;
		ButtonHandlerScript parScript = GetComponentInParent<ButtonHandlerScript> ();
		parScript.Message (rightAnswer);
	}

	public void setText(string new_text){
		GetComponentInChildren<Text>().text = new_text;
	}

	public void setCorrect(bool correctness){
		rightAnswer = correctness;
	}

	public void reveal(){
		GetComponentInChildren<Text> ().color = (rightAnswer) ? Color.green : Color.red;
	}

	public void Reset(){
		GetComponentInChildren<Text> ().color = Color.black;
		setText ("");
		setCorrect (false);
	}
}

