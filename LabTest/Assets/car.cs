using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FindTargetState : State
{
    Vector3 targetPos;
    GameObject picktarget;

    public override void Enter()
    {
        bool targetfound = false;
        // Create an array of all the traffic lights
        GameObject[] lights = GameObject.FindGameObjectsWithTag("TrafficLightTag");

        // Repeat until a target is found
        while (targetfound == false)
        {
            // Go to a random light in the array and check to see if it is green
            int rand = Random.Range(0, 10);
            picktarget = lights[rand];
            if(picktarget.GetComponent<MeshRenderer>().material.color == Color.green)
            {
                // If a target is found, save its porsition for the arrive state
                targetfound = true;
                targetPos = picktarget.transform.position;
                break;
            }
        }

        owner.GetComponent<Arrive>().targetPosition = targetPos;
        owner.GetComponent<Arrive>().enabled = true;
        owner.GetComponent<car>().target = picktarget;
    }
}

public class car : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new FindTargetState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
