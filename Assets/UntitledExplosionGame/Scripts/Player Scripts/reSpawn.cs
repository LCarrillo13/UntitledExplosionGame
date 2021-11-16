using GameScripts.PlayerScripts;

using Mirror;

using NetworkGame.Networking;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using NetworkPlayer = NetworkGame.Networking.NetworkPlayer;

public class reSpawn : NetworkBehaviour
{
    public int myInt = 3;
   //[SyncVar(hook = typeof())] private bool myBool;
   [SerializeField] List<Transform> positions = new List<Transform>();
    
   
    //public Canvas mainCanvas;
    //public GameObject thisPanel;

    
    // Start is called before the first frame update
    void Awake()
    {
        
        // thePlayer = isLocalPlayer
        //     ? GetComponent<Health>().gameObject
        //     : null;

        //respawnButton.interactable = CustomNetworkManager.LocalPlayer;
    }

    // [Command]
    // public void ButtonClicked()
    // {
	   //  GetComponent<Health>().isDead = false;
    // }
    
    // public void Respawn()
    // {
    //         Debug.Log("Respawning...");
    //         if(isLocalPlayer)
    //         {
    //             var pPosition = transform.position;
    //             var sPoint = CustomNetworkManager.Instance.GetStartPosition();
    //
    //             // set positions to new spawn point
    //
    //             pPosition.x = sPoint.position.x;
    //             pPosition.y = 1;
    //             pPosition.z = sPoint.position.x;
    //
    //             // resets player rotation
    //
    //             transform.localRotation = sPoint.rotation;
    //             transform.position = pPosition;
    //
    //             // netPlayer.playerTransform.position = netPlayer.spawnPoint;
    //             // netPlayer.playerTransform.rotation = netPlayer.spawnRotation;
    //             Cursor.lockState = CursorLockMode.Locked;
    //             Cursor.visible = false;
    //             //GetComponent<PlayerShoot>().tempAmmo = GetComponent<PlayerShoot>().maxAmmo;
    //             GetComponent<Health>().isDead = false;
    //         }
    //     
    // }

    void PlayerDeath()
    {
	    // choose random starting position to respawn
	    int index = Random.Range(0, positions.Count);
	    // respawn player back at the start
	    transform.position = positions[index].transform.position;
    }
}
