using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        other.gameObject.GetComponent<PlayerMovement>().OnCollectibleCollected.Invoke();
        Destroy(gameObject);
    }
}
