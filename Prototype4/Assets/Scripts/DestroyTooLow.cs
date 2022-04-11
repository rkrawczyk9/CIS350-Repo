/* Robert Krawczyk
 * Prototype 4
 * Destroys self if too low y
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTooLow : MonoBehaviour
{
    float tooLowY = -15;

    void Update()
    {
        if (transform.position.y < tooLowY)
        {
            Destroy(gameObject);
        }
    }
}
