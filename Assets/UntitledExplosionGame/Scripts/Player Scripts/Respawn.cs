using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField]
        private bool reSpawn = false;

        private bool playerDeath = false;
        
        // Start is called before the first frame update
        void Start() { }

        // Update is called once per frame
        void Update()
        {
            
        }

        void Death()
        {
            if(playerDeath == true)
            {
                reSpawn = true;
            }
        }
    }
}