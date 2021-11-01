using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

namespace GameScripts.PlayerScripts
{
    public class Health : MonoBehaviour
    {
        [Header("Health Settings")] [SerializeField] public int health;
        [SerializeField] public int maxHealth = 100;
        [Space] [SerializeField] private bool isDead = false;
        [SerializeField] private bool isHit = false;
        [SerializeField] public Text healthText;


        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
            healthText.text = health.ToString();
        }

        // Update is called once per frame
        private void Update()
        {
            if(isDead == true)
            {
                Debug.Log("You Died");
            }
            healthText.text = health.ToString();
        }

        // 
        // Making every way to modify health into its own method
        //

        void Death()
        {
            isDead = true;
        }

        void IndirectHit()
        {
            isHit = true;
        }

    }
}