using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] AudioClip pickup_sfx, land_sfx, hitSurface, hitPlayer;
    [SerializeField] float hold_cooldown = 0.1f, hit_self_cooldown = 0.5f, hit_any_cooldown = 0.1f, fall_dist = 1f;

    private PlayerThrow holder, thrower;
    private Collider2D collider;
    private bool is_on, is_held, can_hold, can_hit_self, on_hit_cooldown;

    //throw
    [SerializeField] float weight = 1, gravity = 10, landed_range = 0.1f, min_bounce = 0.2f, max_speed;

    private bool is_thrown;
    private Vector2 cur_dir, cur_velocity, start_pos;
    private ThrowInfo cur_info;
    private Rigidbody2D rb;
    private Damaging dmg;

    private void Awake()
    {
        Initialize();
        Activate();
    }

    public void Initialize()
    {
        collider = GetComponentInChildren<Collider2D>();
        rb = GetComponentInChildren<Rigidbody2D>();
        if(GetComponentInChildren<Damaging>())
            dmg = GetComponentInChildren<Damaging>();
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
        StartCoroutine(nameof(CoHitAnyCooldown));

        cur_dir = info.throw_dir;
        cur_velocity = info.velocity;
        start_pos = info.drop_pos;

        thrower = info.thrower;

        rb.velocity = info.throw_dir * info.starting_strength;

        print("letgo cur dir: " + cur_dir);
        print("letgo rb cur velocity: " + cur_velocity);
        print("letgo rb velovicity: " + rb.velocity);


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
    public void Bounce(bool player)
    {
        print("bounce");
        //udpate dir

        //if done bouncing, end movement
        is_thrown = false;
        cur_velocity = Vector2.zero;
        rb.velocity = Vector2.zero;
        //fx
        if (player)
        {
            AudioManager.Instance.PlaySFXoneshot(hitPlayer);
            //hit player
        }
        else
        {
            AudioManager.Instance.PlaySFXoneshot(hitSurface);
        }
    }

    private void FixedUpdate()
    {
        if (is_thrown)
        {
            /*Vector2 initial = transform.position;
            cur_velocity.y -= gravity;
            //cur_velocity.x += acc;
            Vector2 step = initial + (cur_velocity * Time.fixedDeltaTime);
            rb.MovePosition(step);*/

            Vector2 step = new Vector2(transform.position.x, transform.position.y);
            //step.y -= gravity * Time.fixedDeltaTime;
            step = rb.velocity;
            step.y -= gravity * Time.fixedDeltaTime;
            rb.velocity = step;

            //print("new step: " + step);
            //print("new velocity: " + rb.velocity);

            //rb.MovePosition(step);

            //bounce
            //if(Vector2.Distance(start_pos, transform.position) > fall_dist)
            if (Mathf.Abs(start_pos.y - transform.position.y) > fall_dist)
            {
                //print("reach dist");
                Bounce(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("pick coll");
        //if(collision)
        if ( can_hit_self ||  !collision.gameObject.GetComponentInParent<PlayerThrow>() || (collision.gameObject.GetComponentInParent<PlayerThrow>() != thrower) )
        {
            bool player = false;
            if(is_thrown)
            {
                if (GetComponentInChildren<Damaging>() && dmg.GetDmgOnHit() && collision.gameObject.GetComponentInChildren<PlayerHealth>())
                {
                    HitPlayer(collision.gameObject.GetComponentInChildren<PlayerHealth>());
                    //collision.gameObject.GetComponentInChildren<PlayerHealth>().Damage(1);
                    player = true;
                }
            }
            Bounce(player);
        }
    }

    private void HitPlayer(PlayerHealth player)
    {
        print("ooaa gottem");
        player.Damage(dmg.GetDamage());
        //fx
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
        if (!is_held)
        {
            //collider.enabled = true;
            print("coold now");
        }       
    }

    private IEnumerator CoHitSelfCooldown()
    {
        print("start cohitself");
        yield return new WaitForSeconds(hit_self_cooldown);
        if (!is_held)
        {
            can_hit_self = true;
            print("coolhitd now");
        }       
    }

    private IEnumerator CoHitAnyCooldown()
    {
        print("start cohitany");
        yield return new WaitForSeconds(hit_any_cooldown);
        if (!is_held)
        {
            on_hit_cooldown = false;
            collider.enabled = true;
            print("coolhitany now");
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
