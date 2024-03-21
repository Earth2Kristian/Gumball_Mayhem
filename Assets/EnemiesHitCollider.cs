using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHitCollider : MonoBehaviour
{

    public AudioSource playerHurtSoundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.healthCurrent -= 5;
            GameManager.Instance.healthBar.UpdateHealthhBar(GameManager.Instance.healthCurrent, GameManager.Instance.healthLimited);

            if (GameManager.Instance.health > 0)
            {
                playerHurtSoundEffect.Play();
            }
        }
    }
}
