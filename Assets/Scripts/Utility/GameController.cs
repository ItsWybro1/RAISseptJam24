using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> levels;

    public LobbyUIController lobby;
    public UIUpdater ui;

    private bool is_on, in_level, in_game;

    public void Initialize()
    {
        Activate();
        ui = GameManager.instance.GetComponentInChildren<UIUpdater>();
        //debug
        StartGame();
       // ui.Initialize();
    }

    public void EnterLobby()
    {
        lobby = GameObject.FindGameObjectWithTag("Lobby").GetComponent<LobbyUIController>();

        lobby.EnterLobby();

        //spawn level
        GameObject l = Instantiate(levels[0]);
        l.GetComponent<Level>().Initialize();
    }

    public void ExitLobby()
    {
        
    }

    public void StartGame()
    {
        in_game = true;
        StartCoroutine(nameof(CoGameplay));
    }

    private IEnumerator CoGameplay()
    {
        //   ExitLobby();
        EnterLobby();

        while(in_game)
        {
            // spawn level

            while (in_level)
            {
                yield return new WaitForEndOfFrame();
            }

            //despawn level
        }

        //back to main
    }

    private void CreateLevel()
    {
        //spawn level
        //initialize level
        //start game
    }

    public void LevelEnd()
    {
        in_level = false;
    }

    public void EndGame()
    {

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
