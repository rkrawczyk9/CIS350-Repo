/*
 * Robert Krawczyk
 * 2D Prototype
 * Handles UI, score, and losing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text txt_score, txt_gameOver, txt_restart;

    public int score = 0;
    public bool gameOver = false;

    public void Score()
    {
        score++;
        txt_score.text = score.ToString();
        if(score >= 10)
        {
            gameOver = true;
            txt_gameOver.text = "Winer!";
            txt_restart.text = "[R] to rebar";
        }
    }

    public void Lose()
    {
        if (!gameOver)
        {
            gameOver = true;
            txt_gameOver.text = "Game Over";
            txt_restart.text = "[R] too retsarm";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        txt_score.text = "0";
        txt_gameOver.text = "";
        txt_restart.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
