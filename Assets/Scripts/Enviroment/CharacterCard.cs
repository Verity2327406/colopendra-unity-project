using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCard : MonoBehaviour
{
    public AudioClip collect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<AudioSource>().PlayOneShot(collect);
            collision.gameObject.GetComponent<PlayerMovement>().unlockedHide = true;
            Destroy(gameObject);
        }
    }
}
