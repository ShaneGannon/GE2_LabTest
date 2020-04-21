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
        //IF THE STATE MACHINE WASNT A CRASH THE FOLLOWING TWO LINES WOULD BE COMMENTED OUT AND THE CHANGE STATE IN LINE 36 WOULD BE USED
        owner.GetComponent<Arrive>().targetPosition = targetPos;
        owner.GetComponent<Arrive>().enabled = true;
        // Set the target in the main class
        owner.GetComponent<car>().target = picktarget;
        //HERE IS WHERE CHANGE STATE IS SUPPOSED TO BE
        //owner.GetComponent<StateMachine>().ChangeState(new FindTargetState());

    }
}

/* HERE IS THE CODE TO MAKE THE CUBE GO BACK MOVE INTO PICKING A TARGET
class ArriveTargetState : State
{
    public override void Enter()
    {
        GameObject target = owner.GetComponent<car>().target;

        owner.GetComponent<Arrive>().targetPosition = target.transform.position;
        owner.GetComponent<Arrive>().enabled = true;
    }

    public override void Think()
    {
        GameObject target = owner.GetComponent<car>().target;

        if (target.transform.position == owner.GetComponent<car>().transform.position || target.GetComponent<MeshRenderer>().material.color != Color.green)
        {
            owner.GetComponent<StateMachine>().ChangeState(new FindTargetState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Arrive>().enabled = false;
    }
}
*/

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
