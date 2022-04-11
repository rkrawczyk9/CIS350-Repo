/* Robert Krawczyk
 * Prototype 4
 * Charges at player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    GameManage gameManager;
    [SerializeField] Material goldMat;

    // Settings
    float force = 30, brakeForce = 25, missAngle = 45, missVelocity = 3, activityDuration = 2, activityCooldown = 1, ascendingForce = 4;

    // Backend
    public bool charging, braking, active;
    float curr_activityTimeLeft, curr_activityCooldown;
    bool turnedYellow = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManage>();

        // activity cooldown
        curr_activityTimeLeft = 0;
        curr_activityCooldown = .5f;
        active = false;
    }

    // Physics movement stuff
    void FixedUpdate()
    {
        if (gameManager.gameOver)
        {
            if (!turnedYellow)
            {
                GetComponent<Renderer>().material = goldMat;
            }

            Brake();
            rb.AddForce(Vector3.up * (ascendingForce + brakeForce));
        }
        else
        {
            // Handling activity cooldown
            // Enemies do stuff for 2 seconds then don't do anything for 2 seconds
            curr_activityTimeLeft -= Time.deltaTime;
            curr_activityCooldown -= Time.deltaTime;
            if (active && curr_activityTimeLeft <= 0)
            {
                //print("now inactive");
                active = false;
                curr_activityCooldown = activityCooldown;
            }
            if (!active && curr_activityCooldown <= 0)
            {
                //print("now active");
                active = true;
                curr_activityTimeLeft = activityDuration;
            }

            // Do stuff while active
            if (active)
            {
                // Are we going at least [missVelocity] m/s and [missAngle] degrees off target? If so, stop
                if (rb.velocity.magnitude >= missVelocity && Vector3.Angle(rb.velocity, player.transform.position - transform.position) >= missAngle)
                {
                    charging = false;
                    braking = true;
                }
                else
                {
                    charging = true;
                    braking = false;
                }

                // Forward/Backward
                if (charging)
                {
                    Vector3 rawForce = (player.transform.position - transform.position).normalized * force;
                    rb.AddForce(new Vector3(rawForce.x, 0, rawForce.z));
                }

                // Brake
                if (braking)
                {
                    Brake();
                }
            }
        }
    }

    Vector3 Brake()
    {
        // Pushes ball in opposite direction it is currently going. Clamped to velocity so it won't start going backwards
        float frameRate = (1 / Time.fixedDeltaTime);
        Vector3 oppositeForce = Vector3.ClampMagnitude(brakeForce * -rb.velocity.normalized, rb.velocity.magnitude * frameRate);
        rb.AddForce(oppositeForce);
        //print($"Braking with {oppositeForce} force");
        return oppositeForce;
    }
}
