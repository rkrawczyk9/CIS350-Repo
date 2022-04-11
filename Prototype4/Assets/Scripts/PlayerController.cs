/* Robert Krawczyk
 * Prototype 4
 * Player movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject focalPoint;
    Rigidbody rb;
    
    float forwardForce = 30, backwardForce = 20, leftRightForce = 15, maxBrakeForce = 25;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Forward
        rb.AddForce(focalPoint.transform.forward * forwardForce * Mathf.Max(0, Input.GetAxis("Vertical")));

        // Backward
        rb.AddForce(focalPoint.transform.forward * backwardForce * Mathf.Min(0, Input.GetAxis("Vertical")));

        // Left/Right
        rb.AddForce(focalPoint.transform.right * leftRightForce * Input.GetAxis("Horizontal"));

        // Brake
        if (Input.GetKey(KeyCode.Space))
        {
            // Pushes ball in opposite direction it is currently going. Clamped to velocity so it won't start going backwards
            float frameRate = (1 / Time.fixedDeltaTime);
            Vector3 oppositeForce = Vector3.ClampMagnitude(maxBrakeForce * -rb.velocity.normalized, rb.velocity.magnitude * frameRate);
            rb.AddForce(oppositeForce);
            //print($"Braking with {oppositeForce} force");
        }
    }
}
