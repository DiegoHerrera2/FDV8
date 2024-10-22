using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSimulation : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic) return;
        rb.bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("Simulation activated for " + gameObject.name);
    }
}
