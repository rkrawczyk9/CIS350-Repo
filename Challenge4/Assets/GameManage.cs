/* Robert Krawczyk
 * Challenge 4
 * Handles UI
 * I'm getting really tired of writing a winning and losing script every single prototype and challenge
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [SerializeField] Text txt_lose, txt_win, txt_start, txt_wave;

    void Start()
    {
        txt_win.enabled = false;
        txt_lose.enabled = false;
    }

    void Update()
    {
        // turn off start text
        if(Input.GetKeyDown(KeyCode.Space))
        {
            txt_start.enabled = false;
        }

        // update wave text
        txt_wave.text = $"Wave {GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().waveCount.ToString()}";

        // win
        if(GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().waveCount >= 10)
        {
            txt_win.enabled = true;
        }

        // during game over
        if (txt_lose.enabled) // check the directions
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    int enemyScore = 0;
    public void EnemyScore()
    {
        if(++enemyScore >= GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().gameObject.GetComponent<SpawnManagerX>().enemyCount)
            txt_lose.enabled = true;
    }
}
