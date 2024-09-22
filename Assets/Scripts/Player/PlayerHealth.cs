using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int max_health = 1;
    [SerializeField] float invincibility_cooldown = .5f;

    public int cur_health;
    private bool is_on, is_invincible;
    public UIUpdater updater;

    public void Initialize()
    {
        cur_health = max_health;
        //updater = GetComponent<UIUpdater>();
        //debug
        Activate();
    }
    public void Update()
    {
        Debug.Log(cur_health);
    }

    public void Damage(int d)
    {
        if(!is_invincible)
        {
            cur_health = Mathf.Clamp(cur_health - d, 0, cur_health);
            if(cur_health == 0)
            {
                //die
                Die();
            }
            else
            {
                is_invincible = true;
                StartCoroutine(nameof(CoInvincibilityCD));
                //damage fx
            }
        }
    }

    //I dont thnik we'll heal, but just for later/in case
    public void Heal(int h)
    { 
        cur_health = Mathf.Clamp(cur_health + h, cur_health, max_health); 

        //fx
    }

    public void Die()
    {
        GetComponentInParent<PlayerHandler>().Die();

        //fx
        GameManager.gc.ui.allDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<Damaging>() && collision.gameObject.GetComponentInChildren<Damaging>().GetDmgOnContact())
        {
            Damaging dmg = collision.gameObject.GetComponentInChildren<Damaging>();
            dmg.OnHit(this);
            Damage(dmg.GetDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Damaging>() && collision.gameObject.GetComponentInChildren<Damaging>().GetDmgOnContact())
        {
            Damaging dmg = collision.gameObject.GetComponentInChildren<Damaging>();
            dmg.OnHit(this);
            Damage(dmg.GetDamage());
        }
    }

    private IEnumerator CoInvincibilityCD()
    {
        yield return new WaitForSeconds(invincibility_cooldown);
        is_invincible = false;
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
