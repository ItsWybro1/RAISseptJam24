using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LobbyUIController : MonoBehaviour
{
    public List<PlayerSO> player_prefabs;
    //public List<GameObject> player_prefabs;

    //private List<GameObject> used_playsers, free_players;
    private List<PlayerSO> used_playsers, free_players;

    private bool is_on, can_join;

    //test
    /*private void Awake()
    {
        Initialize();
    }*/

    public void Initialize()
    {
        Activate();
        GameManager.gc .EnterLobby();
    }

    public void EnterLobby()
    {
        print("Enter loobyy");
        can_join = true;
    }

    public void ExitLobby()
    {
        print("ex loobyy");
    }

    public void StartGame()
    {
        can_join = false;
        ExitLobby();
    }

    public void PlayerJoin(PlayerHandler player)
    {
        print("join");
        if(!can_join)
        {
            Destroy(player.gameObject);
            return;
        }
        //add player
        print(GameManager.instance);
        print(player);
        GameManager.instance.PlayerJoin(player);
        //player.JoinLobby();

        //decorate player

        player.gameObject.name = "Player" + GameManager.instance.GetPlayers().Count;
        //player.GetComponentInChildren<Animator>().animato

        GameManager.gc.ui.Join(player);
        

        print("finish join");
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
