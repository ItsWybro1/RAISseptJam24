using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public float max_strength, acceleration;

    [SerializeField] Transform hold_point;

    private bool is_on, is_input_throw, is_throwing, is_holding;

    private float cur_strength;
    private Vector2 cur_direction;

    private PlayerInputManagerScript player_input_manager;

    

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


        //get input

        //check if holding
        //if holding, throw
        if (is_holding)
        {
            //is_input_throw = tog;
        }
        else
        {
            //if not holding, pick up or push
            //if in range to pick up, pick up
            GameObject hold;
            if (AttemptPickup(out hold))
            {
                Pickup(hold);
            }
            else
            {
                //if no pickup and in range to push, push
                if (AttemptPush(out hold))
                {
                    Push(hold);
                }
                // if not in range to push, miss push
                else
                {
                    MissPush();
                }
            }
        }

        //cooldowns
    }

    private bool AttemptPickup(out GameObject hold)
    {
        hold = null;
        //circle cast

        return false;
    }

    private void Pickup(GameObject pick)
    {
        //pickup
        is_holding = true;
        held = pick;
        held.transform.parent = hold_point;

        //fx
    }

    private bool AttemptPush(out GameObject obj)
    {
        obj = null;
        //circle cast

        return false;
    }

    private void Push(GameObject push)
    {
        //push

        //fx
    }

    private void MissPush()
    {
        //cooldown
        //fx
    }

    //are we doing input or auto
    /*public void OnPickupInput()
    {
        //check to pick up
    }*/

    private void FixedUpdate()
    {
        if (!is_on) 
            return;
        if (!is_throwing && is_input_throw)
        {
            print("start throw");
            is_throwing = true;
            
            //fx
        }
        else if (is_throwing && is_input_throw)
        {
            //windup
            Mathf.Clamp(cur_strength += acceleration, -max_strength, max_strength);

            //windup fx
        }
        else if (is_throwing && !is_input_throw)
        { 
            //throw
            is_throwing = false;
            Throw();
        }
    }

    private void Throw()
    {
        print("throw");
        //throw


        //fx
    }

    private IEnumerator CoCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        //end cooldown
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
