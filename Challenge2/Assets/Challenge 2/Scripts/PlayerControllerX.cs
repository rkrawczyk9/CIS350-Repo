/*
 * Robert Krawczyk
 * Challenge 2
 * Player can spawn dogs
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject dogPrefab;

    float dogCooldown = .5f, curr_dogCooldown = 0;

    // Update is called once per frame
    void Update()
    {
        curr_dogCooldown -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && curr_dogCooldown <= 0 && !scoreManager.GameOver())
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            curr_dogCooldown = dogCooldown;
        }
    }
}
