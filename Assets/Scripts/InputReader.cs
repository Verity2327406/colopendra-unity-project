using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    #region Public Values
    public Vector2 MovementValue { get; private set; }
    public Vector2 ScaleValue { get; private set; }
    #endregion

    #region Private Values
    private Controls _controls;
    #endregion

    #region Player Events
    public event Action JumpEvent;
    public event Action HideEvent;
    public event Action InteractEvent;
    #endregion

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _controls = new Controls();
        _controls.Player.SetCallbacks(this);

        _controls.Player.Enable();
    }

    private void OnDestroy()
    {
        _controls.Player.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        JumpEvent?.Invoke();
    }

    public void OnHide(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        HideEvent?.Invoke();
    }

    public void OnScale(InputAction.CallbackContext context)
    {
        ScaleValue = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        InteractEvent?.Invoke();
    }
}
