using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputReader ir;
    public float speed = 1;
    public Vector2 jumpPower = new Vector2(0, 5);
    public bool hiding;
    public bool unlockedHide;

    private bool _canMove;
    private bool _canClimb;
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
        ir.HideEvent += Hide;
        ir.InteractEvent += Interact;
    }
    private void OnDisable()
    {
        ir.JumpEvent -= Jump;
        ir.HideEvent -= Hide;
        ir.InteractEvent += Interact;
    }

    private void FixedUpdate()
    {
        Movement();
        Climb();
    }

    private void Climb()
    {
        if (!_canClimb) return;
        Vector2 scaleValue = ir.ScaleValue;
        Vector2 force = scaleValue.normalized * speed * Time.deltaTime;
        _rb.AddForce(force, ForceMode2D.Impulse);
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

    private void Hide()
    {
        Debug.Log("Hide function called.");
        if (!unlockedHide) return;

        foreach (GameObject hide in GameObject.FindGameObjectsWithTag("Hide"))
        {
            if (hide.GetComponent<HidingSpot>()._canHide)
            {
                if(!hiding)
                    hide.GetComponent<HidingSpot>().Hide();
                else
                    hide.GetComponent<HidingSpot>().UnHide();
            }
        }
    }

    private void Interact()
    {
        Debug.Log("Interact function called.");
        foreach (GameObject interact in GameObject.FindGameObjectsWithTag("Interact"))
        {
            interact.GetComponent<Lever>().Interact();
        }
    }

    public void ToggleMove(bool toggle)
    {
        _canMove = toggle;
    }

    public void ToggleClimb(bool toggle)
    {
        _canClimb = toggle;
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
