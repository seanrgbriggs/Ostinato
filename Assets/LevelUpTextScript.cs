using UnityEngine;
using System.Collections;

public class LevelUpTextScript : MonoBehaviour {

	Vector2 pos;
	Vector2 scale;

	CanvasRenderer canren;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		scale = transform.localScale;
		canren = GetComponent<CanvasRenderer> ();
		canren.SetAlpha (0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, 3);
		transform.localScale *= 0.99f;
		canren.SetAlpha (canren.GetAlpha () * 0.7f);
	}

	public void refresh(){
		transform.position = pos;
		transform.localScale = scale;
		canren.SetAlpha (255);

	}
}
