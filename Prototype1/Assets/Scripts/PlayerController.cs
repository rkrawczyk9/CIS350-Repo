/*
 * Robert Krawczyk
 * Prototype 1
 * Controls the player and turret
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] wheels;
    public GameObject turret;
    public GameObject blast;
    private Rigidbody rb;

    // Movement
    private int speed = 30;
    //private int mov_force = 500;
    //private Vector3 mov_offset = new Vector3(0, 1, 0);
    private int rotspeed = 180;
    // Turret
    private int turret_rotspeed = 60;
    private KeyCode rot_turret_L = KeyCode.Z;
    private KeyCode rot_turret_R = KeyCode.X;
    private KeyCode fire_turret = KeyCode.Space;
    private float fire_force = 2500;
    private float turret_cooldown = 2;
    private float curr_turret_cooldown = 0;
    // Flip
    private KeyCode flip_key = KeyCode.Q;
    private float flip_force = 4000;
    private float flip_cooldown = 1;
    private float curr_flip_cooldown = 0;
    private Vector3 flip_offset = new Vector3(0, 1.5f, 0);
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded()) {
            // Move forward
            //rb.AddForceAtPosition(Vector3.forward * mov_force , mov_offset);
            transform.Translate(0, 0, speed * Time.deltaTime * Input.GetAxis("Vertical"));

            // Turn
            transform.Rotate(0, rotspeed * Time.deltaTime * Input.GetAxis("Horizontal") * Input.GetAxis("Vertical"), 0);
        }

        // Turn turret
        if( Input.GetKey(rot_turret_L) ){
            turret.transform.Rotate(0, -turret_rotspeed * Time.deltaTime, 0);
        }
        else if( Input.GetKey(rot_turret_R) ){
            turret.transform.Rotate(0, turret_rotspeed * Time.deltaTime, 0);
        }

        // Check if turret can fire
        if (curr_turret_cooldown > 0 ){
            curr_turret_cooldown -= Time.deltaTime;
            if (curr_turret_cooldown < 0 ){
                curr_turret_cooldown = 0;
            }
        }
        // Fire turret
        if( Input.GetKeyDown(fire_turret) && curr_turret_cooldown == 0 ){
            // Fire
            blast.GetComponent<TurretBlast>().Blast(); // Shows blast sphere
            rb.AddForceAtPosition(Vector3.back * fire_force, turret.transform.position);
            curr_turret_cooldown = turret_cooldown;
        }

        // Check if can flip
        if (curr_flip_cooldown > 0)
        {
            curr_flip_cooldown -= Time.deltaTime;
            if (curr_flip_cooldown < 0)
            {
                curr_flip_cooldown = 0;
            }
        }
        // Flip
        if (Input.GetKeyDown(flip_key) && curr_flip_cooldown == 0){
            float zrot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z).z;
            if (zrot % 360 < 180 && zrot % 360 > 0) // if between 0 and 179
            {
                rb.AddForceAtPosition(Vector3.forward * -flip_force, flip_offset);
            }
            else{ // if between 0 and -180
                rb.AddForceAtPosition(Vector3.forward * flip_force, flip_offset);
            }
            curr_flip_cooldown = flip_cooldown;
        }
    }
    private bool IsGrounded()
    {
        bool all_grounded = true;
        foreach (GameObject wheel in wheels)
        {
            all_grounded = all_grounded && wheel.GetComponent<Wheel>().IsGrounded();
        }
        return all_grounded;
    }
}
