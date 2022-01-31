/*
 * Robert Krawczyk
 * Challenge 1
 * Makes camera stay with plane
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = gameObject.transform.position - plane.transform.position; // Allows you to set the offset precisely
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
