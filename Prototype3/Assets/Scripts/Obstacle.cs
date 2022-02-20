/*
 * Robert Krawczyk
 * Prototype 3
 * Moves left and destroys self offscreen
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed = 30;
    float kill_x = -8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < kill_x)
        {
            Destroy(gameObject);
        }
    }
}
