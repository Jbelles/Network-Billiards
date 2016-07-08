using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BallSleepThreshold : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	this.GetComponent<Rigidbody>().sleepThreshold = 0f;

	}
	
	// Update is called once per frame
	/* void Update () {
	float energy = this.GetComponent<Rigidbody>().velocity.sqrMagnitude * 0.5f;
	energy += this.GetComponent<Rigidbody>().angularVelocity.sqrMagnitude * 0.5f;
	print(energy);
		if(energy < 5f)
		{
			if(energy < .2f)
				this.GetComponent<Rigidbody>().Sleep();
			else{
			this.GetComponent<Rigidbody>().velocity *= .99f;
			this.GetComponent<Rigidbody>().angularVelocity *= .99f;
		}
		}
	}*/
}
