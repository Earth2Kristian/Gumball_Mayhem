using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleRefillScript : MonoBehaviour
{
    public AudioSource pickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.rifleAmmons += 200;
            GameManager.Instance.rifleAmmonsText.text = "RIFLE GUM AMMO: " + Mathf.Round(GameManager.Instance.rifleAmmons);
            GameManager.Instance.ballCounts += 25;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            pickUpSound.Play();
            Destroy(this.gameObject);
        }
    }
}
