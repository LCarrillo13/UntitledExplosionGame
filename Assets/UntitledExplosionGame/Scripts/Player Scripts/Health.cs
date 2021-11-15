using Mirror;

using NetworkGame.Networking;

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
        [SyncVar(hook = nameof(OnPlayerKilled))][SerializeField] public bool isDead = false;
        [SyncVar][SerializeField] public bool canRespawn = false;
        //[SerializeField] private bool isHit = false;
        [SerializeField] public Text healthText;
        //[SerializeField] public Canvas deathCanvas;
        public GameObject deathPanel;
        private PlayerShoot pShoot;
        


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
            if(isDead && canRespawn)
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
        
        public void Respawn()
        {
            Debug.Log("Respawning...");
            if(isLocalPlayer)
            {
                var pPosition = transform.position;
                var sPoint = CustomNetworkManager.Instance.GetStartPosition();

                // set positions to new spawn point

                pPosition.x = sPoint.position.x;
                pPosition.y = 1;
                pPosition.z = sPoint.position.x;

                // resets player rotation

                transform.localRotation = sPoint.rotation;
                transform.position = pPosition;

                // netPlayer.playerTransform.position = netPlayer.spawnPoint;
                // netPlayer.playerTransform.rotation = netPlayer.spawnRotation;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //GetComponent<PlayerShoot>().tempAmmo = GetComponent<PlayerShoot>().maxAmmo;
                
            }
        
        }
        IEnumerator RespawnButton()
        {
            yield return new WaitForSeconds(1);
            canRespawn = true;
        }
        
        private void OnPlayerKilled(bool _old, bool _new)
        {
            if(_new == true)
            {
                //Respawn();
                // Disable mesh of player
                isDead = true;
                pShoot.enabled = false;
                StartCoroutine(RespawnButton());
            }
            else
            {
                Respawn();
                isDead = false;
                canRespawn = false;
                pShoot.enabled = true;
                
                // Re enable player mesh
                // Update health

            }
        }

        [Command]
        public void CmdPlayerStatus(bool _value)
        {
            isDead = _value;
        }

        // void IndirectHit()
        // {
        //     isHit = true;
        // }

    }
}