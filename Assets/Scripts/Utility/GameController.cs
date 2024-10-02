using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> levels;

    [SerializeField] float level_end_duration = 3.5f;

    public LobbyUIController lobby;
    public UIUpdater ui;

    public Level level;
    public MinigameController level_controller;

    private bool is_on, in_level, in_game;

    public void Initialize()
    {
        Activate();
        ui = GameManager.instance.GetComponentInChildren<UIUpdater>();
        level = GetComponentInChildren<Level>();
        level_controller = GetComponentInChildren<MinigameController>();
        // ui.Initialize();

        //testing lobby
        EnterLobby();
    }

    public void EnterLobby()
    {
        lobby = GameObject.FindGameObjectWithTag("Lobby").GetComponent<LobbyUIController>();

        level.Initialize();
        level_controller.EnterLobby();
        lobby.EnterLobby();
        StartGame();
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

        while(in_game)
        {
            // spawn level
            in_level = true;
            CreateLevel();

            //lvl gameplay
            while (in_level)
            {
                yield return new WaitForEndOfFrame();
            }
            //lvl end
            print("level end");
            yield return new WaitForSeconds(level_end_duration);

            //despawn level
            //reset players
            foreach (PlayerHandler p in GameManager.instance.GetPlayers()) 
            {
                p.ResetPlayer();
            }

            //start new level  
        }
        //gameover
        EndGame();


        //back to main?
    }

    private void CreateLevel()
    {
        //spawn level
        //initialize level
        //start game
        level.Initialize();
        ui.LevelStart();

    }

    /*private IEnumerator CoCreateLEvel()
    { 
        
    }*/

    public void LevelEnd()
    {
        print("LEvelEnd");
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
