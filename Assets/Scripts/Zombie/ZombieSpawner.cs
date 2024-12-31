using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int initEnemiesPerWave = 5;
    public int currEnemiesPerWave;

    public float spawnDelay = 0.5f;

    public int currWave = 0;
    public float waveCooldown = 10;

    public bool inCooldown;
    public float cooldownCounter = 0;

    public List<MonoBehaviour> currEnemiesAlive; // Use MonoBehaviour to hold both Zombie and ShooterAI

    public GameObject zombiePrefab;
    public ShooterAI shooterPrefab;
    public Transform[] shooterSpawnPoints; // Array of spawn points for shooters

    public TextMeshProUGUI waveOverUI;
    public TextMeshProUGUI cooldownCounterUI;
    public TextMeshProUGUI currWaveUI;

    [SerializeField] private Player player; // Assign in the Inspector

    private void Start()
    {
        currEnemiesPerWave = initEnemiesPerWave;
        StartNextWave();
    }

    private void StartNextWave()
    {
        currEnemiesAlive.Clear();
        currWave++;
        currWaveUI.text = "Wave: " + currWave.ToString();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currEnemiesPerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            // Randomly choose between spawning a zombie or a shooter
            if (Random.value < 0.5f) 
            {
                // Spawn a zombie
                var zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
                Zombie enemyScript = zombie.GetComponent<Zombie>();
                currEnemiesAlive.Add(enemyScript);
            }
            else
            {
                // Spawn a shooter
                int spawnPointIndex = currEnemiesAlive.Count % shooterSpawnPoints.Length;

                // Instantiate the shooter at the spawner's position first
                ShooterAI enemy = Instantiate(shooterPrefab, transform.position, shooterSpawnPoints[spawnPointIndex].rotation);

                enemy.Init(player, shooterSpawnPoints[spawnPointIndex]); // Initialize with the target spawn point
                currEnemiesAlive.Add(enemy);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        List<MonoBehaviour> enemiesToRemove = new List<MonoBehaviour>();
        foreach (EnemyGeneral enemy in currEnemiesAlive)
        {
            // Check if the enemy is dead (using ITakeDamage)
            
            if (enemy.isDead) 
            {
                enemiesToRemove.Add(enemy);
            }
        }

        //        foreach (Zombie zombie in CurrZombiesAlives)
        //        {
        //            if (zombie.isDead)
        //            {
        //                zomToRemove.Add(zombie);
        //            }
        //        }

        foreach (MonoBehaviour enemy in enemiesToRemove)
        {
            currEnemiesAlive.Remove(enemy);
            //Destroy(enemy.gameObject);
        }

        enemiesToRemove.Clear();

        if (currEnemiesAlive.Count == 0 && inCooldown == false)
        {
            StartCoroutine(WaveCooldown());
        }

        if (inCooldown)
        {
            cooldownCounter -= Time.deltaTime;
        }
        else
        {
            cooldownCounter = waveCooldown;
        }

        cooldownCounterUI.text = cooldownCounter.ToString("F0");
    }

    private IEnumerator WaveCooldown()
    {
        inCooldown = true;
        waveOverUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(waveCooldown);
        inCooldown = false;
        waveOverUI.gameObject.SetActive(false);
        currEnemiesPerWave *= 2;
        StartNextWave();
    }
}