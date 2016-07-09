using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UniqueName : NetworkBehaviour {
	[SyncVar] public string playerUniqueName;
	private Transform myTransform;
	// Use this for initialization

	public override void OnStartLocalPlayer()
	{
		GetNetIdentity();
		SetIdentity();

		print(GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().clientAuthorityOwner);
    	if(GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().clientAuthorityOwner == null)
    	{
    		if(NetworkServer.connections.Count != 0)
    		{
    			CmdAssignAuthority(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().netId);
    			Debug.Log("authority to player 1");
    		}
    	}
    	else
    	{	int rand = Random.Range(0, 2);
    		Debug.Log(rand);
    		if(rand < 1)
    		{
    			CmdAssignAuthority(GameObject.Find("Player 0").GetComponent<NetworkIdentity>().netId);
    			print("authority to player 0");
    		}
    	}
	}
	void Awake() {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(myTransform.name == "" || myTransform.name == "Player(Clone)")
		{
			SetIdentity();
		}
	}

	[Client]
	void GetNetIdentity(){
		CmdTellServerMyIdentity(MakeUniqueIdentity());
	}

	void SetIdentity()
	{
		if(!isLocalPlayer)
		{
			myTransform.name = playerUniqueName;
		}
		else
		{
			myTransform.name = MakeUniqueIdentity();
		}
	}

	string MakeUniqueIdentity()
	{
		string uniqueName = "Player " + NetworkServer.connections.Count;
		return uniqueName;
	}

	[Command]
	void CmdTellServerMyIdentity(string name)
	{
		playerUniqueName = name;
	}

	[Command]
    void CmdAssignAuthority(NetworkInstanceId playerId) {
    	GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().AssignClientAuthority(NetworkServer.FindLocalObject(playerId).GetComponent<NetworkIdentity>().connectionToClient);
    }
}
