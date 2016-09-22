using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

	public ButtonHandlerScript bhs;
	public ReticleScript ret;
	public Text scoreText;
	public AudioClip clip;

	private int score;
	private Note[] notes;
	private Note curNote;
	private int noteIndex;

	public int stepRange; //The guessing difficulty

	private float timeToReset = 1.0f;
	private float curTime; //The progress of resetting
	bool waitingToReset;

	// Use this for initialization
	void Start ()
	{
		curTime = 0;
		waitingToReset = true;

		score = 0;
		scoreText.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (curTime < timeToReset) {
			waitingToReset = true;
			curTime += Time.deltaTime;

			ret.SetTransparency (1 - curTime);
			GetComponent<AudioSource> ().volume = 1 - curTime;
		} else if (waitingToReset) {
			waitingToReset = false;
			PlayNote ();

			ret.SetTransparency (1);
			GetComponent<AudioSource> ().volume = 1;
		}
	
		scoreText.text = score.ToString();

	}

	void PlayNote(){

		notes = Note.getRandNoteArr (0, bhs.numButtons (), stepRange);
		noteIndex = Random.Range (0, bhs.numButtons ());
		curNote = notes [noteIndex];

		curNote.Play (GetComponent<AudioSource>());
		ret.Reset ();
		bhs.Reset ();
	}

	public Note getNote(){
		return curNote;
	}

	public Note[] getNoteArr(){
		return notes;
	}

	public int getNoteIndex(){
		return noteIndex;
	}

	public void Answer(bool correct){
		int delScore = (correct) ? 200 : -100;
		score += delScore;

		ret.Pause ();
		curTime = 0;
	}
}

