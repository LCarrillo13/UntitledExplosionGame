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
   [SyncVar] public NetworkPlayer netPlayer;
    public GameObject thePlayer;
    public Button respawnButton;
    //public Canvas mainCanvas;
    //public GameObject thisPanel;

    
    // Start is called before the first frame update
    void Awake()
    {
         thePlayer = isLocalPlayer
             ? GetComponent<Health>().gameObject
             : null;
        
         //respawnButton.interactable = CustomNetworkManager.LocalPlayer;
    }

   
    
    public void Respawn()
    {
        Debug.Log("Respawning...");
        if(isLocalPlayer)
        {
            netPlayer.playerTransform.position = netPlayer.spawnPoint;
            netPlayer.playerTransform.rotation = netPlayer.spawnRotation;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //GetComponent<PlayerShoot>().tempAmmo = GetComponent<PlayerShoot>().maxAmmo;
        }
    }
}
