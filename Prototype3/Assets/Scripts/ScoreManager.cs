using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text txt_score, txt_gameOver, txt_restart;

    public int score = 0;
    public bool lost = false;

    public void Score()
    {
        score++;
        txt_score.text = score.ToString();
    }

    public void Lose()
    {
        lost = true;
        txt_gameOver.text = "Game Over!";
        txt_restart.text = "[R] to restart";
        Time.timeScale = 0; // Stop everything
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
        if (Input.GetKeyDown(KeyCode.R) && lost)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
