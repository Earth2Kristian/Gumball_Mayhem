using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillsSpawners : MonoBehaviour
{
    // Ammon Refillers
    public GameObject pistolAmmonRefillerObject;
    public GameObject rifleAmmonRefillerObject;
    public GameObject shotgunAmmonRefillerObject;
    public GameObject healthFillerObject;

    // Timer Spawn for each ammon refillers
    public float pistolRefillTimeSpawn;
    public float rifleRefillTimeSpawn;
    public float shotgunRefillTimeSpawn;
    public float healthFillerTimeSpawn;


    void Start()
    {
        pistolRefillTimeSpawn = Random.Range(20, 40);
        rifleRefillTimeSpawn = Random.Range(40, 60);
        shotgunRefillTimeSpawn = Random.Range(60, 80);
        healthFillerTimeSpawn = Random.Range(30, 45);
    }
    void Update()
    {
        pistolRefillTimeSpawn -= 1 * Time.deltaTime;
        rifleRefillTimeSpawn -= 1 * Time.deltaTime;
        shotgunRefillTimeSpawn -= 1 * Time.deltaTime;
        healthFillerTimeSpawn -= 1 * Time.deltaTime;

        if (pistolRefillTimeSpawn <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-22.8f, 22.5f), 1f, Random.Range(-20.8f, 18.9f));
            Instantiate(pistolAmmonRefillerObject, randomSpawnPosition, Quaternion.identity);
            pistolRefillTimeSpawn = Random.Range(20, 40);
        }
        if (rifleRefillTimeSpawn <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-22.8f, 22.5f), 1f, Random.Range(-20.8f, 18.9f));
            Instantiate(rifleAmmonRefillerObject, randomSpawnPosition, Quaternion.identity);
            rifleRefillTimeSpawn = Random.Range(40, 60);
        }
        if (shotgunRefillTimeSpawn <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-22.8f, 22.5f), 1f, Random.Range(-20.8f, 18.9f));
            Instantiate(shotgunAmmonRefillerObject, randomSpawnPosition, Quaternion.identity);
            shotgunRefillTimeSpawn = Random.Range(60, 80);
        }
        if (healthFillerTimeSpawn <= 0)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-22.8f, 22.5f), 1f, Random.Range(-20.8f, 18.9f));
            Instantiate(healthFillerObject, randomSpawnPosition, Quaternion.Euler(-90, 0, 0));
            healthFillerTimeSpawn = Random.Range(30, 45);
        }



    }
}
