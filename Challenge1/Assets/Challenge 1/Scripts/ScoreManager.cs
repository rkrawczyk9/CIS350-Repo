/*
 * Robert Krawczyk
 * Challenge 1
 * Manages score and winning and losing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text winloseText;
    public Text restartText;

    public int score = 0;
    private int winning_score = 5;
    private bool ready_to_restart = false;

    public void Score()
    {
        if (!ready_to_restart)
        {
            score++;
            scoreText.text = score.ToString();
            if (score >= winning_score)
            {
                winloseText.text = "You win!";
                restartText.text = "Restart? [r]";
                ready_to_restart = true;
            }
        }
    }

    public void Lose()
    {
        if (!ready_to_restart)
        {
            winloseText.text = "You lose!";
            restartText.text = "Restart? [r]";
            ready_to_restart = true;
        }
    }

    void Start()
    {
        scoreText.text = "0";
        winloseText.text = "";
        restartText.text = "";
    }

    void Update()
    {
        if (ready_to_restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
