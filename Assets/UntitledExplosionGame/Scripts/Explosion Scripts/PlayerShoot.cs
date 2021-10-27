using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Collections;

using UnityEngine;

/// <summary>
/// This is for launching a physical instantiated bullet/bomb that will fly out of the gun, not using raycasts
/// </summary>
public class PlayerShoot : MonoBehaviour
{
    private Transform thisTransform;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float myForce = 25;
    [ReadOnly] private int tempAmmo = 15;
    [SerializeField] private int maxAmmo = 15;

    private void Start()
    {
        thisTransform = transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
           Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    
    /// <summary>
    /// Launches grenade / bomb from just in front of gun, auto-despawns after 6 sec
    /// </summary>
    void Shoot()
    {
        if(tempAmmo > 0)
        {
            bomb = Instantiate(bullet, thisTransform.transform.TransformPoint(0, 0, 2f), thisTransform.rotation);
            bomb.GetComponent<Rigidbody>().AddForce(thisTransform.forward * myForce, ForceMode.Impulse);
            Destroy(bomb, 6);
            Debug.Log("shot");
            tempAmmo--;
        }
    }  
    
    /// <summary>
    /// Reload weapon
    /// </summary>
    void Reload()
    {
        // Add Reload animation, delay time
        tempAmmo = maxAmmo;
    }
}
