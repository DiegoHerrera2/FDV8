using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            Debug.Log("Collision detected from " + gameObject.name + " - Dynamic");
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            Debug.Log("Collision detected from " + gameObject.name + " - Dynamic");
        }
    }
}
