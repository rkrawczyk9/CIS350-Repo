/*
 * Robert Krawczyk
 * Prototype2
 * Spawns animals as its children over time
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    public WinFeedback winner;

    public GameObject[] prefabs;

    float spawnCooldown = 5;
    float spawnCooldown_min = 1;
    float spawnCooldown_coeff = .03f;
    float curr_spawnCooldown;
    
    Vector3 spawnPos = new Vector3(0, 0, 23.9f);
    float boundary_LR = 13;

    // Start is called before the first frame update
    void Start()
    {
        curr_spawnCooldown = 0; //spawnCooldown; // Wait at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        // Increase spawn rate
        if(spawnCooldown > spawnCooldown_min) { spawnCooldown *= 1 - (spawnCooldown_coeff * Time.deltaTime); }
        else { spawnCooldown = spawnCooldown_min; }
        

        // Spawn
        curr_spawnCooldown -= Time.deltaTime;
        if(curr_spawnCooldown < 0 && !winner.Won())
        {
            GameObject prefab_choice = prefabs[ Random.Range(0, prefabs.Length) ];
            Vector3 spawnPos_choice = spawnPos + Vector3.right * Random.Range(-boundary_LR, boundary_LR);
            Instantiate(prefab_choice, spawnPos_choice, prefab_choice.transform.rotation, transform);
            curr_spawnCooldown = spawnCooldown;
        }
    }
}
