/* Robert Krawczyk
 * Prototype 4
 * Spawns enemies and powerups
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab, powerupPrefab;

    public int waveNo => _waveNo;

    float spawnCenterRadius = 7, spawnRingRadius = 1, enemyY = 1.5f, powerupY = 2f, numIncreaseRate = .15f, cooldownDecreaseFactor = .9f, cooldownMin = 1;

    int num = 1, _waveNo = 0;
    float cooldown = 5, curr_cooldown = 0, num_raw;

    // Start is called before the first frame update
    void Start()
    {
        num_raw = num;
    }

    // Update is called once per frame
    void Update()
    {
        curr_cooldown -= Time.deltaTime;
        if(curr_cooldown <= 0)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        // Current spawn settings
        num = Mathf.FloorToInt(num_raw);
        curr_cooldown = cooldown;
        _waveNo++;

        // Modify spawn settings for next time
        num_raw += numIncreaseRate;
        cooldown *= cooldownDecreaseFactor;
        cooldown = Mathf.Max(cooldown, cooldownMin);

        // Reset my position
        transform.position = Vector3.zero;

        // Rotate myself to random direction, and spawn the enemy at random distance in that direction
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.up * Random.Range(0, 360));
        Vector3 spawnCenter = transform.forward * Random.Range(0, spawnCenterRadius);

        transform.position = spawnCenter;

        // Spawn enemies in a ring
        for (int i = 0; i < num; i++)
        {
            transform.Rotate(Vector3.up * 360 / num);
            Instantiate(enemyPrefab, SetY(transform.position + (transform.forward * spawnRingRadius), enemyY), Quaternion.identity);
        }

        // Spawn a powerup every third wave
        if (_waveNo % 3 == 2)
        {
            // Spawn powerup opposite enemy ring
            Instantiate(powerupPrefab, SetY(-transform.position, powerupY), Quaternion.identity);
        }
    }

    Vector3 SetY(Vector3 vec, float y)
    {
        return new Vector3(vec.x, y, vec.z);
    }
}