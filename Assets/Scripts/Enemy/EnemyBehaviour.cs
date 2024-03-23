using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private Vector3 _curTarget;
    public Patrol patrol;

    private void Update()
    {
        _curTarget = patrol.CurrentWaypoint();

        transform.position = Vector3.MoveTowards(transform.position, _curTarget, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            if (!movement.hiding)
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            else
                Debug.Log("Player his hiding");
        }
    }
}
