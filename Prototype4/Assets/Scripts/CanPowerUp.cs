/* Robert Krawczyk
 * Prototype 4
 * Can pick up powerups, doing which temporarily repels enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPowerUp : MonoBehaviour
{
    [SerializeField] Material poweredUpMat;
    Material normalMat;

    bool _poweredUp = false;
    public bool poweredUp => _poweredUp;

    float poweredUpDur = 8, maxBackForce = 40, maxUpForce = 20, forceRange = 8, allyMaxBackForce = 15, allyMaxUpForce = 11, allyForceRange = 3;
    Color repelledColor = new Color(.4f, .4f, .2f);

    float curr_poweredUpTimeLeft = 0;


    void Start()
    {
        normalMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_poweredUp)
        {
            if (CompareTag("Player"))
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    // Player repels enemies the full amount
                    Repel(enemy, maxBackForce, maxUpForce, forceRange);
                }
            }
            else if (CompareTag("Enemy"))
            {
                // Enemies repel player the full amount
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Repel(player, maxBackForce, maxUpForce, forceRange);

                // Enemies repel eachother a smaller amount
                foreach (GameObject ally in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if(ally == gameObject) { continue; }

                    Repel(ally, allyMaxBackForce, allyMaxUpForce, allyForceRange);
                }
            }
            

            // End powered up state
            curr_poweredUpTimeLeft -= Time.deltaTime;
            if(curr_poweredUpTimeLeft <= 0)
            {
                _poweredUp = false;
                GetComponent<Renderer>().material = normalMat;
            }
        }
    }

    Vector3 Repel(GameObject other, float maxBack, float maxUp, float range, float factor=1)
    {
        
        float dist = Vector3.Distance(other.transform.position, transform.position);
        if(dist <= range)
        {
            // Calculate force
            Rigidbody enemyRb = other.GetComponent<Rigidbody>();
            Vector3 force = (other.transform.position - transform.position).normalized; // direction is away from self
            force *= Mathf.Lerp(maxBack, 0, dist/range); // magnitude is decreasing within the range
            force += Vector3.up * Mathf.Lerp(maxUp, 0, dist/range); // add some upward force
            force *= factor;
            enemyRb.AddForce(force);
            print($"5. {name} repelling {other.name} by {force.magnitude}");

            // Color
            Material otherMat = other.GetComponent<Renderer>().material;
            otherMat.EnableKeyword("_EMISSION");
            otherMat.SetColor("_EmissionColor", repelledColor * dist / range);

            return force;
        }

        return Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            PowerUp();
            Destroy(other.gameObject);
        }
    }

    public void PowerUp()
    {
        print($"{name} powering up!");
        // Start powered up state
        _poweredUp = true;
        GetComponent<Renderer>().material = poweredUpMat;
        curr_poweredUpTimeLeft = poweredUpDur;
    }
}
