using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will be responsible for spawning in all the enemies, and setting their values.
public class enemyManager : MonoBehaviour
{
    public GameObject testEnemyPrefab;
    
    
    
    public List<NPCClass> enemies = new List<NPCClass>();


    //spawns an enemy at a position, need to add type of enemy aswell
    public void SpawnEnemy(Vector2 pos)
    {
        GameObject enemyObject = Instantiate(testEnemyPrefab,pos, Quaternion.identity);
        enemies.Add(new NPCClass(5, 1, false, 2, 10, enemyObject));
        
    }

    void Start()
    {
        Vector2 spawnPoint = new Vector2(1, 1);
        SpawnEnemy(spawnPoint);
        
    }


    //calls to the behavior function of all enemies every frame
    void Update()
    {
        foreach (NPCClass i in enemies) {
            i.Behavior();
        }
    }


}
