using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScripts.PlayerScripts;
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
                }
        }

        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other);
            Detonate();
            Destroy(bomb, 1f);
            if(other.gameObject.CompareTag("Player"))
            {
                pHealth.health -= 25;
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
    }
}