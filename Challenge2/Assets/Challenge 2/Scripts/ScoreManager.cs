/*
 * Robert Krawczyk
 * Challenge 2
 * Keeps track of score and handles winning/losing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text txt_score, txt_health, txt_gameOver, txt_restart;

    bool gameOver = false;
    int score = 0;
    int max_health = 3, health;

    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
        txt_score.text = $"Score: {score}";
        txt_health.text = $"Health: {health}";
        txt_gameOver.enabled = false;
        txt_restart.enabled = false;
    }


    public void Score()
    {
        score++;
        txt_score.text = $"Score: {score}";
    }

    public void TakeDamage()
    {
        health--;
        txt_health.text = $"Health: {health}";
        if(health == 0)
        {
            gameOver = true;
            txt_gameOver.enabled = true;
            txt_restart.enabled = true;
        }
    }


    void Update()
    {
        if (gameOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public bool GameOver() { return gameOver; }
}
