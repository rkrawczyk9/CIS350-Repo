using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtStart : MonoBehaviour
{
    public float force = 1000;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
