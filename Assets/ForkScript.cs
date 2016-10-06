using UnityEngine;
using System.Collections;

public class ForkScript : MonoBehaviour {

	public Sprite[] sprites;
	public GameController controller;
	public LevelUpTextScript luts;

	private int diff;
	// Use this for initialization
	void Start () {
		diff = int.MinValue;
		if (controller.getDifficulty () > diff) {
			diff = controller.getDifficulty ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.getDifficulty () > diff) {
			diff = controller.getDifficulty ();
			luts.refresh ();
		}
		SpriteRenderer rend = GetComponent<SpriteRenderer> ();
		rend.sprite = sprites [Mathf.Clamp (diff, 0, sprites.Length - 1)];
	}
}
