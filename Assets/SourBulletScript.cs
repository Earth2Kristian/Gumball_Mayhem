using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourBulletScript : MonoBehaviour
{
    public float BulletLimited = 6f;
    public ParticleSystem bulletEffect;
    public Transform bulletPosition;
    public AudioSource playerHurtSoundEffect;
    public AudioSource playerHurtSoundEffect2;

    void Update()
    {
        BulletLimited -= 1 * Time.deltaTime;

        if (BulletLimited <= 0)
        {
            ParticleSystem disapperEffect = Instantiate(bulletEffect, bulletPosition.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ParticleSystem disapperEffect = Instantiate(bulletEffect, bulletPosition.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.Instance.healthCurrent -= 10;
            GameManager.Instance.healthBar.UpdateHealthhBar(GameManager.Instance.healthCurrent, GameManager.Instance.healthLimited);
            GameManager.Instance.healthText.text = " " + Mathf.Round(GameManager.Instance.healthCurrent);

            GameManager.Instance.playerGotHit = true;

            playerHurtSoundEffect2.Play();
            if (GameManager.Instance.health > 0 )
            {
                playerHurtSoundEffect.Play();
            }
            
        }
    }
}
