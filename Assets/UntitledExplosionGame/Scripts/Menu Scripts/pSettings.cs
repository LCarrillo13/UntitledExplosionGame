using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NetworkPlayer = NetworkGame.Networking.NetworkPlayer;

public class pSettings : MonoBehaviour
{
    [SerializeField] private float sensitivitySet;
    [SerializeField] public float fOVSet;
    private NetworkPlayer nPlayer;
    private Camera playerCam;
    
    // Start is called before the first frame update
    void Start()
    {
	    playerCam = nPlayer.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCam.fieldOfView = fOVSet;
    }
/// <summary>
/// Sets the players POV on player camera
/// </summary>
    void SetPOV()
    {
        // float max, min;
        // max = 150.0f;
        // min = 20.0f;
        playerCam.fieldOfView = fOVSet;
    }

    // private void OnGUI()
    // {
    //     float max, min;
    //     max = 150.0f;
    //     min = 40.0f;
    //     //This Slider changes the field of view of the Camera between the minimum and maximum values
    //     fOVSet = GUI.HorizontalSlider(new Rect(20, 20, 100, 40), fOVSet, min, max);
    // }
}
