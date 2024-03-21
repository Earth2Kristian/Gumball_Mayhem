using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRefillerScript : MonoBehaviour
{
    public AudioSource healthSoundEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.healthCurrent += 50;
            GameManager.Instance.healthBar.UpdateHealthhBar(GameManager.Instance.healthCurrent, GameManager.Instance.healthLimited);
            GameManager.Instance.ballCounts += 25;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            healthSoundEffect.Play();
            Destroy(this.gameObject);
        }
    }
}
