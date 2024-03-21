using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletLimited = 6f;
    public ParticleSystem bulletEffect;
    public Transform bulletPosition;

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
        if (other.CompareTag("Enemies"))
        {
            ParticleSystem disapperEffect = Instantiate(bulletEffect, bulletPosition.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
