using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
     {
         if (rb.bodyType == RigidbodyType2D.Static)
         {
             Debug.Log("Collision detected from " + gameObject.name + " - Static");
         }
     }
     
     void OnCollisionEnter2D(Collision2D other)
     {
        if (rb.bodyType == RigidbodyType2D.Static)
        {
            Debug.Log("Collision detected from " + gameObject.name + " - Static");
        }
     }

}
