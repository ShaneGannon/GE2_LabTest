using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GreenLightState : State 
{
    public override void Enter()
    {
        owner.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        int rand = Random.Range(5, 11);
        new WaitForSeconds(rand);
    }   
}

class YellowLightState : State
{
    public override void Enter()
    {
        owner.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        new WaitForSeconds(4.0f);
    }
}

class RedLightState : State
{
    public override void Enter()
    {
        owner.GetComponent<TrafficLight>().gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        int rand = Random.Range(5, 11);
        new WaitForSeconds(rand);
    }
}


public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Change the initial state based on the color of the Game Object
        if(gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            GetComponent<StateMachine>().ChangeState(new GreenLightState());
        }
        else if (gameObject.GetComponent<MeshRenderer>().material.color == Color.yellow)
        {
            GetComponent<StateMachine>().ChangeState(new YellowLightState());
        }
        else if (gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            GetComponent<StateMachine>().ChangeState(new RedLightState());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
