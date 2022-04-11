/* Robert Krawczyk
 * Prototype 4
 * Turn constantly
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float degreesPerSec = 120;

    void Update()
    {
        transform.Rotate(Vector3.up * degreesPerSec * Time.deltaTime);
    }
}
