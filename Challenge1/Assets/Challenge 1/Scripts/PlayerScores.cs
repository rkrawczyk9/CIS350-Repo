/*
 * Robert Krawczyk
 * Challenge 1
 * Player can score or die by entering trigger zones
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            scoreManager.Score();
        }
        else if (collision.gameObject.CompareTag("Death"))
        {
            scoreManager.Lose();
        }
    }
}
