using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float player_vert_speed = 13, player_horiz_speed = 13;
    float boundary_LR = 14, boundary_U = 15, boundary_D = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * player_vert_speed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * player_horiz_speed * Time.deltaTime);

        // Boundaries
        if (transform.position.x < -boundary_LR)
        {
            transform.position = new Vector3(-boundary_LR, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundary_LR)
        {
            transform.position = new Vector3(boundary_LR, transform.position.y, transform.position.z);
        }
        if (transform.position.z < boundary_D)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundary_D);
        }
        else if (transform.position.z > boundary_U)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundary_U);
        }
    }
}
