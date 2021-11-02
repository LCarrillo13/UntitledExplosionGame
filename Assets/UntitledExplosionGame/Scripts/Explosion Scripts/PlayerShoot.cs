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
        private Transform thisTransform;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject gun;
        [SerializeField] private GameObject bomb;
        [SerializeField] private float myForce = 25;
        [ReadOnly] private int tempAmmo = 15;
        [SerializeField] private int maxAmmo = 15;
    // HUD Ammo Text
        [SerializeField] private Text ammoText;

        private void Start()
        {
            thisTransform = gun.transform;
            ammoText.text = tempAmmo.ToString();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                CmdShoot();
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }

        /// <summary>
        /// Launches grenade / bomb from just in front of gun, auto-despawns after 6 sec
        /// </summary>
        [Command]
        void CmdShoot()
        {
            if(tempAmmo > 0)
            {
                bomb = Instantiate(bullet, thisTransform.transform.TransformPoint(0, 0, 2f), thisTransform.rotation);
                NetworkServer.Spawn(bomb);
                bomb.GetComponent<Rigidbody>().AddForce(thisTransform.forward * myForce, ForceMode.Impulse);
                Destroy(bomb, 6);
                Debug.Log("shot");
                tempAmmo--;
                ammoText.text = tempAmmo.ToString();
            }
            else
            {
                Debug.Log("Out of Ammo!");
            }
        }
        
        
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