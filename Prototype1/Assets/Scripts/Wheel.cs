/*
 * Robert Krawczyk
 * Prototype 1
 * Checks if wheel is colliding with something
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private MeshCollider collider;
    private float groundedCheck_rad = .18f;
    private float groundedCheck_depth = .05f;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsGrounded()
    {
        return !Physics.CheckCapsule(collider.bounds.center, collider.bounds.extents - Vector3.down * groundedCheck_depth, groundedCheck_rad);
    }
}
