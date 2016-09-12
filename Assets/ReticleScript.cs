using UnityEngine;
using System.Collections;

public class ReticleScript : MonoBehaviour {

	public float curSize;
	public float maxSize;

	public float targetSize;

	public float collapseTime;
	public float curCollapse;

	bool working;

	// Use this for initialization
	void Start () {
		maxSize = 3;
		curSize = 3;
		curCollapse = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (curCollapse < collapseTime) {
			curCollapse += Time.deltaTime;
		} else if (working) {
			SignalLoss ();
			working = false;
		}
		curSize = targetSize + (maxSize-targetSize) * (1 - (curCollapse / collapseTime));

		transform.localScale= new Vector3(curSize, curSize, 1);

	}

	void Reset(){
		curSize = maxSize;
	}

	void SignalLoss(){
	
	}
}
