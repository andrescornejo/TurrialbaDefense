using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class RoundHandler : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform spawner1, spawner2, spawner3, spawner4;
    public TMP_Text timer;
    private List<Transform> spawnPoints;
    private List<EnemyProperties> enemies;
    public int dayLengthSeconds, enemiesPerWave, waves;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new List<Transform> { spawner1, spawner2, spawner3, spawner4 };
        enemies = new List<EnemyProperties>();
        StartCoroutine(StartRound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check if there are no enemies alive
    private bool AllEnemiesDead(){
        foreach (var enemy in enemies){
            if (!enemy.isDead){
                return false;
            }
        }
        return true;
    }

    IEnumerator StartRound()
    {
        // Countdown the day
        int countdown = dayLengthSeconds;
        while (countdown > 0){
            timer.text = countdown + "s";
            yield return new WaitForSeconds(1);
            countdown--;
        }

        // Start the night
        timer.text = "Protect the seed!";

        // Spawn X enemies every 1 second in Y waves every 10 seconds
        for (int i = 0; i < waves; i++){
            for (int j = 0; j < enemiesPerWave; j++){
                var spawnPoint = spawnPoints[UnityEngine.Random.Range(0, 4)];
                int xOffset = UnityEngine.Random.Range(-2,3);
                int zOffset = UnityEngine.Random.Range(-2,3);
                var position = new Vector3(spawnPoint.position.x + xOffset, spawnPoint.position.y, spawnPoint.position.z + zOffset);
                var enemy = Instantiate(enemyObject, position, spawnPoint.rotation);
                enemy.SetActive(true);
                enemies.Add(enemy.GetComponent<EnemyProperties>());
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(10);
        }
        
        // Wait for all enemies to die
        while (!AllEnemiesDead()){
            yield return new WaitForSeconds(1);
        }

        // Reset the round
        enemies = new List<EnemyProperties>();
    }
}
