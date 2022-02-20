using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRate = 1, cooldown;
    public GameObject[] obstacles;
    public GameObject triggerZone;
    Vector3 startPos = new Vector3(22, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        cooldown = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0)
        {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], startPos, Quaternion.identity, transform);
            Instantiate(triggerZone, startPos, Quaternion.identity, obstacle.transform);
            cooldown = spawnRate;
        }
    }
}
