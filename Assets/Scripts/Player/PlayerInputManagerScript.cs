using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerScript : MonoBehaviour
{
    private Gamepad gamepad;
    private PlayerMovement move;
    private PlayerThrow throw_script;

    [HideInInspector] public bool is_on;

    private bool is_throwing;

    private void Awake()
    {
        Initialize();
        Activate();
    }

    public void Initialize()
    {
        /*if (GetComponentInChildren<PlayerInput>().GetDevice<Gamepad>())
            gamepad = GetComponentInChildren<PlayerInput>().GetDevice<Gamepad>();*/
        move = GetComponentInChildren<PlayerMovement>();
        throw_script = GetComponentInChildren<PlayerThrow>();

        move.Initialize();
        throw_script.Initialize();

        //add gp disconecct
    }

    public void OnMove(InputValue val)
    { 
        move.UpdateDirection(val.Get<Vector2>());
        //move.UpdateDirection((Vector2)val.Get<Vector3>());
        print("onmove");
    }

    public IEnumerator CoMove()
    {
        while (true)
        {
            if(gamepad != null)
                move.UpdateDirection(gamepad.leftStick.ReadValue());
            yield return new WaitForEndOfFrame();
        }
    }

    public void OnThrow(/*InputAction.CallbackContext context*/)
    {
        print("onthrow");
        /*if (context.started)
        {
            throw_script.UpdateThrow(true);
            UpdateThrowing(true);
        }
        else if (context.canceled) 
        {
            throw_script.UpdateThrow(false);
            UpdateThrowing(false);
        }*/
        if(is_throwing)
        {
            UpdateThrowing(false);
            throw_script.UpdateThrow(false);
        }
        else
        {
            UpdateThrowing(true);
            throw_script.UpdateThrow(true);
        }
        
    }

    public void OnPush(InputValue val) 
    {
        
    }

    public void UpdateThrowing(bool tog)
    {
        is_throwing = tog;
    }

    public void Activate()
    {
        is_on = true;
        StartCoroutine(nameof(CoMove));
    }

    public void Dectivate()
    {
        is_on = true;
        StopCoroutine(nameof(CoMove));
        move.UpdateDirection(Vector2.zero);
    }
}
