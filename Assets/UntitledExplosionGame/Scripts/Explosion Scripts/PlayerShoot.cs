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
        
        [SyncVar][SerializeField] public int tempAmmo = 15;
        [SyncVar][SerializeField] private int maxAmmo = 15;
    // HUD Ammo Text
    [SerializeField] public Text ammoText;
       

        private void Start()
        {
            ammoText.text = tempAmmo.ToString();
        }

        private void Update()
        {
            if(isLocalPlayer)
            {
                
                if(Input.GetKeyDown(KeyCode.F))
                {
                    CmdShoot(gameObject);
                    ammoText.text = tempAmmo.ToString();
                }

                if(Input.GetKeyDown(KeyCode.R))
                {
                    Reload();
                    ammoText.text = tempAmmo.ToString();
                }
                ammoText.text = tempAmmo.ToString();
            }

        }

        /// <summary>
        /// Launches grenade / bomb from just in front of gun, auto-despawns after 5 sec
        /// </summary>
        [Command]
        void CmdShoot(GameObject _gun)
        {
            if(tempAmmo > 0)
            {
                GameObject newBomb = Instantiate(bullet, _gun.transform);
                newBomb.transform.localPosition = new Vector3(0, 0, 2);
                newBomb.transform.SetParent(null, true);
                NetworkServer.Spawn(newBomb);
                newBomb.GetComponent<Rigidbody>().AddForce(_gun.transform.forward * myForce, ForceMode.Impulse);
                //Destroy(bomb, 5);
                Debug.Log("shot");
                
                tempAmmo -= 1;
                Debug.Log(tempAmmo);
                ammoText.text = tempAmmo.ToString();
                
            }
            else
            {
                Debug.Log("Out of Ammo!");
                ammoText.text = tempAmmo.ToString();
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
        void Reload()
        {
            // Add Reload animation, delay time
            tempAmmo = maxAmmo;
            ammoText.text = tempAmmo.ToString();
        }
    }
}