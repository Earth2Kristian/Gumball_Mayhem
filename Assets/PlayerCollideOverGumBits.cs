using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideOverGumBits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ballCounts += Random.Range(20, 30);
            GameManager.Instance.ballCountsText.text = "SCORE: " + Mathf.Round(GameManager.Instance.ballCounts);
            Destroy(this.gameObject);

        }
    }
}
