using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScripts.PlayerScripts;

using Mirror;

using System;

using Unity.Collections;

namespace GameScripts.ExplosionScripts
{
    public class Explode1 : MonoBehaviour
    {
        [Header("Bomb Variables")]
        [SerializeField] private GameObject bomb;
        
        [SerializeField] private float power = 10.0f;
        [SerializeField] private float radius = 5.0f;
        [SerializeField] private float upForce = 1.0f;
        
        [Tooltip("Bomb Detonation Timer"),SerializeField] private float countdownTime = 5.0f;
        [Tooltip("Bomb Self Destruct Timer"),SerializeField] private float destroyTime = 6.0f;

        private Health pHealth;
        
        

        // Update is called once per frame
        void FixedUpdate()
        {
            // IMPORTANT: THIS DEFINES WHAT TRIGGERS THE EXPLOSION
            // Keybind to detonate explosion after certain number of seconds, specified by countdownTime
            // test
                if(bomb == enabled)
                {
                    Invoke(nameof(Detonate), countdownTime);
                    Invoke(nameof(SelfDestruct), destroyTime);
                }
        }

        [Server]
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other);
            
            Detonate();
            if(other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Health>().health -= 50;
                // changes health text UI
                // other.gameObject.GetComponent<Health>().healthText.text = 
                //     other.gameObject.GetComponent<Health>().health.ToString();
                // if(other.gameObject.GetComponent<Health>().health == 0)
                // {
                //     other.gameObject.GetComponent<Health>().isDead = true;
                // }
            }
            
            
        }

        /// <summary>
        /// Applys ExplosionForce to all GameObjects with a Collider and a RigidBody component in the radius
        /// </summary>
        void Detonate()
        {
            Vector3 explosionPos = bomb.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach(Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
                }
            }
        }

        void SelfDestruct()
        {
            NetworkServer.Destroy(bomb);
        }
    }
}