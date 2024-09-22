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

    private Animator playerAnim;

    public void Initialize()
    { 
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponentInParent<PlayerHandler>().playerAnim;

        //debug
        Activate();
    }

    public void UpdateDirection(Vector2 dir)
    {
        Vector2 initial = direction;
        float i_scale = gameObject.transform.localScale.x;
        direction = dir;
        direction.Normalize();

        //00 to 10 = no; 00 -10 y; 10 00 n; 10 -10 y; -10 00 n; -10 10 y; 10 10 n; -1 -1 n;
        /*if (dir.x != 0 && dir.x != i_scale) { }


        if ((dir.x != initial.x) && ((i_scale != 0 && dir.x != 0 && i_scale != dir.x) ||
            (i_scale == 0 && dir.x == -1))) { }


        if (dir.x != 0 && ((dir.x == 1 && initial.x == -1) || (dir.x == -1 && initial.x == 1) ||
            (i_scale == 1 && initial.x == 0 && dir.x == -1) ||
            (i_scale == -1 && initial.x == 0 && dir.x == 1))) { }*/
        
        if (dir.x != 0)
        {
            if (dir.x > 0)
                gameObject.transform.localScale = new Vector2(1,1);
            else
                gameObject.transform.localScale = new Vector2(-1, 1);
        }

        //old
        /*if (initial.x != 0 && dir.x != 0 && initial.x != dir.x)
            gameObject.transform.localScale *= -1;
        else if(initial.x == 0 && dir.x != 0)
        {
            if(gameObject.transform.localScale.x == -1 && dir.x)
                gameObject.transform.localScale *= -1;
        }*/

        

        
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
        rb.MovePosition(step); 

        // ANIMATIONS

        if (direction != Vector2.zero) {
            playerAnim.SetBool("Run", true);
        } else {
            playerAnim.SetBool("Run", false);
        }
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
