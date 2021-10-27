using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.ExplosionScripts
{
    public class Explode : MonoBehaviour
    {
        [Header("Bomb Variables")]
        [SerializeField] private GameObject bomb;
        
        [SerializeField] private float power = 10.0f;
        [SerializeField] private float radius = 5.0f;
        [SerializeField] private float upForce = 1.0f;
        
        [Tooltip("Bomb Detonation Timer"),SerializeField] private float countdownTime = 5.0f;
        
        

        // Update is called once per frame
        void FixedUpdate()
        {
            // IMPORTANT: THIS DEFINES WHAT TRIGGERS THE EXPLOSION
            // Keybind to detonate explosion after certain number of seconds, specified by countdownTime
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(bomb == enabled)
                {
                    Invoke(nameof(Detonate), countdownTime);
                }
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