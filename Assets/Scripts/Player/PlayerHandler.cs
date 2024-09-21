using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject player_obj;

    private bool is_on, is_dead;

    PlayerInputManagerScript player_input_manager;
    PlayerHealth health;
    PlayerThrow throw_script;

    public void Initialize()
    {
        player_input_manager = GetComponent<PlayerInputManagerScript>();
        health = GetComponentInChildren<PlayerHealth>();
        throw_script = GetComponentInChildren<PlayerThrow>();

        player_input_manager.Initialize();
        health.Initialize();
        throw_script.Initialize();
    }

    public void Die()
    {
        is_dead = true;
        Deactivate();

        //tell game controller

        //relocate
        player_obj.transform.position = new Vector2(1000, 1000);
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
