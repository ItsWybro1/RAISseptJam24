using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float max_speed, acceleration, deacceleration;

    private Vector2 direction;
    private Rigidbody2D rb;
    private float cur_speed;
    private bool is_on, is_stun;

    public void Initialize()
    { 
        rb = GetComponent<Rigidbody2D>();

        //debug
        Activate();
    }

    public void UpdateDirection(Vector2 dir)
    { 
        direction = dir;
        direction.Normalize();
        print("update dir to " + dir);
    }

    public void FixedUpdate()
    {
        if (!is_on || is_stun)
            return;
        Vector2 step = direction * max_speed * Time.fixedDeltaTime;
        //step.Normalize();
        //cur_speed += acceleration;
        //step = step * cur_speed * Time.fixedDeltaTime;
        step += (Vector2)transform.position;
        print("step: " + step);
        rb.MovePosition(step);
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
