/* Robert Krawczyk
 * Prototype 4
 * Moves the camera to follow player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoint : MonoBehaviour
{
    GameObject player;
    GameManage gameManager;

    float sensitivity = 300, y = 0, boundsRadius = 8;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(gameManager.gameOver);
        if (!gameManager.gameOver)
        {
            // Match player position, unless over [boundsRadius]m from origin. Always at y=[y]
            Vector3 playerXZ = new Vector3(player.transform.position.x, y, player.transform.position.z);
            transform.position = Vector3.ClampMagnitude(playerXZ, boundsRadius);

            // Rotate with input
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime);
        }
    }
}
