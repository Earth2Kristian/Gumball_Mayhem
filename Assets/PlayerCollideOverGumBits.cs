using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideOverGumBits : MonoBehaviour
{
    public AudioSource pickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ballCounts += Random.Range(20, 30);
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            pickUpSound.Play();
            Destroy(this.gameObject);

        }
    }
}
