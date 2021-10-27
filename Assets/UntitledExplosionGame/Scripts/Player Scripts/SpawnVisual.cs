using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;


public class SpawnVisual : MonoBehaviour
{
    

    [SerializeField] private float rad = 1;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, rad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
