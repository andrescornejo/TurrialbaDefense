using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundHandler : MonoBehaviour
{
    public GameObject enemyObject1, enemyObject2, enemyObject3, enemyObject4;
    public Transform spawner1, spawner2, spawner3, spawner4;
    public TMP_Text timer;
    private List<Transform> spawnPoints;
    private List<GameObject> enemyObjects;
    private List<EnemyProperties> enemies;
    public int dayLengthSeconds, enemiesPerWave, waves, increasePerRound;
    public ScoreHandler scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new List<Transform> { spawner1, spawner2, spawner3, spawner4 };
        enemyObjects = new List<GameObject> {enemyObject1, enemyObject2, enemyObject3, enemyObject4};
        enemies = new List<EnemyProperties>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check if there are no enemies alive
    private bool AllEnemiesDead()
    {
        foreach (var enemy in enemies){
            if (!enemy.isDead){
                return false;
            }
        }
        return true;
    }

    public IEnumerator StartRound()
    {
        // Countdown the day
        int countdown = dayLengthSeconds;
        while (countdown > 0){
            timer.text = countdown + "s para la invasión";
            yield return new WaitForSeconds(1);
            countdown--;
        }

        // Start the night
        timer.text = "Protege la casa!";

        // Spawn X enemies every 2 second in Y waves every 20 seconds
        for (int i = 0; i < waves; i++){
            for (int j = 0; j < enemiesPerWave; j++){
                if (scoreHandler.gameOver) break;
                var spawnPoint = spawnPoints[UnityEngine.Random.Range(0, 4)];
                int xOffset = UnityEngine.Random.Range(-2,3);
                int zOffset = UnityEngine.Random.Range(-2,3);
                var position = new Vector3(spawnPoint.position.x + xOffset, spawnPoint.position.y, spawnPoint.position.z + zOffset);
                var enemyObject = enemyObjects[UnityEngine.Random.Range(0, 4)];
                var enemy = Instantiate(enemyObject, position, spawnPoint.rotation);
                enemy.SetActive(true);
                enemy.GetComponent<EnemyProperties>().scoreHandler = scoreHandler;
                enemies.Add(enemy.GetComponent<EnemyProperties>());
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(20);
        }
        
        // Wait for all enemies to die
        while (!AllEnemiesDead()){
            yield return new WaitForSeconds(1);
        }

        // Reset the round
        enemies = new List<EnemyProperties>();
        enemiesPerWave += increasePerRound;
    }
}
