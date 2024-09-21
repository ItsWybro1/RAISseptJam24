using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    private bool is_on, is_input_throw, is_throwing, is_holding;

    private float cur_strength;
    private Vector2 cur_direction;

    private PlayerInputManagerScript player_input_manager;

    public float max_strength, acceleration;

    private GameObject held;

    public void Initialize()
    {
        player_input_manager = GetComponentInParent<PlayerInputManagerScript>();
        
        //debug
        Activate();
    }

    public void UpdateDirection(Vector2 direction)
    { 
        
    }

    public void UpdateThrow(bool tog)
    {
        print("Update Throw");
        is_input_throw = tog;
        //is_input_throw = !is_input_throw;
    }

    //are we doing input or auto
    public void OnPickupInput()
    {
        //check to pick up
    }

    private void FixedUpdate()
    {
        if (!is_on) 
            return;
        if (!is_throwing && is_input_throw)
        {
            print("start throw");
            is_throwing = true;
        }
        else if (is_throwing && is_input_throw)
        {
            Mathf.Clamp(cur_strength += acceleration, -max_strength, max_strength);
        }
        else if (is_throwing && !is_input_throw)
        { 
            is_throwing = false;
            Throw();
        }
    }

    private void Throw()
    {
        print("throw");
    }

    private void Push()
    {
        print("push");
    }

    public void Activate()
    {
        is_on = true;
    }

    public void Deactivate()
    { 
        is_on = false;
    }
}
