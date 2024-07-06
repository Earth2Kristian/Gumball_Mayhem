using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHitCollider : MonoBehaviour
{
    //public GameObject playerCamera;
    //public Animator playerCameraAnimate;

    public AudioSource playerHurtSoundEffect;
    public AudioSource playerHurtSoundEffect2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.healthCurrent -= 5;
            GameManager.Instance.healthBar.UpdateHealthhBar(GameManager.Instance.healthCurrent, GameManager.Instance.healthLimited);
            GameManager.Instance.healthText.text = " " + Mathf.Round(GameManager.Instance.healthCurrent);

            GameManager.Instance.playerGotHit = true;

            if (GameManager.Instance.health > 0)
            {
                playerHurtSoundEffect.Play();
                playerHurtSoundEffect2.Play();
            }
        }


    }
}
