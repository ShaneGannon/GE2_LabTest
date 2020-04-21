using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    IEnumerator Greenlight()
    {
        // Get random range for time
        int rand = Random.Range(5, 11);

        // Set colour to green

        // Yield Return
        yield return new WaitForSeconds(rand);
    }

    IEnumerator Yellowlight()
    {
        // Set colour to yellow

        // Yield Return
        yield return new WaitForSeconds(4.0f);
    }

    IEnumerator Redlight()
    {
        // Get random range for time
        int rand = Random.Range(5, 11);

        // Set colour to red

        // Yield Return
        yield return new WaitForSeconds(rand);
    }

    void OnEnable()
    {
        StartCoroutine(Greenlight());
        StartCoroutine(Yellowlight());
        StartCoroutine(Redlight());
    }

}
