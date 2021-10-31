using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    [Space]
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isHit = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
       
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
