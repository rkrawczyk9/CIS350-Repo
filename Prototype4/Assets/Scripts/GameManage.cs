/* Robert Krawczyk
 * Prototype 4
 * Handles UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    [SerializeField] GameObject[] showOnPause;
    [SerializeField] GameObject[] showOnGameOver;
    [SerializeField] GameObject[] hideOnGameOver;
    [SerializeField] Text txtScore, txtWave;
    [SerializeField] SpawnManager spawnManager;

    int score = 0;
    bool _paused = false, _gameOver = false;
    public bool paused => _paused;
    public bool gameOver => _gameOver;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _paused = false;
        _gameOver = false;

        // Initialize UI
        txtScore.text = score.ToString();
        foreach (GameObject obj in showOnPause)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in showOnGameOver)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        txtWave.text = $"Wave {spawnManager.waveNo} ";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }

        // Restart
        if ((_paused || _gameOver) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Score()
    {
        score++;
        txtScore.text = score.ToString();
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;

        _paused = true;
        foreach(GameObject obj in showOnPause)
        {
            obj.SetActive(true);
        }
    }

    public void UnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _paused = false;
        foreach (GameObject obj in showOnPause)
        {
            obj.SetActive(false);
        }
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;

        _gameOver = true;
        foreach (GameObject obj in showOnGameOver)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in hideOnGameOver)
        {
            obj.SetActive(false);
        }
    }

    void OnApplicationPause(bool pause)
    {
        Pause();
    }
}
