using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawningScriptForset : MonoBehaviour
{
    public float timeSpawnerLimit;
    public float chanceSpawnLimit;
    public GameObject normalSourEnemy;
    public GameObject weaponedSourEnemy;

    // Sound Effect
    public AudioSource enemiesSpawnSoundEffect;

    void Start()
    {
        timeSpawnerLimit = Random.Range(1, 2);
        chanceSpawnLimit = Random.Range(1, 2);
    }


    void Update()
    {
        timeSpawnerLimit -= 1 * Time.deltaTime;


        if (timeSpawnerLimit <= 0)
        {
            enemiesSpawnSoundEffect.Play();

            if (GameManager.Instance.countdownTimer >= 200 && GameManager.Instance.countdownTimer <= 300)
            {
                // Spawn Normal Enmey
                Vector3 spawnPosition = new Vector3(Random.Range(-30f, 19f), 1f, Random.Range(-41f, 16f));
                Instantiate(normalSourEnemy, spawnPosition, Quaternion.identity);
                GameManager.Instance.enemyCounts += 1;
                GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);

                // Doesn't Spawn Guned Enemy at this time

                timeSpawnerLimit = Random.Range(3, 6);

            }


            if (GameManager.Instance.countdownTimer >= 100 && GameManager.Instance.countdownTimer < 200)
            {

                // Spawn Normal Enemy
                Vector3 spawnPosition = new Vector3(Random.Range(-30f, 19f), 1f, Random.Range(-41f, 16f));
                Instantiate(normalSourEnemy, spawnPosition, Quaternion.identity);
                GameManager.Instance.enemyCounts += 1;
                GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);

                // Spawn Guned Enemy
                Vector3 spawnPosition2 = new Vector3(Random.Range(-30f, 19f), 1f, Random.Range(-41f, 16f));
                Instantiate(weaponedSourEnemy, spawnPosition2, Quaternion.identity);
                GameManager.Instance.enemyCounts += 1;
                GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);


                timeSpawnerLimit = Random.Range(2, 4);

            }


            if (GameManager.Instance.countdownTimer < 100)
            {

                // Spawn Normal Enemy
                Vector3 spawnPosition = new Vector3(Random.Range(-30f, 19f), 1f, Random.Range(-41f, 16f));
                Instantiate(normalSourEnemy, spawnPosition, Quaternion.identity);
                GameManager.Instance.enemyCounts += 1;
                GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);


                // Spawn Guned Enemy
                Vector3 spawnPosition2 = new Vector3(Random.Range(-30f, 19f), 1f, Random.Range(-41f, 16f));
                Instantiate(weaponedSourEnemy, spawnPosition2, Quaternion.identity);
                GameManager.Instance.enemyCounts += 1;
                GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);


                timeSpawnerLimit = Random.Range(1, 2);
            }




        }
    }
}
