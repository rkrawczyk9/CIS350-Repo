/* Robert Krawczyk
 * Prororype 5
 * Manages game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    [SerializeField] TextMeshProUGUI txt_score, txt_gameover;
    [SerializeField] Button butt_restart, butt_easy, butt_medium, butt_hard;

    int score;
    bool gameOn = false;
    public enum Difficulty{
        easy,medium,hard
    };

    float spawnRate = .75f;
    private void Start()
    {
        txt_gameover.enabled = false;
        butt_restart.gameObject.SetActive(false);
    }
    public void StartGame(Difficulty difficulty)
    {
        score = 0;
        gameOn = true;
        butt_easy.gameObject.SetActive(false);
        butt_medium.gameObject.SetActive(false);
        butt_hard.gameObject.SetActive(false);
        txt_score.text = "Score: " + score;

        StartCoroutine(SpawnTargets(difficulty));
    }

    IEnumerator SpawnTargets(Difficulty difficulty)
    {
        while (gameOn)
        {
            yield return new WaitForSeconds(spawnRate * (3-(int)difficulty));
            Instantiate( targets[Random.Range(0, targets.Length)] );
            //Score(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(int scoreToAdd)
    {
        score += scoreToAdd;
        if(score <= 0)
        {
            txt_gameover.enabled = true;
            gameOn = false;
            butt_restart.gameObject.SetActive(true);
        }
        else
        {
            txt_score.text = "Score: " + score;
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EasyButt()
    {
        StartGame(Difficulty.easy);
    }
    public void MediumButt()
    {
        StartGame(Difficulty.medium);
    }

    public void HardButt()
    {
        StartGame(Difficulty.hard);
    }
}
