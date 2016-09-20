using UnityEngine;
using System.Collections;

public class ReticleScript : MonoBehaviour {

	public float curSize;
	public float maxSize;

	public float targetSize;

	public float collapseTime;
	public float curCollapse;

	public GameController gm;

	bool working;

	// Use this for initialization
	void Start () {
		maxSize = 3;
		curSize = 0;
		curCollapse = 0;
		working = true;
	}
	
	// Update is called once per frame
	void Update () {
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
}
