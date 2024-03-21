using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy2Script : MonoBehaviour
{
    private string currentState = "IdleState";
    private NavMeshAgent meshAgent;
    public Transform target;
    public Animator animate;

    // Enemy's Gun Settings
    public GameObject sourBullets;
    public Transform sourBulletsPosition;
    public float timeToShoot;


    private float distance;


    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animator>();

        timeToShoot = Random.Range(2, 4);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        meshAgent.SetDestination(target.position);
        meshAgent.speed = 3.5f;

        timeToShoot -= 1 * Time.deltaTime;

        if (timeToShoot <= 0)
        {
            GameObject bullet = Instantiate(sourBullets, sourBulletsPosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(sourBulletsPosition.forward * 600);
            timeToShoot = Random.Range(2, 4);
        }

        

    }
}
