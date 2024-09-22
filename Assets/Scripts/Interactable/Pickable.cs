using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] AudioClip pickup_sfx, land_sfx;
    [SerializeField] float hold_cooldown = 0.1f, hit_self_cooldown = 0.5f, fall_dist = 1f;

    private PlayerThrow holder, thrower;
    private Collider2D collider;
    private bool is_on, is_held, can_hold, can_hit_self;

    //throw
    [SerializeField] float weight = 1, gravity = 10, landed_range = 0.1f, min_bounce = 0.2f, max_speed;

    private bool is_thrown;
    private Vector2 cur_dir, cur_velocity, start_pos;
    private ThrowInfo cur_info;
    private Rigidbody2D rb;

    private void Awake()
    {
        Initialize();
        Activate();
    }

    public void Initialize()
    {
        collider = GetComponentInChildren<Collider2D>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void PickedUp(PlayerThrow player)
    {
        holder = player;
        is_held = true;
        can_hold = false;
        collider.enabled = false;
        //fx
    }

    public void LetGo(ThrowInfo info)
    {
        is_held = false;
        is_thrown = true;
        can_hit_self = false;
        StartCoroutine(nameof(CoHoldCooldown));

        cur_dir = info.throw_dir;
        cur_velocity = info.velocity;

        thrower = info.thrower;


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

        //if done bouncing, end movement
        is_thrown = false;
        cur_velocity = Vector2.zero;
        //fx
    }

    private void FixedUpdate()
    {
        if (is_thrown)
        {
            Vector2 initial = transform.position;
            cur_velocity.y -= gravity;
            Vector2 step = initial + (cur_velocity * Time.fixedDeltaTime);
            rb.MovePosition(step);

            //bounce
            if(Vector2.Distance(start_pos, transform.position) > fall_dist)
                Bounce();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision)
        if(collision != thrower.GetComponentInChildren<Collision2D>())
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
        print("start coholdcoold");
        yield return new WaitForSeconds(hold_cooldown);
        can_hold = true;
        collider.enabled = true;
        print("coold now");
    }

    private IEnumerator CoHitSelfCooldown()
    {
        print("start cohitself");
        yield return new WaitForSeconds(hold_cooldown);
        can_hit_self = true;
        print("coolhitd now");
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

public class ThrowInfo : MonoBehaviour
{
    public bool is_thrown;
    public Vector2 drop_pos, throw_dir, velocity;
    public float starting_strength;
    public PlayerThrow thrower;

    public ThrowInfo(bool thr, Vector2 d, Vector2 t, Vector2 v, PlayerThrow p)
    {
        is_thrown = thr;
        drop_pos = d;
        throw_dir = t;
        velocity = v;
        thrower = p;
    }

    public ThrowInfo(bool thrown, Vector2 d, Vector2 t, float s, PlayerThrow p)
    {
        is_thrown = thrown;
        drop_pos = d;
        throw_dir = t;
        starting_strength = s;
        thrower = p;
    }
}
