using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval_min = 3, spawnInterval_max = 5;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        StartCoroutine(SpawnBallsCoroutine());
    }

    IEnumerator SpawnBallsCoroutine()
    {
        yield return new WaitForSeconds(startDelay);// Wait seconds before starting to spawn
        while (true)
        {
            SpawnRandomBall();
            yield return new WaitForSeconds(Random.Range(spawnInterval_min, spawnInterval_max));
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        if (!scoreManager.GameOver())
        {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], spawnPos, ballPrefabs[0].transform.rotation);
        }
        
    }

}
