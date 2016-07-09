using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetAxis("Mouse ScrollWheel") > 0)
	{	
		if(transform.position.y > 0 && transform.position.x > -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x + 22.6f/90f, transform.position.y - 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if(transform.position.y < 0 && transform.position.x > -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x - 22.6f/90f, transform.position.y - 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if (transform.position.y < 0 && transform.position.x < -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x - 22.6f/90f, transform.position.y + 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if (transform.position.y > 0 && transform.position.x < -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x + 22.6f/90f, transform.position.y + 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(1f, 0, 0);
			transform.Rotate(newPos);
		}

	}
	else if(Input.GetAxis("Mouse ScrollWheel") < 0)
	{	
		if(transform.position.y > 0 && transform.position.x > -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x - 22.6f/90f, transform.position.y + 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(-1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if(transform.position.y < 0 && transform.position.x > -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x + 22.6f/90f, transform.position.y + 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(-1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if (transform.position.y < 0 && transform.position.x < -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x + 22.6f/90f, transform.position.y - 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(-1f, 0, 0);
			transform.Rotate(newPos);
		}
		else if (transform.position.y > 0 && transform.position.x < -11.3)
		{
			Vector3 newPos = new Vector3(transform.position.x - 22.6f/90f, transform.position.y - 44f/180f, transform.position.z);
			transform.position = newPos;
			newPos = new Vector3(-1f, 0, 0);
			transform.Rotate(newPos);
		}

	}
	}
}
