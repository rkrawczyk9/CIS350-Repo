/*
 * Robert Krawczyk
 * Prototype 1
 * Receives force from blast
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rb;

    private float blastForce = 100000;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox"))
        {
            rb.AddForce(Vector3.RotateTowards(Vector3.back * blastForce, other.transform.GetChild(0).transform.position, 100f, 100f));
        }
    }
}
