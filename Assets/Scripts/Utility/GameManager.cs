using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }

    private List<PlayerHandler> players;


    public void Awake()
    {
        if (instance == null && instance != this)
        { 
            Destroy(this);
        }
        else
        {
            instance = this;

            players = new List<PlayerHandler>();

            //initialize everything
            //audio
            //GetComponentInChildren<AudioManager>().Initialize();
            //game controller
            GetComponentInChildren<GameController>().Initialize();
        }
    }

    public List<PlayerHandler> GetPlayers()
    {
        return players;
    }

    public void PlayerJoin(PlayerHandler p)
    {
        players.Add(p);
    }

    public void PlayerLeave(PlayerHandler p)
    {
        
        players.Remove(p);

        //later add loop to iterate through players to readjust any UI and other info
    }
}
