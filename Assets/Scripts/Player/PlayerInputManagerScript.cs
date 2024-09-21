using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerScript : MonoBehaviour
{
    private Gamepad gamepad;
    private PlayerMovement move;
   // private PlayerMovement move;

    [HideInInspector] public bool is_on;

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

        move.Initialize();

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

    public void OnThrow(InputValue val)
    {

    }

    public void OnPush(InputValue val) 
    {
        
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
