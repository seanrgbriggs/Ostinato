using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public string gameSceneName;
	public string tutSceneName;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (Screen.currentResolution.height * 9 / 16, Screen.currentResolution.height, false); //creates a vertical game screen,
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startMenu(){
		SceneManager.LoadScene (0);
	}

	public void startGame(){
		SceneManager.LoadScene (1);
	}

	public void startTutorial(){
		SceneManager.LoadScene (2);
	}
}
