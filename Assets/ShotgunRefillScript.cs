using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunRefillScript : MonoBehaviour
{
    public AudioSource pickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.shotgunAmmons += 10;
            GameManager.Instance.shotgunAmmonsText.text = "SHOT GUM AMMO: " + Mathf.Round(GameManager.Instance.shotgunAmmons);
            GameManager.Instance.ballCounts += 25;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            pickUpSound.Play();
            Destroy(this.gameObject);
        }
    }
}
