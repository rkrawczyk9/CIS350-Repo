/*
 * Robert Krawczyk
 * Prototype 3
 * Controls player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreManager scoreManager;
    Rigidbody rb;
    bool grounded = true;
    float jumpForce = 800;
    Vector3 gravity = new Vector3(0, -19.6f, 0);
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = gravity;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotation;
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        else
        {
            scoreManager.Lose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.Score();
    }
}
