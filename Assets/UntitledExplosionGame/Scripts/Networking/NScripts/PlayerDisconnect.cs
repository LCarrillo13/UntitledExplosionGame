using Mirror;

using NetworkGame.Networking;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerDisconnect : NetworkBehaviour
{

	 public void Disconnect()
	 { 
		 if(isLocalPlayer)
		 {
			 CmdLeaveMatch();
			Debug.Log("Disconnecting...");
		 }
	 }
	
	 [Client]
	 public void CmdLeaveMatch()
	 {
		 CustomNetworkManager.Instance.StopClient();
		 if (isServer) CustomNetworkManager.Instance.StopHost();
             
		 SceneManager.LoadScene("MainMenu");
	 }


}
