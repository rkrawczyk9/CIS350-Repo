/*
 * Robert Krawczyk
 * Prototype2
 * Calls Win() when first going past a Z position
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPastPos : MonoBehaviour
{
    float winZ = .5f;
    WinFeedback winner;
    bool past = false;

    // Start is called before the first frame update
    void Start()
    {
        winner = Object.FindObjectOfType<WinFeedback>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= winZ && !past && !winner.Won()) {
            past = true;
            winner.Win();
        }
    }
}
