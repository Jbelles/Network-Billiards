using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TestPlayerController : NetworkBehaviour {

    void Update()
    {
		if(!hasAuthority){
    		return;
    	}
    	 //if (Input.GetMouseButton(0)) {
            RaycastHit hit = new RaycastHit();
            Vector3 direction = new Vector3();
            if(!Input.GetMouseButton(0))
            {
      			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
	            	hit.point = new Vector3(hit.point.x, .285525f, hit.point.z);
	            	GameObject.Find("GhostBall").GetComponent<MeshRenderer>().enabled = true;
	            	GetComponent<LineRenderer>().enabled = true;
	            	GameObject.Find("GhostBall").transform.position = hit.point;
	                //Debug.DrawLine(transform.position, hit.point, Color.red);
	                GetComponent<LineRenderer>().SetPosition(0, transform.position);
					GetComponent<LineRenderer>().SetPosition(1, hit.point);
					direction = hit.point - transform.position;
					direction.Normalize();
	            }

      		}
        	if(Input.GetMouseButton(0))
			{
				GameObject.Find("GhostBall").GetComponent<MeshRenderer>().enabled = false;
        		GetComponent<LineRenderer>().enabled = false;
			}

			if(Input.GetMouseButtonUp(0))
       		{
        		CmdMovePlayers(direction);
        		GameObject.Find("GhostBall").GetComponent<MeshRenderer>().enabled = false;
        		GetComponent<LineRenderer>().enabled = false;

        		print("ball shot");
	    		print(GetComponent<NetworkIdentity>().clientAuthorityOwner);
	    		print(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().clientAuthorityOwner);
	    		if(GetComponent<NetworkIdentity>().clientAuthorityOwner == GameObject.Find("Player 1").GetComponent<NetworkIdentity>().clientAuthorityOwner && GetComponent<NetworkIdentity>().clientAuthorityOwner != null)
	    		{
	    			print("remove authority from player 1");
	    			CmdAssignPlayerTwoAuthority();
	    			//ShotFired = false;
	    		//	CmdRemoveAuthority(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().netId);
	    		//	CmdAssignAuthority(GameObject.Find("Player 0").GetComponent<NetworkIdentity>().netId);
	    		}
	    		else
	    		{
	    			print("remove authority from player 2");
	    			CmdAssignPlayerOneAuthority();
	    			//ShotFired = false;
	    			//CmdRemoveAuthority(GameObject.Find("Player 0").GetComponent<NetworkIdentity>().netId);
	    			//CmdAssignAuthority(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().netId);
	    		}
	    		//RemoveOwnership(this.GetComponent<NetworkIdentity>().connectionToClient);
      		}

                    //}

    	//if(Input.GetMouseButtonDown(1)){
    		
    	//}

     /*   if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0){
	        var x = Input.GetAxis("Mouse X");
	        var z = Input.GetAxis("Mouse Y");
	        //print(x + " " + z);
	        CmdMovePlayers(x, z);
    	}*/

    }

    [Command]
    void CmdAssignPlayerOneAuthority() {
    	GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().RemoveClientAuthority(GameObject.Find("Player 0").GetComponent<NetworkIdentity>().connectionToClient);
    	GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().AssignClientAuthority(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().connectionToClient);
    }
    [Command]
    void CmdMovePlayers(Vector3 direction)
    {
    	RpcServerMovePlayers(direction);
    }

    [ClientRpc]
    public void RpcServerMovePlayers(Vector3 direction)
    {
          transform.GetComponent<Rigidbody>().AddForce(direction*2000);
          GameObject.Find("GhostBall").GetComponent<MeshRenderer>().enabled = false;
          GetComponent<LineRenderer>().enabled = false;
    }

    [Command]
    public void CmdAssignPlayerTwoAuthority()
    {
    	GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().RemoveClientAuthority(GameObject.Find("Player 1").GetComponent<NetworkIdentity>().connectionToClient);
    	GameObject.Find("TestPlayer(Clone)").GetComponent<NetworkIdentity>().AssignClientAuthority(GameObject.Find("Player 0").GetComponent<NetworkIdentity>().connectionToClient);
    }
              
}
