using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public float start_strength = 1, max_strength = 5, acceleration = 1.1f, pickup_radius = 1;

    [SerializeField] Transform hold_point;

    private bool is_on, is_input_throw, is_throwing, is_holding;

    private float cur_strength;
    private Vector2 cur_direction;

    private PlayerInputManagerScript player_input_manager;

    private Animator playerAnim;
    

    private GameObject held;

    public void Initialize()
    {
        player_input_manager = GetComponentInParent<PlayerInputManagerScript>();
        playerAnim = GetComponentInParent<PlayerHandler>().playerAnim;
        
        //debug
        Activate();
    }

    public void UpdateDirection(Vector2 direction)
    { 
        
    }

    public void UpdateThrow(bool tog)
    {
        print("Update Throw");
        //is_input_throw = tog;
        //is_input_throw = !is_input_throw;
        is_input_throw = tog;

        //get input

        //check if holding
        //if holding, throw
        if (is_holding)
        {
            if(is_input_throw && !is_throwing)
            {
                is_throwing = true;
                cur_strength = start_strength;
            }
        }
        else
        {
            is_input_throw = false;
            GetComponentInParent<PlayerInputManagerScript>().UpdateThrowing(false);
            print("else 1");
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

    public void Trip()
    {
        print("Trip");
        Drop();
    }

    private bool AttemptPickup(out GameObject hold)
    {
        print("attempt pick");
        hold = null;
        //circle cast
        Collider2D[] hits = Physics2D.OverlapCircleAll(hold_point.position, pickup_radius);
        foreach (Collider2D hit in hits) 
        {
            if(hit.GetComponentInChildren<Pickable>())
            {
                hold = hit.gameObject;
                return true;
            }
        }

        return false;
    }

    private void Pickup(GameObject pick)
    {
        //pickup
        is_holding = true;
        held = pick;
        held.transform.parent = hold_point;
        held.transform.position = hold_point.position;
        //held.transform.position = Vector2.zero;
        pick.GetComponentInChildren<Pickable>().PickedUp(this);
        print("pickup: " + pick.name);
        //fx
        playerAnim.SetBool("HasBall", true);
    }

    private bool AttemptPush(out GameObject obj)
    {
        obj = null;
        //circle cast
        Collider2D[] hits = Physics2D.OverlapCircleAll(hold_point.position, pickup_radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.GetComponentInChildren<Pushable>())
            {
                obj = hit.gameObject;
                return true;
            }
        }
        return false;
    }

    private void Push(GameObject push)
    {
        print("push");
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
        /*if (!is_throwing && is_input_throw)
        {
            print("start throw");
            is_throwing = true;
            
            //fx
        }*/
        //else if (is_throwing && is_input_throw)
        if(is_holding)
            //held.transform.localPosition = Vector2.zero;
            held.transform.position = hold_point.position;
        if (is_throwing && is_input_throw)
        {
            //windup
            cur_strength = Mathf.Clamp(cur_strength + acceleration, -max_strength, max_strength);
            print("windup: " + cur_strength);
            //windup fx
            playerAnim.SetBool("Wind", true);
        }
        else if (is_throwing && !is_input_throw)
        { 
            //throw
            Throw();
        }
    }

    private void Throw()
    {
        //debug
        print("throw");
        //cur_direction = Vector2.right;
        /*if(transform.localScale.x == 1)
            cur_direction = Vector2.right;
        else
            cur_direction = Vector2.left;*/
        cur_direction = new Vector2(transform.localScale.x, 0);

        //throw
        is_holding = false;
        is_throwing = false;
        held.transform.parent = null;
        ThrowInfo info = new ThrowInfo(true, hold_point.position, cur_direction, cur_strength, this);
        held.GetComponentInChildren<Pickable>().LetGo(info);
        held = null;

        //fx
        playerAnim.SetTrigger("Throw");
        playerAnim.SetBool("HasBall", false);
        playerAnim.SetBool("Wind", false);
    }

    private void Drop()
    {
        print("throw");
        //throw
        held.transform.parent = null;
        ThrowInfo info = new ThrowInfo(false, hold_point.position, cur_direction, cur_strength, this);
        held.GetComponentInChildren<Pickable>().LetGo(info);

        //fx
        playerAnim.SetBool("HasBall", false);
        playerAnim.SetBool("Wind", false);
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
