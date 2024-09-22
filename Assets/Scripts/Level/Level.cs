using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SpriteRenderer levelSprite;
    [SerializeField] private Transform ballSpawn1;
    [SerializeField] private Transform ballSpawn2;
    [SerializeField] private Transform hazardSpawn1, hazardSpawn2;

    public List<Sprite> levelEnvironment = new List<Sprite>();
    public List<GameObject> hazards = new List<GameObject>();
    public List<GameObject> projectiles = new List<GameObject>();


    private void Start()
    {

    }

    public void Initialize()
    {
        //LEVEL CHANGE
        levelSprite.sprite = levelEnvironment[Random.Range(0, levelEnvironment.Count)];

        //SPAWN BALLS
        GameObject ball1 = Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn1);
        GameObject ball2 = Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn2);

        //SPAWN HAZARDS
        hazardSpawn1.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        hazardSpawn2.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));

        GameObject hazard1 = Instantiate(hazards[Random.Range(0, hazards.Count)], hazardSpawn1);
        GameObject hazard2 = Instantiate(hazards[Random.Range(0, hazards.Count)], hazardSpawn2);
    }

    public void ResetLevel()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
