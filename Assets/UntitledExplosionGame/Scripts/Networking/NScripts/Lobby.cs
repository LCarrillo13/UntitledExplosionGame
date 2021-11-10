using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using NetworkPlayer = NetworkGame.Networking.NetworkPlayer;
using NetworkGame.Networking;

using System;



public class Lobby : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Awake()
    {
        startButton.interactable = CustomNetworkManager.Instance.IsHost;
    }

    public void OnClickStartMatch()
    {
        NetworkPlayer localplayer = CustomNetworkManager.LocalPlayer;
        localplayer.StartMatch();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    
}
