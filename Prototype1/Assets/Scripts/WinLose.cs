/*
 * Robert Krawczyk
 * Prototype 1
 * Triggers win/loss actions when player enters win/loss zones
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public Text text;
    public Text scoreText;
    public Text restartText;

    private float winloss_wait = 10;
    private KeyCode restart_key = KeyCode.R;
    public int wonlost = 0; // 1 for win, -1 for loss
    private int score = 0;
    private int winning_score = 3;
    private List<string> zones_entered = new List<string>(10);
    private float score_wait = 1;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        scoreText.text = "0";
        restartText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(wonlost != 0){

            if (Input.GetKeyDown(restart_key)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Collided with " + other.name);
        if (other.CompareTag("TriggerZone")){
            if (other.name.Contains("FinishZone") && !Contains(zones_entered, other.name) && wonlost == 0)
            {
                text.text = "Score!";
                Invoke("reset_text", score_wait);
                zones_entered.Add(other.name);
                score++;
                scoreText.text = score.ToString();
                if(score >= winning_score)
                {
                    text.text = "You win!";
                    restartText.text = "Restart [r]";
                    wonlost = 1;
                }
            }
            else if (other.name == "DeathZone" && wonlost == 0)
            {
                text.text = "You lose!";
                restartText.text = "Restart [r]";
                wonlost = -1;
            }
        }
    }

    private void reset_text(){
        text.text = "";
    }

    private bool Contains<Comparable>(List<Comparable> list, Comparable find){
        foreach(Comparable possible in list){
            if( find.Equals(possible)){
                return true;
            }
        }
        return false;
    }
}
