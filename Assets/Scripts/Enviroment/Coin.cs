using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Collectables>().AddCoin();
            other.GetComponent<AudioSource>().PlayOneShot(collect);
            Destroy(gameObject);
        }
    }
}
