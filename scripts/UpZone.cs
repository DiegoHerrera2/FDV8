using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpZone : MonoBehaviour
{
    
    [SerializeField] private float force = 50f;
    private void OnTriggerStay2D(Collider2D other)
    {
        var rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * force);
        }
    }
}
