using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Waypoint[] waypoints;
    private Waypoint _curWaypoint;
    private int index = 0;

    private void Start()
    {
        _curWaypoint = waypoints[index];
    }

    public Vector3 CurrentWaypoint()
    {
        return _curWaypoint.transform.position;
    }

    private void Update()
    {
        if (_curWaypoint.AtWaypoint())
        {
            Debug.Log("At Waypoint");
            index++;
            if (index > waypoints.Length - 1)
                index = 0;

            _curWaypoint = waypoints[index];
        }
    }
}

