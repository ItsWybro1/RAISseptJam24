using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject player_obj;

    public Animator playerAnim;

    private bool is_on, is_dead;

    PlayerInputManagerScript player_input_manager;
    PlayerHealth health;
    PlayerThrow throw_script;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        player_input_manager = GetComponent<PlayerInputManagerScript>();
        health = GetComponentInChildren<PlayerHealth>();
        throw_script = GetComponentInChildren<PlayerThrow>();

        player_input_manager.Initialize();
        health.Initialize();
        throw_script.Initialize();

        if (GameObject.FindGameObjectWithTag("Lobby"))
        {
            GameObject.FindGameObjectWithTag("Lobby").GetComponent<LobbyUIController>().PlayerJoin(this);
        }
        else
            Destroy(gameObject);
    }

    public void Die()
    {
        is_dead = true;
        Deactivate();
        player_obj.SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);

        //tell game controller

        //relocate
        //player_obj.transform.position = new Vector2(1000, 1000);

        // FX

        playerAnim.SetBool("Hit", true);
    }

    public void ResetPlayer()
    {
        playerAnim.SetBool("Hit", false);
        is_dead = false;
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
