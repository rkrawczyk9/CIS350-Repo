/*
 * Robert Krawczyk
 * Prototype 1
 * Shows the blast and activates the hitbox
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBlast : MonoBehaviour
{
    public GameObject hitbox;

    private float duration = .2f;
    private float hitbox_duration = .1f;
    public void Blast(){
        gameObject.SetActive(true);
        Invoke("HideBlast", duration);
        hitbox.SetActive(true);
        Invoke("EndHitbox", hitbox_duration);
    }

    private void HideBlast(){
        gameObject.SetActive(false);
    }

    private void EndHitbox(){
        hitbox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
