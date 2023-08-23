using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 5.0f;


    void Start()
    {

    }


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 3)
        {
            currentWP++;
        }

        if (currentWP >= waypoints.Length)
        {
            currentWP = 0;
        }

        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
