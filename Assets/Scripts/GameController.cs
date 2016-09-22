using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

	public ButtonHandlerScript bhs;
	public ReticleScript ret;
	public Text scoreText;
	public AudioClip clip;

	public int score;
	private Note[] notes;
	private Note curNote;
	private int noteIndex;

	public int stepRange; //The starting guessing difficulty
	private int curStepRange; //The current guessing difficulty

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
		scoreText.gameObject.SetActive (false);

		curStepRange = stepRange;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//Managing the waiting and reset time, with the related aesthetics
		if (curTime < timeToReset) {
			waitingToReset = true;
			curTime += Time.deltaTime;

			ret.SetTransparency (1 - curTime);
			GetComponent<AudioSource> ().volume = 1 - curTime;
		} else if (waitingToReset) {
			waitingToReset = false;
			PlayNote (); //Plays the note

			ret.SetTransparency (1);
			GetComponent<AudioSource> ().volume = 1;
		}
	

		//Funny emoticon, also preventing negative score
		if (score <= 0) {
			score = 0;
			scoreText.text = ":(";
		} else {
			scoreText.text = score.ToString ();
		}


		int difficulty = (int) Mathf.Floor(Mathf.Log(score / 1000) / Mathf.Log(2));
		Debug.Log (difficulty);
		if (difficulty > 0) {
			curStepRange = stepRange - difficulty;
		}
		curStepRange = Mathf.Clamp (curStepRange, 1, stepRange); //Zero step would be bad, and so would a huge step.
	}

	void PlayNote(){

		notes = Note.getRandNoteArr (0, bhs.numButtons (), curStepRange);
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
		scoreText.gameObject.SetActive (true);
		int delScore = (correct) ? 200 : -100;
		score += delScore;

		ret.Pause ();
		curTime = 0;
	}
}

