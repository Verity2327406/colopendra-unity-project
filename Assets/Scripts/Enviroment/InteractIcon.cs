using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIcon : MonoBehaviour
{
    public GameObject icon;
    public float dist;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        icon.SetActive(Vector3.Distance(player.transform.position, gameObject.transform.position) < dist);
    }
}
