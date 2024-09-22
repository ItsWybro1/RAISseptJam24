using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private SpriteRenderer levelSprite;
    [SerializeField] private Transform ballSpawn1;
    [SerializeField] private Transform ballSpawn2;

    public List<Sprite> levelEnvironment = new List<Sprite>();
    public List<GameObject> hazards = new List<GameObject>();
    public List<GameObject> projectiles = new List<GameObject>();


    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        print(levelEnvironment.Count);
        levelSprite.sprite = levelEnvironment[Random.Range(0, levelEnvironment.Count)];

        Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn1);
        Instantiate(projectiles[Random.Range(0, projectiles.Count)], ballSpawn2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
