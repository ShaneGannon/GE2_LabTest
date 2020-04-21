using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    int trafficLights = 10;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        // Use y = 10 so that traffic lights sit atop quad plane instead of halfway through it
        // Camera is rotated to look downward instead of forward so y and z essentially switch for this test
        Vector3 center = new Vector3(0, 10, 0);

        // Calculate angle using amount of lights for even placement of GOs
        int angle = 360 / trafficLights;

        // Create Traffic light Game Objects using prefab, with their center along the circumfrance of a circle with center 0,0,0 and radius 60 units
        // Radius 60 was used to create all Traffic lights within the view of the camera
        for(int i = 0; i < trafficLights; i++)
        {
            int a = i * angle;
            Vector3 pos = GetPos(center, 60.0f, a);
            var myObject = Instantiate(prefab, pos, Quaternion.identity);

            // Use random number genertaion to decide initial color and state
            int rand = Random.Range(0, 3);
            if(rand == 0)
            {
                // Change color of prefab
                myObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if(rand == 1)
            {
                // Change color of prefab
                myObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (rand == 2)
            {
                // Change color of prefab
                myObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            myObject.transform.parent = this.transform; // Parenting
        }
    }

    Vector3 GetPos(Vector3 center, float radius, int angle)
    {
        Vector3 pos;

        // Get the position for the new instantiation by getting a pos on the circumfrance 
        // Y and Z are switched as explained above
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return pos;
    }
}
