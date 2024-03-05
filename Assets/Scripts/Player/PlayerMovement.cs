using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputReader ir;
    public float speed = 1;
    public Vector2 jumpPower = new Vector2(0, 5);

    private bool _canMove;
    private bool _canJump;
    private Vector2 _moveInput;
    private Rigidbody2D _rb;

    private void Start()
    {
        _canMove = true;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ir.JumpEvent += Jump;
    }
    private void OnDisable()
    {
        ir.JumpEvent -= Jump;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (!_canMove) return;
        _moveInput = ir.MovementValue;
        _rb.AddForce(_moveInput * speed, ForceMode2D.Force);
    }

    private void Jump()
    {
        Debug.Log("Jump function called.");
        if (!_canJump)
        {
            Debug.Log("Can't jump.");
            return;
        }
        _rb.AddForce(jumpPower, ForceMode2D.Impulse);
        _canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Debug.Log("Grounded.");
            _canJump = true;
        }
    }
}
