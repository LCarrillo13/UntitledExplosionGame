using Mirror;

using NetworkGame.Networking;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

using NetworkPlayer = NetworkGame.Networking.NetworkPlayer;
using Random = UnityEngine.Random;

namespace GameScripts.PlayerScripts
{
    public class Health : NetworkBehaviour
    {
        [Header("Health Settings")] 
        [SyncVar][SerializeField] public int health;
        [SerializeField] public int maxHealth = 100;

        [Space] [SerializeField] [SyncVar(hook = nameof(SetHealthText))] public string healthName;
        //[SyncVar(hook = nameof(OnPlayerKilled))][SerializeField]
        public bool isDead = false;
       // [SyncVar][SerializeField] public bool canRespawn = false;
        //[SerializeField] private bool isHit = false;
        [SerializeField] public Text healthText;
        [SerializeField] List<Transform> positions = new List<Transform>();
        //[SerializeField] public Canvas deathCanvas;
        //public GameObject deathPanel;
        private PlayerShoot pShoot;
        


        // Start is called before the first frame update
        void Start()
        {
            if(isLocalPlayer)
            {
                PopulatePositions();
            }
            //healthText.text = health.ToString();
        }

        private void Awake()
        {
             health = maxHealth;
            
            //deathCanvas.gameObject.SetActive(false);
            // deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
            //  if(deathPanel == enabled)
            //  {
            //      deathPanel.gameObject.SetActive(false);
            //  }
             
        }
        
        // Update is called once per frame
        private void Update()
        {
            // For testing purposes
            if(isLocalPlayer)
            {
                // important!!!
                healthName = health.ToString();
                if(health < 1)
                {
                    Death();
                }
                // ^ keep
                if(Input.GetKeyDown(KeyCode.X))
                {
                    Death();
                }

                if(Input.GetKeyDown(KeyCode.Z))
                {
                    health -= 10;
                }
            }
        }

        // FixedUpdate is framerate independant
        private void FixedUpdate()
        {
            if(isLocalPlayer)
            {
                
                if(isDead)
                {
                    Debug.Log("You Died");
                    Death();
                }

                
                //healthText.text = health.ToString();
            }
        }

        void SetHealthText(string _old, string _new)
        {
            // test
            healthText.text = healthName;
        }

        // 
        // Making every way to modify health into its own method
        //

       //[Server]

       void PopulatePositions()
       {
           positions[0] = GameObject.Find("Position1").transform;
           positions[1] = GameObject.Find("Position2").transform;
           positions[2] = GameObject.Find("Position3").transform;
           positions[3] = GameObject.Find("Position4").transform;
       }
        void Death()
        {
            // respawn
            if(isLocalPlayer)
            {
                //deathPanel.gameObject.SetActive(true);
                
                // choose random starting position to respawn
                int index = Random.Range(0, positions.Count);
                // respawn player back at the start
                transform.position = positions[index].transform.position;
                ResetHealth();
               
            }
        }

    #region RespawnTesting

        // public void Respawn()
        // {
        //     Debug.Log("Respawning...");
        //     if(isLocalPlayer)
        //     {
        //         var pPosition = transform.position;
        //         var sPoint = CustomNetworkManager.Instance.GetStartPosition();
        //
        //         // set positions to new spawn point
        //
        //         pPosition.x = sPoint.position.x;
        //         pPosition.y = 1;
        //         pPosition.z = sPoint.position.x;
        //
        //         // resets player rotation
        //
        //         transform.localRotation = sPoint.rotation;
        //         transform.position = pPosition;
        //
        //         // netPlayer.playerTransform.position = netPlayer.spawnPoint;
        //         // netPlayer.playerTransform.rotation = netPlayer.spawnRotation;
        //         Cursor.lockState = CursorLockMode.Locked;
        //         Cursor.visible = false;
        //         //GetComponent<PlayerShoot>().tempAmmo = GetComponent<PlayerShoot>().maxAmmo;
        //         
        //   }
        // void PlayerDeath()
        // {
        //     // choose random starting position to respawn
        //     int index = Random.Range(0, positions.Count);
        //     // respawn player back at the start
        //     transform.position = positions[index].transform.position;
        // }
        
        
        // IEnumerator RespawnButton()
        // {
        //     yield return new WaitForSeconds(1);
        //     canRespawn = true;
        // }
        
        // private void OnPlayerKilled(bool _old, bool _new)
        // {
        //     if(_new == true)
        //     {
        //         //Respawn();
        //         // Disable mesh of player
        //         isDead = true;
        //         pShoot.enabled = false;
        //         StartCoroutine(RespawnButton());
        //     }
        //     else
        //     {
        //         
        //         isDead = false;
        //         canRespawn = false;
        //         pShoot.enabled = true;
        //         
        //         // Re enable player mesh
        //         // Update health
        //
        //     }
        // }
        //
        // [Command]
        // public void CmdPlayerStatus(bool _value)
        // {
        //     isDead = _value;
        // }

        // void IndirectHit()
        // {
        //     isHit = true;
        // }
    #endregion


        void ResetHealth()
        {
            health = maxHealth;
        }
        
        
    }
}