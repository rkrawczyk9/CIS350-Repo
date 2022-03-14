/* Robert Krawczyk
 * Assignment 5B - 3D FPS
 * Shoots and hits targets and rigidbodies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour
{
    public float damage = 10, range = 100, hitForce = 10;
    public Camera cam;
    public ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo, range))
        {
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
