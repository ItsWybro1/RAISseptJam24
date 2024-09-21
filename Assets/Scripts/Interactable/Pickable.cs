using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] AudioClip pickup_sfx, land_sfx;
    [SerializeField] float hold_cooldown;

    private PlayerThrow holder;
    private bool is_held, can_hold;

    //throw
    [SerializeField] float weight = 1, gravity = 10, landed_range = 0.1f, min_bounce = 0.2f;

    private bool is_thrown;
    private Vector2 cur_dir, cur_velocity, start_pos;
    private ThrowInfo cur_info;

    public void Initialize()
    {
        
    }

    public void PickedUp(PlayerThrow player)
    {
        holder = player;
        is_held = true;
        can_hold = false;
        //fx
    }

    public void LetGo(ThrowInfo info)
    {
        is_held = false;
        is_thrown = true;
        StartCoroutine(nameof(CoHoldCooldown));

        cur_dir = info.throw_dir;
        cur_velocity = info.velocity;


        //check if thrown or dropped
        if (info.is_thrown)
        {
            //throw fx
        }
        else
        {
            //drop fx
        }

    }

    //maybe do a bounce function later
    public void Bounce()
    {
        //udpate dir

        //fx
    }

    private void FixedUpdate()
    {
        if (is_thrown)
        {
            Vector2 initial = transform.position;
            cur_velocity.y += gravity;
            //Vector2 step = 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision)
        Bounce();
    }

    public PlayerThrow GetHolder()
    {
        return holder;
    }

    public bool GetIsHeld()
    {
        return is_held;
    }

    private IEnumerator CoHoldCooldown()
    {
        yield return new WaitForSeconds(hold_cooldown);
        can_hold = true;
    }
}

public class ThrowInfo : MonoBehaviour
{
    public bool is_thrown;
    public Vector2 drop_pos, throw_dir, velocity;

    public ThrowInfo(bool thr, Vector2 d, Vector2 t, Vector2 v)
    {
        is_thrown = thr;
        drop_pos = d;
        throw_dir = t;
        velocity = v;
    }
}
