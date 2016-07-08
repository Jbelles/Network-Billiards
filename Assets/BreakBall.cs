using UnityEngine;
using System.Collections;

public class BreakBall : MonoBehaviour {
	float someForce = 3000f;
	// Use this for initialization
	void Start () {
		Invoke("Break", 4f);
	this.GetComponent<Rigidbody>().sleepThreshold = 3f;
	}
	
	// Update is called once per frame
	void Break(){
			this.GetComponent<Rigidbody>().AddForce(new Vector3(.2f, -.02f, 1f) * someForce);
	}
}
