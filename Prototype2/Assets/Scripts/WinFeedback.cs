/*
 * Robert Krawczyk
 * Prototype2
 * Controls scoring, losing hearts, and winning UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinFeedback : MonoBehaviour
{
    public Text txt_win, txt_restart, txt_score, txt_hiScore;
    public Sprite fullHeart, emptyHeart;
    public Image[] heart_images = new Image[5];

    int score = 0, hiScore = 0;
    int heartsLost = 0;

    bool won = false;
    public bool Won() { return won; }

    private void Start()
    {
        txt_score.text = "0";
        txt_win.enabled = false;
        txt_restart.enabled = false;
    }

    public void Score()
    {
        score++;
        txt_score.text = score.ToString();
    }

    public void Win()
    {
        if (!won)
        {
            heartsLost++;
            if(heartsLost <= heart_images.Length) // You lose a heart
            {
                heart_images[heart_images.Length - heartsLost].sprite = emptyHeart;
            }
            if(heartsLost == heart_images.Length) // You lose, animals win
            {
                txt_win.enabled = true;
                txt_restart.enabled = true;
                won = true;
                // Update high score
                if (score > hiScore)
                {
                    hiScore = score;
                    txt_hiScore.text = $"Best:{hiScore}";
                }
                Time.timeScale = 0;
            }
        }
    }

    private void Update()
    {
        if (won)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
