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
            scoreManager.TakeDamage();
            Destroy(gameObject);
        }
        
        
    }
}
