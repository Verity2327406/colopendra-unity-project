using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool canInteract;
    public GameObject player;
    public GameObject door;
    public float dist;

    private void Update()
    {
        canInteract = Vector3.Distance(player.transform.position, transform.position) <= dist;
    }

    public void Interact()
    {
        if (!canInteract) return;

        door.SetActive(false);
        Destroy(GetComponent<InteractIcon>());
        Destroy(this);
    }
}
