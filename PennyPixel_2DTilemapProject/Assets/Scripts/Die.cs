/*
 * Robert Krawczyk
 * 2D Prototype
 * Lose if go off screen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(transform.position.y < -5)
        {
            sm.Lose();
        }
    }
}
