/*
 * Robert Krawczyk
 * Challenge 2
 * Destroys this when colliding with anything, and scores if it was a dog
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            scoreManager.Score();
            Destroy(gameObject);
        }
        else
        {
            // scoreManager.TakeDamage(); // covered by DestroyOutOfBounds
            Destroy(gameObject);
        }
        
        
    }
}
