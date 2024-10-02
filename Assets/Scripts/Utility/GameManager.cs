using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameController gc;
    private List<PlayerHandler> players;


    public void Awake()
    {
        if (instance != null && instance != this)
        { 
            Destroy(gameObject);
        }
        else
        {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);

            players = new List<PlayerHandler>();

            //initialize everything
            //audio
            //GetComponentInChildren<AudioManager>().Initialize();
            //game controller
            gc = GetComponentInChildren<GameController>();
            gc.ui.Initialize();
        }
    }

    public List<PlayerHandler> GetPlayers()
    {
        return players;
    }

    public void PlayerJoin(PlayerHandler p)
    {
        print("add player");
        players.Add(p);
    }

    public void PlayerLeave(PlayerHandler p)
    {
        
        players.Remove(p);

        //later add loop to iterate through players to readjust any UI and other info
    }
}
