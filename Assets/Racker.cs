using UnityEngine;
using System.Collections;

public class Racker : MonoBehaviour {
	public GameObject Ball;

  void Start(){
		float x = -11.22f;
		float y = 0.285525f;
		float z = -9.749f;
		float diameter = .5715f;

		//if(isServer){
		for(int i = 0; i < 5; i ++)
		{
			var ball = (GameObject) Instantiate(Ball, new Vector3(x, y, z), Quaternion.identity);
			int j = i;
			while(j > 0)
			{
			ball = (GameObject) Instantiate(Ball, new Vector3(x+diameter*j, y, z), Quaternion.identity);
			j--;
			}
			z += diameter * .866f; //sin(60*)
			x -= diameter * .5f; //cos(60*)
		}
	//}

}} 

