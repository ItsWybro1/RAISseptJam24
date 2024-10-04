using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SpriteRenderer levelSprite;
    [SerializeField] private Transform ballSpawn1;
    [SerializeField] private Transform ballSpawn2;
    [SerializeField] private Transform hazardSpawn1, hazardSpawn2;
    [SerializeField] private List<Transform> player_spawns, ball_spawns, hazard_spawns;
    [SerializeField] private int balls_count, hazzards_count;

    public List<Sprite> levelEnvironment = new List<Sprite>();
    public List<GameObject> hazards = new List<GameObject>();
    public List<GameObject> projectiles = new List<GameObject>(), required_projectiles = new List<GameObject>();
    //required projectiles will be used later for making sure there are always useable projectiles and/or ways to die

    private List<GameObject> spawned;


    public void Initialize()
    {
        ResetLevel();
        //add spawned non-player objects to this list
        spawned = new List<GameObject>();

        //spawn players
        //dont add players to spawned list
        List<PlayerHandler> players = GameManager.instance.GetPlayers();
        List<Transform> all_spawns = new List<Transform>(player_spawns);
        //List<Transform> cur_spawns = new List<Transform>();
        for (int i = 0; i < players.Count; i++) 
        {
            Transform spawn = all_spawns[Random.Range(0, all_spawns.Count)];
            all_spawns.Remove(spawn);
            players[i].GetComponentInChildren<PlayerMovement>().transform.position = spawn.position;
        }

        //LEVEL CHANGE
        levelSprite.sprite = levelEnvironment[Random.Range(0, levelEnvironment.Count)];

        //SPAWN BALLS
        Spawn(balls_count, required_projectiles, projectiles, ball_spawns);
        /*GameObject ball1 = Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn1);
        GameObject ball2 = Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn2);
        spawned.Add(ball1);
        spawned.Add(ball2);*/

        //SPAWN HAZARDS
        //put loop here for list based spawns
        Spawn(hazzards_count, hazards, hazards, hazard_spawns);
        /*hazardSpawn1.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        hazardSpawn2.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));*/

        /*GameObject hazard1 = Instantiate(hazards[Random.Range(0, hazards.Count)], hazardSpawn1);
        GameObject hazard2 = Instantiate(hazards[Random.Range(0, hazards.Count)], hazardSpawn2);
        spawned.Add(hazard1);
        spawned.Add(hazard2);*/
    }

    private void Spawn(int amnt, List<GameObject> req_to_spawn, List<GameObject> possible_spawn, List<Transform> spawn_points)
    {
        List<Transform> all_points = new List<Transform>(spawn_points);
        for (int i = 0; i < amnt; i++)
        { 
            if(all_points.Count < 1)
                all_points = new List<Transform>(spawn_points);
            Transform spawn = all_points[Random.Range(0, all_points.Count)];
            GameObject obj;
            if (i == 0)
                obj = Instantiate(req_to_spawn[Random.Range(0, req_to_spawn.Count)], spawn);
            else
                obj = Instantiate(possible_spawn[Random.Range(0, possible_spawn.Count)], spawn);
            spawned.Add(obj);
            all_points.Remove(spawn);
            //obj.transform.position = spawn.position;
        }
    }

    public void LobbyPlayerSpawn(PlayerHandler player)
    {
        GameObject obj = player.GetComponentInChildren<PlayerMovement>().gameObject;
        obj.transform.position = player_spawns[Random.Range(0, player_spawns.Count)].position;
    }

    public void ResetLevel()
    {
        if (spawned != null && spawned.Count > 0)
        {
            foreach (GameObject s in spawned)
            {
                Destroy(s);            
            }
            spawned.Clear();
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
}
