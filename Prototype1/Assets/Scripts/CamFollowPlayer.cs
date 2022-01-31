/*
 * Robert Krawczyk
 * Prototype 1
 * Makes the camera follow the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(1, 11, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
