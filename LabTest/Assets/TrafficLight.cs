using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class TrafficLight : MonoBehaviour
{
    private IEnumerator GoGreen()
    {
        StopCoroutine(GoRed());
        int rand;
        // Change color, create random timer and wait
        gameObject.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        rand = Random.Range(5, 11);
        yield return new WaitForSeconds(rand);
        StartCoroutine(GoYellow());
        
        yield break;
    }

    private IEnumerator GoYellow()
    {
        StopCoroutine(GoGreen());
        int rand;
        // Change color, create random timer and wait
        gameObject.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(4);
        StartCoroutine(GoRed());
        yield break;
    }

    private IEnumerator GoRed()
    {
        StopCoroutine(GoYellow());
        int rand;
        // Change color, create random timer and wait
        gameObject.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        rand = Random.Range(5, 11);
        yield return new WaitForSeconds(rand);
        StartCoroutine(GoGreen());
        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Change the initial state based on the color of the Game Object
        // For Green
        if(gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            StartCoroutine(GoGreen());
        }

        // For Yellow
        else if (gameObject.GetComponent<MeshRenderer>().material.color == Color.yellow)
        {
            StartCoroutine(GoYellow());
        }

        // For Red
        else if (gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            StartCoroutine(GoRed());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
