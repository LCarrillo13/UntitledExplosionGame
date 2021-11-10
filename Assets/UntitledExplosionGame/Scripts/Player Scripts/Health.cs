using Mirror;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

using NetworkPlayer = NetworkGame.Networking.NetworkPlayer;

namespace GameScripts.PlayerScripts
{
    public class Health : NetworkBehaviour
    {
        [Header("Health Settings")] 
        [SyncVar][SerializeField] public int health;
        [SerializeField] public int maxHealth = 100;
        [Space]
        [SyncVar][SerializeField] public bool isDead = false;
        //[SerializeField] private bool isHit = false;
        [SerializeField] public Text healthText;
        //[SerializeField] public Canvas deathCanvas;
        public GameObject deathPanel;
        


        // Start is called before the first frame update
        void Start()
        {
            
            //healthText.text = health.ToString();
        }

        private void Awake()
        {
             health = maxHealth;
            //deathCanvas.gameObject.SetActive(false);
            deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
             if(deathPanel == enabled)
             {
                 deathPanel.gameObject.SetActive(false);
             }
             
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if(isDead)
            {
                Debug.Log("You Died");
                Death();
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                Death();
            }
            //healthText.text = health.ToString();
        }

        // 
        // Making every way to modify health into its own method
        //

       //[Server]
        void Death()
        {
            // respawn
            if(isLocalPlayer)
            {
                deathPanel.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        
        // void IndirectHit()
        // {
        //     isHit = true;
        // }

    }
}