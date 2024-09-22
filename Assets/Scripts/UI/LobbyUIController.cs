using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public List<PlayerSO> player_prefabs;
    //public List<GameObject> player_prefabs;

    //private List<GameObject> used_playsers, free_players;
    private List<PlayerSO> used_playsers, free_players;

    private bool is_on, can_join;

    public void Initialize()
    {
        Activate();
    }

    public void EnterLobby()
    {

    }

    public void ExitLobby()
    {

    }

    public void StartGame()
    {
        
        ExitLobby();
    }

    public void PlayerJoin(PlayerHandler player)
    {
        if(!can_join)
        {
            Destroy(player);
            return;
        }
        //add player
        GameManager.instance.PlayerJoin(player);
        //player.JoinLobby();

        //decorate player



        //fx
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
