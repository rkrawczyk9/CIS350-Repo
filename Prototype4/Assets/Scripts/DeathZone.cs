/* Robert Krawczyk
 * Prototype 4
 * Score on enemy enter, lose on player enter
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    GameManage gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.Score();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.Score();
        }
    }
}
