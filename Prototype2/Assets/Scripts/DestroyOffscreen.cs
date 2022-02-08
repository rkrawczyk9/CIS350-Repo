/*
 * Robert Krawczyk
 * Prototype2
 * Destroys self when offscreen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public float boundary_LR = 18, boundary_U = 24, boundary_D = -6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check
        if (transform.position.x < -boundary_LR || transform.position.x > boundary_LR || transform.position.z < boundary_D || transform.position.z > boundary_U)
        {
            Destroy(gameObject);
        }
    }
}
