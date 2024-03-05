using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float dist = 1.1f;
    public bool AtWaypoint()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(transform.position, player.transform.position);

        return distance <= dist;
    }
}
