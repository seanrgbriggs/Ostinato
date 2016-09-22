using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public string gameSceneName;
	public string tutSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void startGame(){
		SceneManager.LoadScene (1);
	}

	public void startTutorial(){
		SceneManager.LoadScene (2);

	}
}
