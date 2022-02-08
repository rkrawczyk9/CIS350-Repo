/*
 * Robert Krawczyk
 * Prototype2
 * Destroys self (cookie) and animal, and calls Score()
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    WinFeedback winner;

    bool destroySelf = true, destroyOther = false;

    private void Start()
    {
        winner = Object.FindObjectOfType<WinFeedback>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            destroyOther = true;
            winner.Score();
        }

        if (destroyOther) { Destroy(other.gameObject); }
        if (destroySelf) { Destroy(gameObject); }
    }
}
