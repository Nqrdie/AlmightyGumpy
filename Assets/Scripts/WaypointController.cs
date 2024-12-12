using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaypointController : MonoBehaviour
{
    public GameObject waypoints;
    private Transform[] waypointList;
    private int current = 1;
    public float speed;
    private float waypointRadius;


    private void Start()
    {
        waypointRadius = Random.Range(1, 5);
        waypointList = waypoints.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        
        Debug.Log(waypointRadius);
        
        if (Vector3.Distance(waypointList[current].position, transform.position) < waypointRadius)
        {
            waypointRadius = Random.Range(1, 5);
            current++;
            if (current >= waypointList.Length)
            {
                current = 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypointList[current].position, Time.deltaTime * speed);
    }
}