using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float dist = 1.1f;
    public GameObject patrolEnemy;
    public bool AtWaypoint()
    {
        float distance = Vector2.Distance(transform.position, patrolEnemy.transform.position);

        return distance <= dist;
    }
}
