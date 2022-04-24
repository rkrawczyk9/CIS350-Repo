/* Robert Krawczyk
 * Prororype 5
 * Jumps and gets clicked
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;
    [SerializeField] ParticleSystem explosion;

    [SerializeField] public int value;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();

        // Starting force
        rb.AddForce(Vector3.up * Random.Range(16, 18), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10,10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), -6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gm.Score(value);

        Instantiate(explosion, transform.position, explosion.transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
