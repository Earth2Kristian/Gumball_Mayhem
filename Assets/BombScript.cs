using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    // Basic Bomb Variables including Particles and Time Limted
    public ParticleSystem explosionEffect;
    public Transform bombPosition;

    public float timeLimited = 3f;

    public float bombDestroy = 3.25f;



    void Update()
    {
        timeLimited -= 1 * Time.deltaTime;
        bombDestroy -= 1 * Time.deltaTime;

        if (timeLimited <= 0 && explosionEffect != null)
        {
            BombExplode();
            BombDestroy();
        }
    }

    public void BombExplode()
    {
        ParticleSystem playEffect = Instantiate(explosionEffect, bombPosition.position, Quaternion.identity);
    }
    public void BombDestroy()
    {
        Destroy(this.gameObject);
    }
}
