using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    public GameObject prefab;
    float cooldown = .3f, curr_cooldown = 0;
    float yOffset = 1.5f;
    float mouseOffset_y2z = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curr_cooldown -= Time.deltaTime;
        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && curr_cooldown <= 0)
        {
            /* Aim attempt 1
            Vector3 mouseXZ = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.y + mouseOffset_y2z);
            Vector3 up = transform.position + Vector3.up; // Left found to be the correct direction by trial and error
            GameObject newPrefab = Instantiate(prefab, transform.position, Quaternion.LookRotation(mouseXZ, up)); */
            /* Aim attempt 2
            Instantiate(prefab);
            newPrefab.transform.LookAt(new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.z)); */
            /* No aim */
            Instantiate(prefab, transform.position + (Vector3.up * yOffset), Quaternion.identity);
            curr_cooldown = cooldown;
        }
    }
}
