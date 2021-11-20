using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Collections;

using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace GameScripts.PlayerScripts
{
    /// <summary>
    /// This is for launching a physical instantiated bullet/bomb that will fly out of the gun, not using raycasts
    /// </summary>
    public class PlayerShoot : NetworkBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject gun;
        [SerializeField] private GameObject bomb;
        [SerializeField] private float myForce = 25;
        [SerializeField] public Text ammoText;
        
        [SyncVar(hook = nameof(SetAmmoText))][SerializeField] public int currentAmmo = 15;
        
        [SyncVar][SerializeField] public int maxAmmo = 15;
        
        [Header("Animations")] [SerializeField] public Animator playerAnim;

        private static readonly int isShooting = Animator.StringToHash("IsShooting");

        public Health pHealth;
        // HUD Ammo Text
    //[SerializeField] public Text ammoText;
       

        private void Start()
        {
            playerAnim = GetComponentInChildren<Animator>();
            
            SetAmmoText(0, 0);
        }

        private void Update()
        {
            if(isLocalPlayer)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    CmdShoot(gun.transform.position, gun.transform.rotation, gun.transform.forward);
                    //playerAnim.Play("Shoot");
                    // playerAnim.SetBool(isShooting, true);
                    //ammoText.text = tempAmmo.ToString();
                }
                // else
                // {
                //     playerAnim.SetBool(isShooting, false); 
                // }

                if(Input.GetKeyDown(KeyCode.R))
                {
                    CmdReload();
                    //ammoText.text = tempAmmo.ToString();
                }

                if(GetComponent<Health>().isRespawning)
                {
                    CmdReload();
                    GetComponent<Health>().isRespawning = false;
                }
                
            }

        }

        void SetAmmoText(int _old, int _new)
        {
            ammoText.text = currentAmmo.ToString();
        }

        /// <summary>
        /// Launches grenade / bomb from just in front of gun, auto-despawns after 5 sec
        /// </summary>
        [Command]
        void CmdShoot(Vector3 _position, Quaternion _rotation, Vector3 _forward)
        {
            if(currentAmmo > 0)
            {
                GameObject newBomb = Instantiate(bullet, _position + _forward * 2f, _rotation);
                // newBomb.transform.localPosition = new Vector3(0, 0, 2);
                // newBomb.transform.SetParent(null, true);
                NetworkServer.Spawn(newBomb);
                newBomb.GetComponent<Rigidbody>().AddForce(_forward * myForce, ForceMode.Impulse);
                //Destroy(bomb, 5);
                Debug.Log("shot");
                
                currentAmmo -= 1;
                Debug.Log(currentAmmo);
                //ammoText.text = tempAmmo.ToString();
                
            }
            else
            {
                Debug.Log("Out of Ammo!");
                //ammoText.text = tempAmmo.ToString();
            }
        }

        // [ClientRpc]
        // Void RpcShoot()
        // {
        //     if(!isLocalPlayer)
        //     {
        //         CmdShoot();
        //     }
        // }
        
        
        /// <summary>
        /// Reload weapon
        /// </summary>
        [Command]
        void CmdReload()
        {
            // Add Reload animation, delay time
            currentAmmo = maxAmmo;
            //ammoText.text = tempAmmo.ToString();
        }
    }
}