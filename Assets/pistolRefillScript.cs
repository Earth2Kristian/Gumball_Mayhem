using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolRefillScript : MonoBehaviour
{
    public AudioSource pickUpSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.pistolAmmons += 50;
            GameManager.Instance.pistolAmmonsText.text = "HAND GUN AMMO: " + Mathf.Round(GameManager.Instance.pistolAmmons);
            GameManager.Instance.ballCounts += 25;
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            pickUpSound.Play();
            Destroy(this.gameObject);
        }    
    }
}
