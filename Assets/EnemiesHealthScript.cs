using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealthScript : MonoBehaviour
{
    private static EnemiesHealthScript instance = null;
    public float enemiesHealth;

    // Hit Particles Effect
    public ParticleSystem hitEffect;
    public Transform hitPosition;

    // Destory Particles Effect
    public ParticleSystem destoryEffect;
    public ParticleSystem destoryEffect2;
    public Transform destoryPosition;
    public GameObject gumBits;
    public Transform gumPosition;

    // Sound Effects
    public AudioSource enemiesHurtSoundEffect;
    public AudioSource enemiesHurtSoundEffect2;
    public AudioSource enemiesDiesSoundEffect;
    
    void Start()
    {
        enemiesHealth = 100;
    }

    
    void Update()
    {
        if (enemiesHealth <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Instance.ballCounts += 50;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            ParticleSystem playEffect = Instantiate(destoryEffect, destoryPosition.position, Quaternion.identity);
            ParticleSystem playEffect2 = Instantiate(destoryEffect2, gumPosition.position, Quaternion.identity);
            GameObject appearGumBits = Instantiate(gumBits, gumPosition.position, Quaternion.identity);
            enemiesDiesSoundEffect.Play();
            GameManager.Instance.enemyCounts -= 1;
            GameManager.Instance.enemyCounterText.text = "ENEMY: " + Mathf.Round(GameManager.Instance.enemyCounts);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gumballs"))
        {
            enemiesHealth -= 25;
            GameManager.Instance.ballCounts += 20;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            ParticleSystem playHitEffect = Instantiate(hitEffect, hitPosition.position, Quaternion.identity);  
            if (enemiesHealth > 0)
            {
                enemiesHurtSoundEffect.Play();
                enemiesHurtSoundEffect2.Play();
            }
            
        }
        if (other.CompareTag("BasicGum"))
        {
            enemiesHealth -= 50;
            GameManager.Instance.ballCounts += 10;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            ParticleSystem playHitEffect = Instantiate(hitEffect, hitPosition.position, Quaternion.identity);
            if (enemiesHealth > 0)
            {
                enemiesHurtSoundEffect.Play();
                enemiesHurtSoundEffect2.Play();
            }

        }
        if (other.CompareTag("ShotGum"))
        {
            enemiesHealth -= 100;
            GameManager.Instance.ballCounts += 30;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            ParticleSystem playHitEffect = Instantiate(hitEffect, hitPosition.position, Quaternion.identity);
            enemiesDiesSoundEffect.Play();
            enemiesHurtSoundEffect2.Play();

        }
        if (other.CompareTag("Explosion"))
        {
            enemiesHealth -= 100;
            GameManager.Instance.ballCounts += 40;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            enemiesDiesSoundEffect.Play();
            enemiesHurtSoundEffect2.Play();
        }
    }

    void Awake()
    {
        instance = this;
    }

    public static EnemiesHealthScript Instance
    {
        get
        {
            return instance;
        }
    }
}
