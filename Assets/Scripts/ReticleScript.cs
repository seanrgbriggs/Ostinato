using UnityEngine;
using System.Collections;

public class ReticleScript : MonoBehaviour {

	public float curSize;
	public float maxSize;

	public float targetSize;

	public float collapseTime;
	public float curCollapse;

	public GameController gm;

	float timeTillStart;

	bool working;

	// Use this for initialization
	void Start () {
		maxSize = 3;
		curSize = 0;
		curCollapse = 0;
		working = true;

		timeTillStart = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeTillStart < 1.0f) {
			timeTillStart += Time.deltaTime;
			return;
		}
		if (working) {

			if (curCollapse < collapseTime) {
				curCollapse += Time.deltaTime;
			} else {
				Debug.Log ("Reticule collapse");
				SignalLoss ();
				working = false;
			}
		}

		curSize = targetSize + (maxSize-targetSize) * (1 - (curCollapse / collapseTime));

		transform.localScale= new Vector3(curSize, curSize, 1);

	}

	public void Pause(){
		working = false;
	}

	public void Reset(){
		curCollapse = 0;
		working = true;
	}

	void SignalLoss(){
		gm.Answer (false); //Out of time
	}

	public void SetTransparency(float alpha){
		GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, alpha);
	}
}
