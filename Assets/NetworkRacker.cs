using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkRacker : NetworkBehaviour {
	public GameObject Ball;
	public GameObject Player;

			//NetworkServer.SpawnWithAuthority(GameObject.Find("TestPlayer"), this.GetComponent<NetworkIdentity>().connectionToClient);
	public override void OnStartServer(){
		float x = -11.22f;
		float y = 0.285525f;
		float z = -9.749f;
		float diameter = .5715f;
		var ball = (GameObject) Instantiate(Player, new Vector3(-11.22f, .28525f, -24.79f), Quaternion.identity);
			NetworkServer.Spawn(ball);

		//if(isServer){
		for(int i = 0; i < 5; i ++)
		{
			ball = (GameObject) Instantiate(Ball, new Vector3(x, y, z), Quaternion.identity);
			NetworkServer.Spawn(ball);
			int j = i;
			while(j > 0)
			{
			ball = (GameObject) Instantiate(Ball, new Vector3(x+diameter*j, y, z), Quaternion.identity);
			NetworkServer.Spawn(ball);
			j--;
			}
			z += diameter * .866f; //sin(60*)
			x -= diameter * .5f; //cos(60*)
		}
	//}
}
}