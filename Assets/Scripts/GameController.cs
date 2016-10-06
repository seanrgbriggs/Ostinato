using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

	public ButtonHandlerScript bhs;
	public ReticleScript ret;
	public Text scoreText;
	public Text notesRemText;
	public AudioClip clip;

	public int score;
	private Note[] notes;
	private Note curNote;
	private int noteIndex;

	private int difficulty;

	public int stepRange; //The starting guessing difficulty
	private int curStepRange; //The current guessing difficulty

	private float timeToReset = 1.0f;
	private float curTime; //The progress of resetting
	bool waitingToReset;

	private int num_notes = 100;

	public Button replayButton;

	// Use this for initialization
	void Start ()
	{
		curTime = 0;
		waitingToReset = true;

		score = 0;
		scoreText.alignment = TextAnchor.MiddleCenter;
		scoreText.gameObject.SetActive (false);

		curStepRange = stepRange;
		replayButton.gameObject.SetActive (false);
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


		difficulty = (int) Mathf.Floor(Mathf.Log(score / 1000) / Mathf.Log(2));
		difficulty = 1 + Mathf.Max (-1, difficulty);
		Debug.Log (difficulty);
		if (difficulty > 0) {
			curStepRange = stepRange - difficulty;
		}
		curStepRange = Mathf.Clamp (curStepRange, 1, stepRange); //Zero step would be bad, and so would a huge step.
	}

	void PlayNote(){
		num_notes--;
		if (num_notes < 0) {
			Destroy (ret.gameObject);
			Destroy (bhs.gameObject);
			scoreText.text = "Final Score: \n" + scoreText.text;
			Destroy (GetComponent<AudioSource> ());
			replayButton.gameObject.SetActive (true);
			Destroy (this);
			return;
		}

		if (difficulty < 1) {
			notes = new Note[4];

			int[] naturals = { 0, 2, 4, 5, 7, 9, 11, 12 };
			for (int i = 0; i < notes.Length; i++) {
				int addition = ((int)(2 * Random.value));
 				notes [i] = new Note(0, naturals [2 * i + addition]);
			}
		} else {
			notes = Note.getRandNoteArr (0, bhs.numButtons (), curStepRange);
		}
		if (difficulty < 2) {
			for (int i = 0; i < notes.Length; i++) {
				if (notes [i].ToString ().Contains ("#")) {
					notes [i] = new Note (notes [i].getOctave (), notes [i].getNote () + 1);
				}
			}
		}		

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
		notesRemText.text = "Notes Remaining:\n" + num_notes + " / 100";

		scoreText.gameObject.SetActive (true);
		int delScore = (correct) ? 200 : -100;
		score += delScore;

		scoreText.color = (correct) ? Color.green : Color.red;

		ret.Pause ();
		curTime = 0;
	}

	public int getDifficulty(){
		return difficulty;
	}
}

