//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] private Transform[] spawnPoints;
//    [SerializeField] private ShooterAI enemyPrefab;
//    [SerializeField] private float spawnInterval;
//    [SerializeField] private int maxEnemiesNumber;
//    [SerializeField] private Player player;

//    private List<ShooterAI> spawnedEnemies = new List<ShooterAI>();
//    private float timeSinceLastSpawn;

//    private void Start()
//    {
//        timeSinceLastSpawn = spawnInterval;
//    }

//    private void Update()
//    {
//        timeSinceLastSpawn += Time.deltaTime;
//        if (timeSinceLastSpawn > spawnInterval)
//        {
//            timeSinceLastSpawn = 0f;
//            if (spawnedEnemies.Count < maxEnemiesNumber)
//            {
//                SpawnEnemy();
//            }
//        }
//    }

//    private void SpawnEnemy()
//    {
//        ShooterAI enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
//        int spawnPointindex = spawnedEnemies.Count % spawnPoints.Length;
//        enemy.Init(player, spawnPoints[spawnPointindex]);
//        spawnedEnemies.Add(enemy);
//    }


//}